<template>
    <div class="card mb-3 text-center mt-5 mx-auto shadow-lg custom-tam">
        <div>
            <div class="card-body">
                <FormItem :formFields="formFields" formId="form-log" :submitCallback="handleSubmitForm" />
                <Button @click="handleSubmitForm" :variant="submitButtonVariant" :size="submitButtonSize"
                    :class="submitButtonClass" form="form-log">
                    Save
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
                            class: 'col-md-8'
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
                                return data.familyMembers >= 1;
                            }
                        },
                        {
                            name: "FamilyType1Salary",
                            type: 'number',
                            id: "FamilyType1Salary",
                            placeholder: "Relative's Salary",
                            label: "Relative's Salary",
                            validationRules: { required },
                            typeInput: 'input',
                            class: 'col-md-4',
                            optional: true,
                            showCondition: (data) => {
                                return data.FamilyType1 === 'no' && data.familyMembers != 0;
                            }
                        },
                        {
                            name: 'FamilyType2',
                            type: 'text',
                            id: 'FamilyType2',
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
                                return data.familyMembers >= 2;
                            }
                        },
                        {
                            name: "FamilyType2Salary",
                            type: 'number',
                            id: "FamilyType2Salary",
                            placeholder: "Relative's Salary",
                            label: "Relative's Salary",
                            validationRules: { required },
                            typeInput: 'input',
                            class: 'col-md-4',
                            optional: true,
                            showCondition: (data) => {
                                return data.FamilyType2 === 'no' && data.familyMembers > 1;
                            }
                        },
                        {
                            name: 'FamilyType3',
                            type: 'text',
                            id: 'FamilyType3',
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
                                return data.familyMembers >= 3;
                            }
                        },
                        {
                            name: "FamilyType3Salary",
                            type: 'number',
                            id: "FamilyType3Salary",
                            placeholder: "Relative's Salary",
                            label: "Relative's Salary",
                            validationRules: { required },
                            typeInput: 'input',
                            class: 'col-md-4',
                            optional: true,
                            showCondition: (data) => {
                                return data.FamilyType3 === 'no' && data.familyMembers > 2;
                            }
                        },
                        {
                            name: 'FamilyType4',
                            type: 'text',
                            id: 'FamilyType4',
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
                                return data.familyMembers >= 4;
                            }
                        },
                        {
                            name: "FamilyType4Salary",
                            type: 'number',
                            id: "FamilyType3Salary",
                            placeholder: "Relative's Salary",
                            label: "Relative's Salary",
                            validationRules: { required },
                            typeInput: 'input',
                            class: 'col-md-4',
                            optional: true,
                            showCondition: (data) => {
                                return data.FamilyType4 === 'no' && data.familyMembers > 3;
                            }
                        },
                        {
                            name: 'familyVehicles',
                            type: 'number',
                            id: 'familyVehicles',
                            placeholder: 'Family Car hire',
                            label: 'Family Car hire',
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
                            class: 'col-md-8'
                        },
                    ]
                },
                {
                    name: 'Labor',
                    fields: [
                        {
                            name: 'Employee',
                            type: 'text',
                            id: 'Employee',
                            placeholder: 'Employee',
                            label: 'Employee',
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
                        },
                        {
                            name: 'BusinessOwner',
                            type: 'text',
                            id: 'BusinessOwner',
                            placeholder: 'Business Owner',
                            label: 'Business Owner',
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
                                return data.Employee === 'no';
                            }
                        },
                        {
                            name: "JobEntity",
                            type: 'text',
                            id: "JobEntity",
                            placeholder: "Job Entity",
                            label: "Job Entity",
                            validationRules: { required },
                            typeInput: 'input',
                            class: 'col-md-4',
                            optional: true,
                            showCondition: (data) => {
                                return data.Employee === 'yes' || data.BusinessOwner === 'yes';
                            }
                        },
                        {
                            name: "Salary",
                            type: 'number',
                            id: "Salary",
                            placeholder: "Salary in COP",
                            label: "Salary in COP",
                            validationRules: { required },
                            typeInput: 'input',
                            class: 'col-md-4',
                            optional: true,
                            showCondition: (data) => {
                                return data.Employee === 'yes' || data.BusinessOwner === 'yes';
                            }
                        },
                        {
                            name: "JobTitle",
                            type: 'text',
                            id: "JobTitle",
                            placeholder: "Job Title",
                            label: "Job Title",
                            validationRules: { required },
                            typeInput: 'input',
                            class: 'col-md-4',
                            optional: true,
                            showCondition: (data) => {
                                return data.Employee === 'yes';
                            }
                        },
                        {
                            name: 'FinancialObligations',
                            type: 'text',
                            id: 'FinancialObligations',
                            placeholder: 'Financial Obligations',
                            label: 'Financial Obligations',
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
                        },
                        {
                            name: "FinancialObligationsReason",
                            type: 'text',
                            id: "FinancialObligationsReason",
                            placeholder: "Financial Obligations Reason",
                            label: "Financial Obligations Reason",
                            validationRules: { required },
                            typeInput: 'input',
                            class: 'col-md-6',
                            optional: true,
                            showCondition: (data) => {
                                return data.FinancialObligations === 'yes';
                            }
                        },
                        {
                            name: "FinancialObligationsQuantity",
                            type: 'number',
                            id: "FinancialObligationsQuantity",
                            placeholder: "Financial Obligations Quantity in COP",
                            label: "Financial Obligations Quantity in COP",
                            validationRules: { required },
                            typeInput: 'input',
                            class: 'col-md-6',
                            optional: true,
                            showCondition: (data) => {
                                return data.FinancialObligations === 'yes';
                            }
                        },
                    ]
                },
                {
                    name: 'Hobbies',
                    fields: [
                        {
                            name: 'Sport',
                            type: 'text',
                            id: 'Sport',
                            placeholder: 'Sports',
                            label: 'Sports',
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
                            class: 'col-md-4',
                        },
                        {
                            class: 'col-md-6',
                            checkboxes: [
                                {
                                    name: "Futbol",
                                    type: 'checkbox',
                                    id: "Futbol",
                                    label: "Futbol",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Sport === 'yes';
                                    }
                                },
                                {
                                    name: "Tenis",
                                    type: 'checkbox',
                                    id: "Tenis",
                                    label: "Tenis",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Sport === 'yes';
                                    }
                                },
                                {
                                    name: "Baloncesto",
                                    type: 'checkbox',
                                    id: "Baloncesto",
                                    label: "Baloncesto",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Sport === 'yes';
                                    }
                                },
                                {
                                    name: "Baseball",
                                    type: 'checkbox',
                                    id: "Baseball",
                                    label: "Baseball",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Sport === 'yes';
                                    }
                                },
                                {
                                    name: "Golf",
                                    type: 'checkbox',
                                    id: "Golf",
                                    label: "Golf",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Sport === 'yes';
                                    }
                                },
                                {
                                    name: "Voleyball",
                                    type: 'checkbox',
                                    id: "Voleyball",
                                    label: "Voleyball",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Sport === 'yes';
                                    }
                                },
                                {
                                    name: "Ciclismo",
                                    type: 'checkbox',
                                    id: "Ciclismo",
                                    label: "Ciclismo",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Sport === 'yes';
                                    }
                                },
                                {
                                    name: "Rugby",
                                    type: 'checkbox',
                                    id: "Rugby",
                                    label: "Rugby",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Sport === 'yes';
                                    }
                                },
                                {
                                    name: "Natacion",
                                    type: 'checkbox',
                                    id: "Natacion",
                                    label: "Natacion",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Sport === 'yes';
                                    }
                                },
                                {
                                    name: "GYM",
                                    type: 'checkbox',
                                    id: "GYM",
                                    label: "GYM",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Sport === 'yes';
                                    }
                                },
                            ]
                        },
                        {
                            name: 'Food',
                            type: 'text',
                            id: 'Food',
                            placeholder: 'Food',
                            label: 'Food',
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
                            class: 'col-md-4',
                        },
                        {
                            class: 'col-md-6',
                            checkboxes: [
                                {
                                    name: "SeaFood",
                                    type: 'checkbox',
                                    id: "SeaFood",
                                    label: "SeaFood",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Food === 'yes';
                                    }
                                },
                                {
                                    name: "Itaian",
                                    type: 'checkbox',
                                    id: "Italian",
                                    label: "Italian",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Food === 'yes';
                                    }
                                },
                                {
                                    name: "Mexican",
                                    type: 'checkbox',
                                    id: "Maxican",
                                    label: "Mexican",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Food === 'yes';
                                    }
                                },
                                {
                                    name: "Chinese",
                                    type: 'checkbox',
                                    id: "Chinese",
                                    label: "Chinese",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Food === 'yes';
                                    }
                                },
                                {
                                    name: "Peruvian",
                                    type: 'checkbox',
                                    id: "Peruvian",
                                    label: "Peruvian",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Food === 'yes';
                                    }
                                },
                                {
                                    name: "French",
                                    type: 'checkbox',
                                    id: "French",
                                    label: "French",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Food === 'yes';
                                    }
                                },
                                {
                                    name: "Fast",
                                    type: 'checkbox',
                                    id: "Fast",
                                    label: "Fast",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Food === 'yes';
                                    }
                                },
                                {
                                    name: "Spain",
                                    type: 'checkbox',
                                    id: "Spain",
                                    label: "Spain",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Food === 'yes';
                                    }
                                },
                                {
                                    name: "Arabic",
                                    type: 'checkbox',
                                    id: "Arabic",
                                    label: "Arabic",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Food === 'yes';
                                    }
                                },
                                {
                                    name: "Thai",
                                    type: 'checkbox',
                                    id: "Thai",
                                    label: "Thai",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Food === 'yes';
                                    }
                                },
                                {
                                    name: "Japanese",
                                    type: 'checkbox',
                                    id: "Japanese",
                                    label: "Japanese",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Food === 'yes';
                                    }
                                },
                                {
                                    name: "Korean",
                                    type: 'checkbox',
                                    id: "Korean",
                                    label: "Korean",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Food === 'yes';
                                    }
                                },
                                {
                                    name: "Mediterranea",
                                    type: 'checkbox',
                                    id: "Mediterranea",
                                    label: "Mediterranea",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Food === 'yes';
                                    }
                                },
                                {
                                    name: "Colombian",
                                    type: 'checkbox',
                                    id: "Colombian",
                                    label: "Colombian",
                                    validationRules: {},
                                    typeInput: 'checkbox',
                                    class: 'col-md-6 col-sm-12',
                                    optional: true,
                                    showCondition: (data) => {
                                        return data.Food === 'yes';
                                    }
                                },
                            ]
                        },
                    ]
                }
            ],
            submitButtonVariant: 'outline-primary',
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
    
    