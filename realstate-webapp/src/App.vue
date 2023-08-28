<template>
  <header>
    <Navbar />
  </header>
  <RouterView/>
  <Footer/>
</template>

<script >
import { RouterLink, RouterView } from 'vue-router'
import Navbar from './components/organisms/Navbar/Navbar.vue';
import Footer from './components/organisms/Footer/Footer.vue';
import axios from 'axios'
export default{
  name:'App',
  components:{
    Navbar,
    Footer
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
        limit: "All"
      }
    });
    this.$store.dispatch('user', response.data);
    }
  }
}
</script>
<style scoped></style>
