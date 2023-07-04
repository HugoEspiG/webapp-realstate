<template>
  <div>
    <h1>¡Bienvenido a la página de inicio!</h1>
    <!-- Contenido adicional de la página de inicio -->
    <h3 v-if="user">Hi, {{ user.name }} {{user.rol}}</h3>
    <h3 v-if="!user">You are not logged im! </h3>
  </div>
</template>

<script>
import axios from 'axios'

export default{
  name: "Home",
  props:['user']
  
}
</script>

