<template>
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-8 order-lg-1">
                <PItem variant="fs-4" color="dark" class="m-1 me-5">
                    Encontrar el lugar perfecto para llamar hogar!
                </PItem>
                <PItem variant="fs-5" color="dark" class="mt-2 me-5">
                    Puede ser emocionante y desafiante al mismo tiempo. En nuestra plataforma, nos enorgullece brindarle un enfoque integral y personalizado para ayudarle a adquirir la vivienda ideal, ya sea que esté buscando para comprar o alquilar en Colombia.
                    Nuestro equipo de expertos en bienes raíces está aquí para guiarlo en cada paso del proceso. Desde la búsqueda inicial hasta la firma del Contrato, nos comprometemos a brindarle un servicio excepcional y una experiencia sin complicaciones
                </PItem>
            </div>
            <div class="col-lg-4 order-lg-2 text-center">
                
            </div>
        </div>
    </div>
</template>

<script>
import PItem from '../../atoms/PItem/PItem.vue';

export default {
    name: 'Home',
    components:{
        PItem,
    },
    methods: {

    },
}

</script>

<style scoped></style>