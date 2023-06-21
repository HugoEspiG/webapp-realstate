<script>
import { RouterView } from 'vue-router'
import Navbar from './components/organisms/Navbar/Navbar.vue';

export default {
  name: 'App',
  components: {
    Navbar
  }
};

</script>

<template>
  <header>
    <Navbar />
  </header>

  <RouterView />
</template>

<style scoped></style>
