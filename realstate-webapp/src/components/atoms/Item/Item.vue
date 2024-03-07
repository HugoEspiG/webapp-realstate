<template>
    <div :class="cardClass">
        <div class="card-body">
            <img :src="getImageUrl(img)" alt="Casas" class="card-img" />
            <PItem variant="" class="card-title">{{cardTitle}}</PItem>
            <Button @click="buttonFunc" variant="dark" size="md" class="my-2">
                {{ buttonText }}
            </Button>
        </div>
    </div>
</template>

<script>
import Button from '../../atoms/Button/Button.vue';
import PItem from '../../atoms/PItem/PItem.vue';

export default {
    setup(props) {

        return {}
    },
    name: 'Item',
    components: {
        Button,
        PItem
    },
    props: {
        cardTam:{
            type: String
        },
        img:{
            type: String
        },
        cardTitle:{
            type: String
        },
        cardInfo:{
            type: String
        },
        buttonText:{
            type: String
        },
        buttonFunc:{
            type: Function
        }
    },
    data(){
        return{
            cardClass: `card text-center m-4 shadow-lg ${this.cardTam}`
        }
    },methods:{
        getImageUrl(name) {
            return new URL(`../../../assets/${name}`, import.meta.url).href
        }
    }
}
</script>

<style lang="scss" scoped></style>