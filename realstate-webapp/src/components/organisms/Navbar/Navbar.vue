<template>
    <nav class="navbar navbar-expand-lg bg-light shadow-lg rounded-bottom">
        <div class="container-fluid">
            <RouterLink to='/' class="navbar-brand">Home</RouterLink>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
                aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarText">
                <ul class="navbar-nav ms-auto mb-2 mb-lg-0">
                    <li class="nav-item">
                        <RouterLink to="/" :class="[$route.path === '/' ? 'nav-link active' : 'nav-link']">Follow
                        </RouterLink>
                    </li>
                    <li class="nav-item">
                        <RouterLink to="/about" :class="[$route.path === '/about' ? 'nav-link active' : 'nav-link']">About
                        </RouterLink>
                    </li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle bi bi-person-circle" role="button"
                            data-bs-toggle="dropdown" aria-expanded="false"> </a>
                        <ul class="dropdown-menu dropdown-menu dropdown-menu-end">
                            <li>
                                <RouterLink to="/login" class="dropdown-item">Login</RouterLink>
                            </li>
                            <li>
                                <RouterLink to="/register" class="dropdown-item">Sign up</RouterLink>
                            </li>
                            <li>
                                <hr class="dropdown-divider" />
                            </li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</template>
  
  
<script>
export default {
    name: 'NavBar'
}
</script>
  
<style scoped></style>
  