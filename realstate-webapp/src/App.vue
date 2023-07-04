<<<<<<< HEAD
<template>
  <header>
    <!-- <nav>
          <RouterLink to="/">Home</RouterLink>
          <RouterLink to="/about">About</RouterLink>
        </nav> -->
    <Navbar :user="user" />
=======
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
>>>>>>> db7020d4705887115d6f29a37b388392bd4375b7
  </header>

  <RouterView :user="user" />
</template>

<script >
import { RouterLink, RouterView } from 'vue-router'
import Navbar from './components/organisms/Navbar/Navbar.vue';
import axios from 'axios'
export default{
  name:'App',
  components:{
    Navbar,
  },
  data(){
    return {
      user:null
    }
  },
  async created(){
    var pid = null;
    if (JSON.parse(sessionStorage.getItem('rs-device'))!=null){
      pid = JSON.parse(sessionStorage.getItem('rs-device')).pid
    
    const response = await axios.get(`Client/User`,{
      params:{
        request: pid,
        limit: "Simple"
      }
    });

    this.user = response.data;
    }
  }
}
</script>
<style scoped></style>
