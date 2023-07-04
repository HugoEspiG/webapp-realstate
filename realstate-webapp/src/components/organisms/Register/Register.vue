<template>
  <div class="card mb-3 text-center mt-5 mx-auto shadow-lg custom-tam">
    <div class="card-body">
      <PItem variant="fs-3" color="dark" class="my-2 card-title">Sign up</PItem>
      <div class="col">
        <form @submit.prevent="submitForm" id="form-log" class="mt-5 col mx-4">
          <InputItem v-model.trim="state.user" type="text" id="user" placeholder="mail" label="mail"
            :error="v$.user.$error" errorMessage="El campo no puede estar vacío" />
          <InputItem v-model.trim="state.confUser" type="text" id="confUser" placeholder="Confirm mail"
            label="Confirm mail" :error="v$.user.$error" errorMessage="El campo no puede estar vacío" />
          <InputItem v-model.trim="state.password" type="password" id="password" placeholder="Password" label="Password"
            :error="v$.password.$error" errorMessage="El campo no puede estar vacío" />
          <InputItem v-model.trim="state.Confpassword" type="password" id="Confpassword" placeholder="Confir Password"
            label="Confirm Password" :error="v$.password.$error" errorMessage="El campo no puede estar vacío" />
          <Button id="btnSubmit" variant="primary" size="lg" class="mt-3 mw-25" type="submit"
            form="form-log">Submit</Button>
        </form>
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
import axios from 'axios';
import { required, email, minLength, maxLength, sameAs } from '@vuelidate/validators';
import { useVuelidate } from '@vuelidate/core';
import { reactive, computed } from 'vue';

export default {
  name: 'Register',
  components: {
    Button,
    PItem,
    InputItem
  },
  setup() {
    const state = reactive({
      user: '',
      confUser: '',
      password: '',
      Confpassword: ''
    })
    const rules = computed(() => {
      return {
        user: { required, email },
        confUser: { required, email, sameAs: sameAs(state.user, "user") },
        password: { required, minLength: minLength(6), maxLength: maxLength(20) },
        Confpassword: { required, minLength: minLength(6), maxLength: maxLength(20), sameAs: sameAs(state.password, "password") }
      }
    })
    const v$ = useVuelidate(rules, state)

    return {
      state,
      v$
    }
  },
  methods: {



    submitForm() {
      //console.log(this.v$);
      this.v$.$validate()
      document.getElementById('btnSubmit').disable = true;
      if (!this.v$.$error && !this.v$.$invalid) {
        axios.post("Client/Register", {
          Email: this.state.user,
          Password: this.state.password
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
      document.getElementById('btnSubmit').disable = false;
    }
  }
};
</script>
  
<style>
.custom-tam {
  width: 35%;
}
</style>
  
  