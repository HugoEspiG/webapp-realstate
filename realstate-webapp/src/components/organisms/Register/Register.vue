<template>
  <div class="card mb-3 text-center mt-5 mx-auto shadow-lg custom-tam">
    <div class="card-body">
      <FormItem :formFields="formFields" formId="form-reg" :submitCallback="handleSubmitForm" />
      <Button @click="handleSubmitForm" :variant="submitButtonVariant" :size="submitButtonSize" :class="submitButtonClass"
        form="form-reg">
        Sign Up
      </Button>
    </div>
    <div id="SubmitOk" class="alert alert-success alert-dimissible fade show" role="alert" hidden></div>
    <div id="SubmitFail" class="alert alert-danger" role="alert" hidden></div>
  </div>
</template>
  
<script>
import axios from 'axios'
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
          name: 'Sign up',
          fields: [{
            name: 'name',
            type: 'text',
            id: 'name',
            placeholder: 'Name',
            label: 'Name',
            validationRules: { required },
            typeInput: 'input',
            class: 'col-md-8'
          },
          {
            name: 'user',
            type: 'text',
            id: 'user',
            placeholder: 'Username',
            label: 'Username',
            validationRules: { required, email },
            typeInput: 'input',
            class: 'col-md-8'
          },
          {
            name: 'password',
            type: 'password',
            id: 'password',
            placeholder: 'Password',
            label: 'Password',
            validationRules: { required, minLength: minLength(6), maxLength: maxLength(20) },
            typeInput: 'input',
            class: 'col-md-6'
          },
          {
            name: 'confPassword',
            type: 'password',
            id: 'confPassword',
            placeholder: 'Confirm Password',
            label: 'Confirm Password',
            validationRules: { required, sameAs: "password" },
            typeInput: 'input',
            class: 'col-md-6'
          }
          ]
        }
      ],
      submitButtonVariant: 'primary',
      submitButtonSize: 'lg',
      submitButtonClass: 'mt-3 mw-25'
    };
  },
  methods: {
    submitfunction(v,state) {
      //console.log(this.v$);
      if (!v.$error && !v.$invalid) {
        axios.post("Client/Register", {
          Name:state.name,
          Email: state.user,
          Password: state.password,
          Rol:"Client"
        }).then((response) => {
          console.log(response.status);
          document.getElementById("SubmitOk").innerHTML = response.data;
          document.getElementById("SubmitOk").removeAttribute("hidden");
          setTimeout(() => {
            document.getElementById("SubmitOk").setAttribute("hidden", "hidden");
          }, 1500);
          this.$router.push('/login');
        }).catch(e => {
          document.getElementById("SubmitFail").innerHTML = e.response.data;
          document.getElementById("SubmitFail").removeAttribute("hidden");
          setTimeout(() => {
            document.getElementById("SubmitFail").setAttribute("hidden", "hidden");
          }, 1500);
        })
      } else {
        document.getElementById("SubmitFail").innerHTML = "Data does not match";
        document.getElementById("SubmitFail").removeAttribute("hidden");
        setTimeout(() => {
          document.getElementById("SubmitFail").setAttribute("hidden", "hidden");
        }, 1500);
      }
    }
  }
};
</script>
  
<style>
.custom-tam {
  width: 80%;
}
</style>
  
  