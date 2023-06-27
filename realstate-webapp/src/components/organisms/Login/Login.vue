<template>
  <div class="card mb-3 text-center mt-5 mx-auto shadow-lg custom-tam">
    <div class="card-body">
      <PItem variant="fs-3" color="dark" class="my-2 card-title">Log in</PItem>
      <div class="col">
        <FormItem :fields="formFields" formId="form-log" :submitButtonVariant="submitButtonVariant"
          :submitButtonSize="submitButtonSize" :submitButtonClass="submitButtonClass" />
        <PItem variant="fs-5" color="dark" class="my-2">
          ¿Aún no estás registrado? <RouterLink to="/register"> Registrate</RouterLink>
        </PItem>
        <div class="divider"> OR</div>
        <Button variant="outline-primary" size="lg" class="bi bi-google mt-3 mw-25" type="submit" form="form-log"> Log in
          con Google</Button>
      </div>
    </div>
  </div>
</template>

<script>
import FormItem from '../../molecules/FormItem/FormItem.vue';
import Button from '../../atoms/Button/Button.vue';
import PItem from '../../atoms/PItem/PItem.vue';
import { required, email, minLength, maxLength } from '@vuelidate/validators';

export default {
  name: 'Login',
  components: {
    FormItem,
    Button,
    PItem
  },
  data() {
    return {
      formFields: [
        {
          name: 'user',
          type: 'text',
          id: 'user',
          placeholder: 'Username',
          label: 'Username',
          validationRules: { required, email }
        },
        {
          name: 'password',
          type: 'password',
          id: 'password',
          placeholder: 'Password',
          label: 'Password',
          validationRules: { required, minLength: minLength(6), maxLength: maxLength(20) }
        }
      ],
      submitButtonVariant: 'primary',
      submitButtonSize: 'lg',
      submitButtonClass: 'mt-3 mw-25'
    };
  },
  methods: {
    submitForm() {
      this.v$.$validate()
      if (!this.v$.$error && !this.v$.$invalid) {
        ;
        axios.post(variables.MONGOAPI + "Client/Login", {
          Email: this.state.user,
          Password: this.state.password
        }).then((response) => {
          console.log(response.data);
          //window.localStorage.setItem("token",response.data);
        }).catch(e => console.log(e.response));
      } else {
      }
    }
  }
};
</script>


<style>
.custom-tam {
  width: 35%;
}
</style>

