<!--<script setup>
import User from '../components/organisms/User/User.vue';
</script>-->

<template>
        <div class="container">
            <p>{{ user }}</p>
        </div>
</template>

<script>
import {mapGetters} from 'vuex'
export default{
    name:"User",
    computed:{
    ...mapGetters(['user'])
  }
}
</script>