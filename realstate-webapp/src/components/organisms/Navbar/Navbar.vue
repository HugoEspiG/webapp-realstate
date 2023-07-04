<template>
                <nav class="navbar navbar-expand-lg navbar-dark bg-primary shadow-lg rounded-bottom">
                <div class="container-fluid">
                    <RouterLink to='/' class="navbar-brand" >Home</RouterLink>
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarText">
                        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                            <li class="nav-item">
                                <RouterLink to="/" :class="[$route.path === '/' ? 'nav-link active' : 'nav-link']">Follow</RouterLink>
                            </li>
                            <li class="nav-item">
                                <RouterLink to="/about" :class="[$route.path === '/about' ? 'nav-link active' : 'nav-link']">About</RouterLink>
                            </li>
                        </ul>
                        <span class="nav-item dropdown" v-if="!user">
                            <span class="nav-link dropdown-toggle bi bi-person-circle text-white" role="button" data-bs-toggle="dropdown" aria-expanded="false"> </span>
                            <ul class="dropdown-menu dropdown-menu-end">
                                <li><RouterLink to="/login" class="dropdown-item">Login</RouterLink></li>
                                <li><RouterLink to="/register" class="dropdown-item">Sign up</RouterLink></li>
                                <li><hr class="dropdown-divider" /></li>
                            </ul>
                        </span>
                        <span class="nav-item dropdown" v-if="user">
                            <span class="nav-link dropdown-toggle bi bi-person-circle text-white" role="button" data-bs-toggle="dropdown" aria-expanded="false"> </span>
                            <ul class="dropdown-menu dropdown-menu-end">
                                <li><a href="javascript:void(0)" @click="handleClick" class="dropdown-item">Logout</a></li>
                                <li><hr class="dropdown-divider" /></li>
                            </ul>
                        </span>
                        
                    </div>
                </div>
            </nav>
</template>
  
  
<script>
export default {
    name: 'NavBar',
    props:['user'],
    methods:{
        handleClick(){
            sessionStorage.removeItem('rs-device');
            this.$route.push('/');
        }
    }
}
</script>
  
<style scoped></style>
  