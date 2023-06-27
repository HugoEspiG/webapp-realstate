<template>
  <div class="card mb-3 text-center mt-5 mx-auto shadow-lg custom-tam">
    <div class="card-body">
      <PItem variant="fs-3" color="dark" class="my-2 card-title">Sign up</PItem>
      <div class="col">
        <FormItem :fields="formFields" formId="form-reg" :submitButtonVariant="submitButtonVariant"
          :submitButtonSize="submitButtonSize" :submitButtonClass="submitButtonClass"/>
      </div>
    </div>
    <div id="SubmitOk" class="alert alert-success alert-dimissible fade show" role="alert" hidden></div>
    <div id="SubmitFail" class="alert alert-danger" role="alert" hidden></div>
  </div>
</template>
  
<script>
import InputItem from '../../atoms/InputItem/InputItem.vue'
import Button from '../../atoms/Button/Button.vue'
import PItem from '../../atoms/PItem/PItem.vue'
import FormItem from '../../molecules/FormItem/FormItem.vue';
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
          name: 'name',
          type: 'text',
          id: 'name',
          placeholder: 'Name',
          label: 'Name',
          validationRules: { required }
        },
        {
          name: 'user',
          type: 'text',
          id: 'user',
          placeholder: 'Username',
          label: 'Username',
          validationRules: { required, email }
        },
        {
          name: 'confUser',
          type: 'text',
          id: 'confUser',
          placeholder: 'Confirm email',
          label: 'Confirm email',
          validationRules: { required, sameAs:"user"}
        },
        {
          name: 'password',
          type: 'password',
          id: 'password',
          placeholder: 'Password',
          label: 'Password',
          validationRules: { required, minLength: minLength(6), maxLength: maxLength(20) }
        },
        {
          name: 'confPassword',
          type: 'password',
          id: 'confPassword',
          placeholder: 'Confirm Password',
          label: 'Confirm Password',
          validationRules: { required, sameAs:"password"}
        }
      ],
      submitButtonVariant: 'primary',
      submitButtonSize: 'lg',
      submitButtonClass: 'mt-3 mw-25'
    };
  }
};
</script>
  
<style>
.custom-tam {
  width: 35%;
}
</style>
  
  