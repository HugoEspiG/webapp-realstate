<template>
    <div class="container mt-5">
        <form @submit.prevent="submitfunction" :id="formId">
            <div class="row justify-content-center">
                <div v-for="(field, index) in fields" :key="index" :class="field.class">
                    <InputItem v-if="field.typeInput === 'input'" v-model.trim="state[field.name]" :type="field.type"
                        :id="field.id" :placeholder="field.placeholder" :label="field.label" :error="v$[field.name].$error"
                        :errorMessage="getErrorMessage(field.name)" />
                    <SelectItem v-else-if="field.typeInput === 'select'" v-model.trim="state[field.name]" :id="field.id"
                        :options="field.options" :label="field.label" :error="v$[field.name].$error"
                        :errorMessage="getErrorMessage(field.name)" />
                    <div v-if="showPartnerFields" class="col-md-6">
                        <InputItem v-model.trim="state.partnerName" type="text"
                        id="partnerName" placeholder="Partner's Name" label="Partner's Name" :error="v$[field.name].$error"
                        :errorMessage="getErrorMessage(field.name)" />
                    </div>
                    <DatePickerItem v-else-if="field.typeInput === 'date'" v-model.trim="state[field.name]"
                        :type="field.type" :id="field.id" :error="v$[field.name].$error"
                        :errorMessage="getErrorMessage(field.name)" />
                </div>
            </div>
        </form>
        <Button @click="submitfunction" :variant="submitButtonVariant" :size="submitButtonSize" :class="submitButtonClass"
            :type="submitButtonType" :form="formId">
            {{ submitButtonText }}
        </Button>
    </div>
</template>
  
<script>
import InputItem from '../../atoms/InputItem/InputItem.vue';
import Button from '../../atoms/Button/Button.vue';
import SelectItem from '../../atoms/SelectItem/SelecItem.vue'
import DatePickerItem from '../../atoms/DatePickerItem/DatePickerItem.vue';
import { useVuelidate } from '@vuelidate/core';
import { reactive, computed } from 'vue';
import { sameAs } from '@vuelidate/validators';

export default {
    name: 'FormItem',
    components: {
        Button,
        InputItem,
        SelectItem,
        DatePickerItem,
        InputItem
    },
    props: {
        fields: {
            type: Array,
            required: true
        },
        formId: {
            type: String,
            required: true
        },
        submitButtonVariant: {
            type: String,
            default: 'primary'
        },
        submitButtonSize: {
            type: String,
            default: 'lg'
        },
        submitButtonClass: {
            type: String,
            default: ''
        },
        submitButtonType: {
            type: String,
            default: 'submit'
        },
        submitButtonText: {
            type: String,
            default: 'Submit'
        },
        handleSubmitForm: {
            type: Function,
            required: true
        }
    },
    setup(props) {
        const state = reactive(
            Object.fromEntries(
                props.fields.map(field => [field.name, ''])
            )
        );

        const validationRules = {}

        props.fields.forEach(field => {
            validationRules[field.name] = field.validationRules
            if (validationRules[field.name].sameAs) {
                // Obtener el nombre del campo al que se debe hacer referencia
                console.log(validationRules[field.name].sameAs);

                const fieldName = validationRules[field.name].sameAs;
                // Crear una función de validación dinámica para sameAs
                validationRules[field.name].sameAs = sameAs(state[fieldName], validationRules[field.name].sameAs)
            }
        })
        const rules = computed(() => {
            props.fields.forEach(field => {
                validationRules[field.name] = field.validationRules
            })
            console.log(validationRules);
            return validationRules
        })
        const v$ = useVuelidate(rules, state)

        const showPartnerFields = computed(() => {
            console.log();
            return state.civilStatus === 'casado' || state.civilStatus === 'unionlibre';
        });
        console.log(state);
        return {
            state,
            v$,
            showPartnerFields
        }
    },
    methods: {
        getErrorMessage(inputName) {
            const errorIndex = this.v$.$errors.findIndex(error => error.$property === inputName);
            if (this.v$.$errors.length !== 0 & errorIndex !== -1) {
                return this.v$.$errors[errorIndex].$message
            }
            return '';
        },
        submitfunction() {
            this.handleSubmitForm(this.v$, this.state)
        }
    }
};
</script>
  
<style>
/* Estilos personalizados para el formulario si es necesario */
</style>
  