<template>
        <footer class="d-flex flex-wrap justify-content-between align-items-center p-3 border-top bg-light shadow-lg mt-5">
            <ul class='nav col-md-4 justify-content-start list-unstyled d-flex'>
                <li> <p class='text-primary mx-1'> Email: mail</p></li>
                <li> <p class='text-primary mx-1'> Teléfono: number</p></li>
            </ul>
            <div class='justify-content-center '>
                <ul class='nav border-bottom  mb-3'>
                    <li class='mx-2'><a href='https://www.facebook.com/groups/832391130456275' class='bi bi-facebook btn btn-outline-primary btn-lg border border-0' role="button"></a></li>
                    <li class='mx-2'><a href='https://wa.link/orsxfc' class='bi bi-whatsapp btn btn-outline-primary btn-lg border border-0' role="button"></a></li>
                    <li class='mx-2'><a href='/' class='bi bi-instagram btn btn-outline-primary btn-lg border border-0' role="button"></a></li>
                </ul>
                <p class="mb-3 mb-md-0 text-primary">© 2023 EspacioVital, Inc</p>
            </div>
            <ul class='nav col-md-4 justify-content-end list-unstyled d-flex'>
                <li><RouterLink to='/' class='text-primary'>
                    <img src={logo} alt="Logo" class="d-inline-block align-text-top" />
                </RouterLink></li>
            </ul>
        </footer>
</template>

<script>
    export default {
        name: 'Footer',
        methods: {

        }
    }
</script>

<style scoped>

</style>