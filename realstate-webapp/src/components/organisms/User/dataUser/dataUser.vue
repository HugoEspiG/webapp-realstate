<template>
    <div class="card mb-3 text-center mt-5 mx-auto shadow-lg custom-tam">
        <div>
            <div class="card-body">
                <PItem variant="fs-3" color="dark" class="my-2 card-title">Personal Info</PItem>
                <div class="col">
                    <FormItem :fields="formFields.Personal" formId="form-reg" :submitButtonVariant="submitButtonVariant"
                        :submitButtonSize="submitButtonSize" :submitButtonClass="submitButtonClass"
                        :handleSubmitForm="handleSubmitForm" />
                </div>
            </div>
            <div id="SubmitOk" class="alert alert-success alert-dimissible fade show" role="alert" hidden></div>
            <div id="SubmitFail" class="alert alert-danger" role="alert" hidden></div>
        </div>
        <div>
            <div class="card-body">
                <PItem variant="fs-3" color="dark" class="my-2 card-title">Family</PItem>
                <div class="col">
                    <FormItem :fields="formFields.Family" formId="form-reg" :submitButtonVariant="submitButtonVariant"
                        :submitButtonSize="submitButtonSize" :submitButtonClass="submitButtonClass"
                        :handleSubmitForm="handleSubmitForm" />
                </div>
            </div>
            <div id="SubmitOk" class="alert alert-success alert-dimissible fade show" role="alert" hidden></div>
            <div id="SubmitFail" class="alert alert-danger" role="alert" hidden></div>
        </div>
        <div>
            <div class="card-body">
                <PItem variant="fs-3" color="dark" class="my-2 card-title">Labor</PItem>
                <div class="col">
                    <FormItem :fields="formFields.Labor" formId="form-reg" :submitButtonVariant="submitButtonVariant"
                        :submitButtonSize="submitButtonSize" :submitButtonClass="submitButtonClass"
                        :handleSubmitForm="handleSubmitForm" />
                </div>
            </div>
            <div id="SubmitOk" class="alert alert-success alert-dimissible fade show" role="alert" hidden></div>
            <div id="SubmitFail" class="alert alert-danger" role="alert" hidden></div>
        </div>
        <div>
            <div class="card-body">
                <PItem variant="fs-3" color="dark" class="my-2 card-title">Hobbies</PItem>
                <div class="col">
                    <FormItem :fields="formFields.Hobbies" formId="form-reg" :submitButtonVariant="submitButtonVariant"
                        :submitButtonSize="submitButtonSize" :submitButtonClass="submitButtonClass"
                        :handleSubmitForm="handleSubmitForm" />
                </div>
            </div>
            <div id="SubmitOk" class="alert alert-success alert-dimissible fade show" role="alert" hidden></div>
            <div id="SubmitFail" class="alert alert-danger" role="alert" hidden></div>
        </div>
    </div>
</template>
    
<script>
import InputItem from '../../../atoms/InputItem/InputItem.vue'
import Button from '../../../atoms/Button/Button.vue'
import PItem from '../../../atoms/PItem/PItem.vue'
import FormItem from '../../../molecules/FormItem/FormItem.vue';
import { required, email, minLength, maxLength } from '@vuelidate/validators';

export default {
    name: 'Register',
    components: {
        Button,
        PItem,
        InputItem,
        FormItem
    }, data() {
        return {
            formFields: {
                Personal: [
                    {
                        name: 'phone',
                        type: 'text',
                        id: 'phone',
                        placeholder: 'Phone',
                        label: 'Phone',
                        validationRules: { required },
                        typeInput: 'input'
                    },
                    {
                        name: 'address',
                        type: 'text',
                        id: 'address',
                        placeholder: 'Address',
                        label: 'Addres',
                        validationRules: { required },
                        typeInput: 'input'
                    },
                    {
                        name: 'civilStatus',
                        type: 'text',
                        id: 'civilStatus',
                        placeholder: 'Civil Status',
                        label: 'Civil Status',
                        validationRules: { required, sameAs: "user" },
                        typeInput: 'select',
                        options: [
                            {
                                value: 1,
                                label: 'soltero'
                            },
                            {
                                value: 1,
                                label: 'casado'
                            },
                            {
                                value: 1,
                                label: 'union libre'
                            }
                        ]
                    },
                    {
                        name: 'birthday',
                        type: 'text',
                        id: 'birthday',
                        placeholder: 'birthday',
                        label: 'Birthday',
                        validationRules: { required },
                        typeInput: 'date'
                    },
                    {
                        name: 'confPassword',
                        type: 'password',
                        id: 'confPassword',
                        placeholder: 'Confirm Password',
                        label: 'Confirm Password',
                        validationRules: { required, sameAs: "password" }
                    }
                ],
                Family: [

                ],
                Labor: [

                ],
                Hobbies: [

                ]
            },
            submitButtonVariant: 'primary',
            submitButtonSize: 'lg',
            submitButtonClass: 'mt-3 mw-25'
        };
    },
    methods: {
        handleSubmitForm(v$, state) {
            v$.$validate()
            // document.getElementById('btnSubmit').disable = true;
            // if (!v$.$error && !v$.$invalid) {
            //   console.log(variables.MONGOAPI + "Client/Register");
            //   axios.post(variables.MONGOAPI + "Client/Register", {
            //     Email: state.user,
            //     Password: state.password
            //   }).then((response) => {
            //     console.log(response.status);
            //     document.getElementById("SubmitOk").innerHTML = response.data;
            //     document.getElementById("SubmitOk").removeAttribute("hidden");
            //     setTimeout(() => {
            //       document.getElementById("SubmitOk").setAttribute("hidden", "hidden");
            //     }, 1500);
            //     this.$router.push('/login');
            //   }).catch(e => {
            //     document.getElementById("SubmitFail").innerHTML = e.response.data;
            //     document.getElementById("SubmitFail").removeAttribute("hidden");
            //     setTimeout(() => {
            //       document.getElementById("SubmitFail").setAttribute("hidden", "hidden");
            //     }, 1500);
            //   })
            // } else {
            //   document.getElementById("SubmitFail").innerHTML = "Data does not match";
            //   document.getElementById("SubmitFail").removeAttribute("hidden");
            //   setTimeout(() => {
            //     document.getElementById("SubmitFail").setAttribute("hidden", "hidden");
            //   }, 1500);
            // }
            // document.getElementById('btnSubmit').disable = false;
        }
    }
};
</script>
    
<style>
.custom-tam {
    width: 35%;
}
</style>
    
    