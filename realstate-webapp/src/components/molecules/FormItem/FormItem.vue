<template>
    <div>
        <form @submit.prevent="submitForm" :id="formId" class="mt-5 col mx-4">
            <div v-for="(field, index) in fields" :key="index">
                <InputItem v-model.trim="state[field.name]" :type="field.type" :id="field.id"
                    :placeholder="field.placeholder" :label="field.label" :error="v$[field.name].$error"
                    :errorMessage="getErrorMessage(field.name)" />
            </div>
        </form>
        <Button :variant="submitButtonVariant" :size="submitButtonSize" :class="submitButtonClass" :type="submitButtonType"
            :form="formId">
            {{ submitButtonText }}
        </Button>
    </div>
</template>
  
<script>
import InputItem from '../../atoms/InputItem/InputItem.vue';
import Button from '../../atoms/Button/Button.vue';
import axios from 'axios';
import { useVuelidate } from '@vuelidate/core';
import { reactive, computed } from 'vue';
import { sameAs } from '@vuelidate/validators';

export default {
    name: 'FormItem',
    components: {
        Button,
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
        }
    },
    setup(props) {
        const state = reactive(
            Object.fromEntries(
                props.fields.map(field => [field.name, ''])
            )
        );
        // Generar las reglas de validación dinámicamente según los campos recibidos
        const rules = computed(() => {
            const validationRules = {}
            props.fields.forEach(field => {
                validationRules[field.name] = field.validationRules
                if (validationRules[field.name].sameAs) {
                    const fieldName = field.validationRules.sameAs;
                    console.log(state[fieldName]);
                    validationRules[field.name].sameAs=sameAs(state[fieldName],"user");
                    console.log(validationRules[field.name]);
                }
            })
            return validationRules
        })
    const v$ = useVuelidate(rules, state)

        return {
        state,
        v$
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
    submitForm() {
        this.v$.$validate()
        console.log(this.v$);
        if (!this.v$.$error && !this.v$.$invalid) {
            ;
            axios.get(variables.MONGOAPI + "Client/Login?login=" + this.state.user + "&password=" + this.state.password, {}).then((response) => {
                console.log(response.data);
            })
        } else {
        }

        //El otro caso del register:
        //console.log(this.v$);
        // this.v$.$validate()
        // document.getElementById('btnSubmit').disable = true;
        // if (!this.v$.$error && !this.v$.$invalid) {
        //     console.log(variables.MONGOAPI + "Client/Register");
        //     axios.post(variables.MONGOAPI + "Client/Register", {
        //         Name: this.state.name,
        //         Password: this.state.password,
        //         Email: this.state.user
        //     }).then((response) => {
        //         console.log(response.data);
        //         let element = response.data == "Successfully added" ? "SubmitOk" : "SubmitFail";
        //         document.getElementById(element).innerHTML = response.data;
        //         document.getElementById(element).removeAttribute("hidden");
        //         setTimeout(() => {
        //             document.getElementById(element).setAttribute("hidden", "hidden");
        //         }, 1500);
        //     })
        // } else {
        //     document.getElementById("SubmitFail").removeAttribute("hidden");
        //     setTimeout(() => {
        //         document.getElementById("SubmitFail").setAttribute("hidden", "hidden");
        //     }, 1500);
        // }
        // document.getElementById('btnSubmit').disable = false;

    }
}
};
</script>
  
<style>
/* Estilos personalizados para el formulario si es necesario */
</style>
  