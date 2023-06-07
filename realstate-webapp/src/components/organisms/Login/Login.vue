<template>
  <form @submit.prevent="submitForm" class='flex-row'>
    <div class="form-floating m-3 col-md-4 text-center">
      <input v-model.trim="state.user" type="text" id="user" class="form-control" placeholder="Username"/>
      <small v-if="v$.user.$error" class="error-message">
        {{ v$.user.$errors[0].$message }}
      </small>
      <label for="user">Username</label>
    </div>
    <div class="form-floating m-3 col-md-4">
      <input v-model.trim="state.password" type="password" id="password" class="form-control" placeholder="Password"/>
      <small v-if="v$.password.$error" class="error-message">
        {{ v$.password.$errors[0].$message }}
      </small>
      <label for="password">Password</label>
    </div>

    <button type="submit" class="btn btn-primary center">Submit</button>
  </form>
</template>

<script>
import { required, email, minLength, maxLength } from '@vuelidate/validators';
import { useVuelidate } from '@vuelidate/core';
import { reactive, computed } from 'vue';

export default {
  name: 'Login',
  setup() {
    const state = reactive({
      user: '',
      password: ''
    })
    const rules = computed(() => {
      return {
        user: { required, email },
        password: { required, minLength: minLength(6), maxLength: maxLength(20) }
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
        alert("Incompletto")
      }
      console.log('Username:', this.state.user);
      console.log('Password:', this.state.password);
    }
  }
};
</script>

<style>
.error-message {
  color: red;
}
</style>
