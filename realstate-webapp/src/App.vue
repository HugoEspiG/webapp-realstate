<script>
import { RouterLink, RouterView } from 'vue-router'
import Navbar from './components/organisms/Navbar/Navbar.vue';
import { provideUser } from './context/UserContext';

export default {
  name: 'App',
  components: {
    Navbar
  },
  mounted() {
    provideUser(); // Proporciona el contexto del usuario a todos los componentes hijos
  },
};

</script>

<template>
  <header>
    <!-- <nav>
          <RouterLink to="/">Home</RouterLink>
          <RouterLink to="/about">About</RouterLink>
        </nav> -->
    <Navbar />
  </header>

  <RouterView />
</template>

<style scoped></style>
