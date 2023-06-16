<template>
    <div class="card mb-3 text-center mt-5 mx-auto shadow-lg custom-tam">
      <div class="card-body">
        <PItem variant="fs-3" color="dark" class="my-2 card-title">Sign up</PItem>
        <div class="col">
          <form @submit.prevent="submitForm" id="form-log" class="mt-5 col mx-4">
            <InputItem v-model.trim="state.user" type="text" id="user" placeholder="mail" label="mail"
              :error="v$.user.$error" errorMessage="El campo no puede estar vacío" />
            <InputItem v-model.trim="state.confUser" type="text" id="confUser" placeholder="Confirm mail" label="Confirm mail"
              :error="v$.user.$error" errorMessage="El campo no puede estar vacío" />
            <InputItem v-model.trim="state.password" type="password" id="password" placeholder="Password" label="Password"
              :error="v$.password.$error" errorMessage="El campo no puede estar vacío" />
            <InputItem v-model.trim="state.Confpassword" type="password" id="Confpassword" placeholder="Confir Password" label="Confirm Password"
              :error="v$.password.$error" errorMessage="El campo no puede estar vacío" />
            <Button variant="primary" size="lg" class="mt-3 mw-25" type="submit" form="form-log">Submit</Button>
          </form>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  import InputItem from '../../atoms/InputItem/InputItem.vue'
  import Button from '../../atoms/Button/Button.vue'
  import PItem from '../../atoms/PItem/PItem.vue'
  import { required, email, minLength, maxLength } from '@vuelidate/validators';
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
          confUser: { required, email },
          password: { required, minLength: minLength(6), maxLength: maxLength(20) },
          Confpassword: { required, minLength: minLength(6), maxLength: maxLength(20) }
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
        this.v$.$validate()
        if (!this.v$.$error) {
          alert("Completo")
        } else {
          alert("Incompleto")
        }
        console.log(this.state);;
      }
    }
  };
  </script>
  
  <style>
  .custom-tam {
    width: 35%;
  }
  </style>
  
  