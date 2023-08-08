<template>
    <div class="card mb-3 text-center mt-5 mx-auto shadow-lg custom-tam">
        <div>
            <div class="card-body">
                <FormItem :formFields="formFields" formId="form-log" :submitCallback="handleSubmitForm" />
                <Button @click="handleSubmitForm" :variant="submitButtonVariant" :size="submitButtonSize"
                    :class="submitButtonClass" form="form-log">
                    Login
                </Button>
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
            formFields: [
                {
                    name: 'Personal',
                    fields: [
                        {
                            name: 'email',
                            type: 'text',
                            id: 'email',
                            placeholder: 'email',
                            label: 'email',
                            validationRules: { required, email },
                            typeInput: 'input',
                            class: 'col-md-6'
                        },
                        {
                            name: 'phone',
                            type: 'text',
                            id: 'phone',
                            placeholder: 'Phone',
                            label: 'Phone',
                            validationRules: { required },
                            typeInput: 'input',
                            class: 'col-md-4'
                        },
                        {
                            name: 'address',
                            type: 'text',
                            id: 'address',
                            placeholder: 'Address',
                            label: 'Addres',
                            validationRules: { required },
                            typeInput: 'input',
                            class: 'col-md-6'
                        },
                        {
                            name: 'birthday',
                            type: 'date',
                            id: 'birthday',
                            placeholder: 'birthday',
                            label: 'Birthday',
                            typeInput: 'date',
                            validationRules: { required },
                            class: 'col-md-4'
                        }
                    ]
                },
                {
                    name: 'Family',
                    fields: [
                        {
                            name: 'civilStatus',
                            type: 'text',
                            id: 'civilStatus',
                            placeholder: 'Civil Status',
                            label: 'Civil Status',
                            validationRules: { required },
                            typeInput: 'select',
                            options: [
                                {
                                    value: 'soltero',
                                    label: 'Soltero'
                                },
                                {
                                    value: 'casado',
                                    label: 'Casado'
                                },
                                {
                                    value: 'unionlibre',
                                    label: 'Unión Libre'
                                }
                            ],
                            class: 'col-md-6'
                        },
                        {
                            name: "PartnerName",
                            type: 'text',
                            id: "PartnerName",
                            placeholder: "Partner's Name",
                            label: "Partner's Name",
                            validationRules: { required },
                            typeInput: 'input',
                            class: 'col-md-6',
                            optional: true,
                            showCondition: (data) => {
                                return data.civilStatus === 'casado' || data.civilStatus === 'unionlibre';
                            }
                        },
                        {
                            name: "PartnerBirthday",
                            type: 'date',
                            id: 'PartnerBirthday',
                            placeholder: 'Partner Birthday',
                            label: 'Partner Birthday',
                            typeInput: 'date',
                            validationRules: { required },
                            class: 'col-md-4',
                            optional: true,
                            showCondition: (data) => {
                                return data.civilStatus === 'casado' || data.civilStatus === 'unionlibre';
                            }
                        },
                        {
                            name: "PartnerJob",
                            type: 'text',
                            id: "PartnerJob",
                            placeholder: "Partner's Job",
                            label: "Partner's Job",
                            validationRules: { required },
                            typeInput: 'input',
                            class: 'col-md-4',
                            optional: true,
                            showCondition: (data) => {
                                return data.civilStatus === 'casado' || data.civilStatus === 'unionlibre';
                            }
                        },
                        {
                            name: "PartnerSalary",
                            type: 'number',
                            id: "PartnerSalary",
                            placeholder: "Partner's Salary",
                            label: "Partner's Salary",
                            validationRules: { required },
                            typeInput: 'input',
                            class: 'col-md-4',
                            optional: true,
                            showCondition: (data) => {
                                return data.civilStatus === 'casado' || data.civilStatus === 'unionlibre';
                            }
                        },
                        {
                            name: 'familyMembers',
                            type: 'number',
                            id: 'familyMembers',
                            placeholder: 'Family Members',
                            label: 'Family Members',
                            validationRules: { required },
                            typeInput: 'select',
                            options: [
                                {
                                    value: '0',
                                    label: '0'
                                },
                                {
                                    value: '1',
                                    label: '1'
                                },
                                {
                                    value: '2',
                                    label: '2'
                                },
                                {
                                    value: '3',
                                    label: '3'
                                },
                                {
                                    value: '4',
                                    label: '4 o mas'
                                }
                            ],
                            class: 'col-md-6'
                        },
                        {
                            name: 'FamilyType1',
                            type: 'text',
                            id: 'FamilyType1',
                            placeholder: 'Dependent on me',
                            label: 'Dependent on me',
                            validationRules: { required },
                            typeInput: 'select',
                            options: [
                                {
                                    value: 'yes',
                                    label: 'yes'
                                },
                                {
                                    value: 'no',
                                    label: 'no'
                                }
                            ],
                            class: 'col-md-6',
                            optional: true,
                            showCondition: (data) => {
                                return data.familyMembers>=1;
                            }
                        },

                    ]
                },
                {
                    name: 'Labor',
                    fields: [

                    ]
                },
                {
                    name: 'Hobbies',
                    fields: [

                    ]
                }
            ],
            submitButtonVariant: 'primary',
            submitButtonSize: 'lg',
            submitButtonClass: 'mt-3 mw-25',
        };
    },
    methods: {
        handleSubmitForm(v$, state) {
            console.log(state);
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
    width: 100%;
}
</style>
    
    