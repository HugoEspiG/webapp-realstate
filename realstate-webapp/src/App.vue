<script setup>
import { RouterLink, RouterView } from 'vue-router'
import Navbar from './components/organisms/Navbar/Navbar.vue';
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
