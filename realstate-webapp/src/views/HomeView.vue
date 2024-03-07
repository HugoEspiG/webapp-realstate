<template>
  <div class="container">
    <Home />
  </div>
</template>

<script>
import { mapGetters } from 'vuex'
import Home from '../components/organisms/Home/Home.vue';

export default {
  name: "HomeView",
  components: {
    Home
  },
  computed: {
  }

}
</script>

