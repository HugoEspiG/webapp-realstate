<template>
    <div class="container justufy-content-center mx-auto">
        <div class="card mt-5 shadow-lg">
            <img src="@/assets/Imagen_Edificio_2.png" alt="Casas" class="card-img img-fluid d-none d-md-block" />
            <img :src="getImageUrl('../../../assets/Imagen_Edificio_1.jpg')" alt="Imagen Pequeña"
                class="card-img img-fluid d-block d-md-none" />
            <div class="card-img-overlay text-center px-5 overflow-auto bg-dark bg-opacity-50">
                <PItem variant="fs-2" class="text-light">
                    Encontrar el lugar perfecto para llamar hogar!
                </PItem>
                <PItem variant="fs-4" class="text-light">
                    Puede ser emocionante y desafiante al mismo tiempo. En nuestra plataforma, nos enorgullece brindarle un
                    enfoque integral y personalizado para ayudarle a adquirir la vivienda ideal, ya sea que esté buscando
                    para comprar o alquilar en Colombia.
                </PItem>
                <PItem variant="fs-4" class="text-light">
                    Nuestro equipo de expertos en bienes raíces está aquí para guiarlo en cada paso del proceso. Desde la
                    búsqueda inicial hasta la firma del Contrato, nos comprometemos a brindarle un servicio excepcional y
                    una experiencia sin complicaciones.
                </PItem>
            </div>
        </div>
        <ItemList :Items="Items"></ItemList>
    </div>
</template>

<script>
import PItem from '../../atoms/PItem/PItem.vue';
import Button from '../../atoms/Button/Button.vue';
import ItemList from '../../molecules/ItemList/ItemList.vue';
import Imagen_Edificio_1 from '../../../assets/Imagen_Edificio_1.jpg'

export default {
    name: 'Home',
    components: {
        PItem,
        Button,
        ItemList
    },
    methods: {
        getImageUrl(name) {
            return new URL(`${name}`, import.meta.url).href
        }
    },
    data() {
        return {
            Items: [
                {
                    cardTam: "",
                    img: "Buy_Home.png",
                    cardTitle: "Buy a Home",
                    cardInfo: "",
                    buttonText: "Register your Preferences",
                    buttonFunc: () => { this.$router.push({ name: 'login' }) }
                },
                {
                    cardTam: "",
                    img: "Sell_Home.png",
                    cardTitle: "Sell a Home",
                    cardInfo: "",
                    buttonText: "Register your Home",
                    buttonFunc: () => { this.$router.push({ name: 'login' }) }
                },
                {
                    cardTam: "",
                    img: "Rent_Home.png",
                    cardTitle: "Rent a Home",
                    cardInfo: "",
                    buttonText: "Register your Preferences",
                    buttonFunc: () => { this.$router.push({ name: 'login' }) }
                }
            ],
        }
    }
}

</script>

<style scoped></style>