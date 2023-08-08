<template>
    <div class="container mt-5">
        <form @submit.prevent="submitfunction" :id="formId">
            <div v-for="(category, index) in formFields" :key="index">
                <PItem variant="fs-3" color="dark" class="my-2 card-title">{{ category.name }}</PItem>
                <div class="row justify-content-center">
                    <div v-for="(field, fieldIndex) in category.fields" :key="fieldIndex" :class="field.class">
                        <InputItem v-if="field.typeInput === 'input' && !field.optional" v-model.trim="state[field.name]"
                            :type="field.type" :id="field.id" :placeholder="field.placeholder" :label="field.label"
                            :error="v$[field.name].$error" :errorMessage="getErrorMessage(field.name)" />
                        <SelectItem v-else-if="field.typeInput === 'select' && !field.optional"
                            v-model.trim="state[field.name]" :id="field.id" :options="field.options" :label="field.label"
                            :error="v$[field.name].$error" :errorMessage="getErrorMessage(field.name)" />
                        <DatePickerItem v-else-if="field.typeInput === 'date' && !field.optional"
                            v-model.trim="state[field.name]" :type="field.type" :id="field.id"
                            :error="v$[field.name].$error" :errorMessage="getErrorMessage(field.name)" />
                        <div v-if="field.optional && field.showCondition(state)">
                            <InputItem v-if="field.typeInput === 'input'" v-model.trim="state[field.name]"
                                :type="field.type" :id="field.name" :placeholder="field.placeholder" :label="field.label"
                                :error="v$[field.name].$error" :errorMessage="getErrorMessage(field.name)" />
                            <SelectItem v-else-if="field.typeInput === 'select'"
                                v-model.trim="state[field.name]" :id="field.id" :options="field.options"
                                :label="field.label" :error="v$[field.name].$error"
                                :errorMessage="getErrorMessage(field.name)" />
                            <DatePickerItem v-else-if="field.typeInput === 'date'" v-model.trim="state[field.name]"
                                :type="field.type" :id="field.id" :error="v$[field.name].$error"
                                :errorMessage="getErrorMessage(field.name)" />
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</template>
  
<script>
import InputItem from '../../atoms/InputItem/InputItem.vue';
import PItem from '../../atoms/PItem/PItem.vue';
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
        InputItem,
        PItem
    },
    props: {
        formFields: {
            type: Array,
            required: true
        },
        formId: {
            type: String,
            required: true
        },
        submitCallback: {
            type: Function,
            required: true
        }
    },
    setup(props) {
        const state = reactive(
            props.formFields.reduce((acc, category) => {
                category.fields.forEach(field => {
                    acc[field.name] = '';
                });
                return acc;
            }, {})
        );

        const validationRules = {}
        props.formFields.forEach(category => {
            category.fields.forEach(field => {
                validationRules[field.name] = field.validationRules
                if (validationRules[field.name].sameAs) {
                    // Obtener el nombre del campo al que se debe hacer referencia
                    console.log(validationRules[field.name].sameAs);

                    const fieldName = validationRules[field.name].sameAs;
                    // Crear una función de validación dinámica para sameAs
                    validationRules[field.name].sameAs = sameAs(state[fieldName], validationRules[field.name].sameAs)
                }
            })
        })


        const rules = computed(() => {
            props.formFields.forEach(category => {
                category.fields.forEach(field => {
                    validationRules[field.name] = field.validationRules;
                });
            });
            return validationRules;
        });
        const v$ = useVuelidate(rules, state)


        return {
            state,
            v$,
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
            this.v$.$validate()
            this.submitCallback(this.v$, this.state)
        }
    }
};
</script>
  
<style>
/* Estilos personalizados para el formulario si es necesario */
</style>
  