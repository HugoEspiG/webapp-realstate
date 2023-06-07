<template>
  <form @submit.prevent="login">
    <div class="mb-3">
      <Input
        name="username"
        type="text"
        label="Nombre de usuario"
        :model="loginForm.username"
        :validations="usernameValidations"
      />
    </div>
    <div class="mb-3">
      <Input
        name="password"
        type="password"
        label="Contraseña"
        :model="loginForm.password"
        :validations="passwordValidations"
      />
    </div>
    <button type="submit" class="btn btn-primary">Iniciar sesión</button>
  </form>
</template>

<script>
import Input from '../../atoms/Input/Input.vue';
import { required, minLength, maxLength } from '@vuelidate/validators';

export default {
  name: 'Login',
  components: {
    Input,
  },
  data() {
    return {
      loginForm: {
        username: '',
        password: '',
      },
      usernameValidations: {
        required: value => !!value || 'El nombre de usuario es requerido',
        minLength: minLength(4, 'El nombre de usuario debe tener al menos 4 caracteres'),
        maxLength: maxLength(10, 'El nombre de usuario no puede tener más de 10 caracteres'),
      },
      passwordValidations: {
        required: true,
        minLength: 6,
      },
    };
  },
  methods: {
    login() {
      // Lógica para realizar la autenticación
      // Puedes acceder a los valores de entrada en this.loginForm.username y this.loginForm.password
    },
  },
};
</script>
