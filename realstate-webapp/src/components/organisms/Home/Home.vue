<template>
    <div class="container">
        <div class="card text-bg-dark mt-5">
            <img src="@/assets/Imagen_Edificio_2.png" alt="Casas" class="card-img" />
            <div class="card-img-overlay text-center px-5 overflow-auto bg-dark bg-opacity-50">
                <PItem variant="fs-2" class="">
                    Encontrar el lugar perfecto para llamar hogar!
                </PItem>
                <PItem variant="fs-5" class="">
                    Puede ser emocionante y desafiante al mismo tiempo. En nuestra plataforma, nos enorgullece brindarle un
                    enfoque integral y personalizado para ayudarle a adquirir la vivienda ideal, ya sea que esté buscando
                    para comprar o alquilar en Colombia.
                </PItem>
                <PItem variant="fs-5" class="">
                    Nuestro equipo de expertos en bienes raíces está aquí para guiarlo en cada paso del proceso. Desde la
                    búsqueda inicial hasta la firma del Contrato, nos comprometemos a brindarle un servicio excepcional y
                    una experiencia sin complicaciones
                </PItem>
            </div>
        </div>
        <div class="row my-5">
            <div class="card text-center col-sm m-3">
                <div class="card-body">
                    <img src="@/assets/Buy_Home.png" alt="Casas" class="card-img" />
                    <PItem variant="" class="card-title">Buy a Home</PItem>
                    <Button @click="goToBuy" variant="dark" size="md"
                    class="my-2">
                    register your preferences
                  </Button>
                </div>
            </div>
            <div class="card text-center col-sm m-3">
                <div class="card-body">
                    <img src="@/assets/Sell_Home.png" alt="Casas" class="card-img" />
                    <PItem variant="" class="card-title">Sell a Home</PItem>
                    <Button @click="goToSell" variant="dark" size="md"
                    class="my-2">
                    Register you Home
                  </Button>
                </div>
            </div>
            <div class="card text-center col-sm m-3">
                <div class="card-body">
                    <img src="@/assets/Rent_Home.png" alt="Casas" class="card-img" />
                    <PItem variant="" class="card-title">Rent a Home</PItem>
                    <Button @click="goToRent" variant="dark" size="md"
                    class="my-2">
                    Register yout preferences
                  </Button>
                </div>
            </div>

        </div>
    </div>
</template>

<script>
import PItem from '../../atoms/PItem/PItem.vue';
import Button from '../../atoms/Button/Button.vue';

export default {
    name: 'Home',
    components: {
        PItem,
        Button
    },
    methods: {
        goToSell() {
            this.$router.push({ name: 'register' }); 
        },
        goToBuy() {
            this.$router.push({ name: 'login' }); 
        },
        goToRent() {
            this.$router.push({ name: 'register' }); 
        },

    },
}

</script>

<style scoped></style>