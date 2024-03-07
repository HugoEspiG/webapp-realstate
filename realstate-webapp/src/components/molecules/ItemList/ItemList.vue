<template>
    <div class="row my-5">
        <div v-for="(item, index) in Items" :key="index" class="col-md-4 p-2">
            <Item 
            :cardTam="item.cardTam"
            :img="item.img"
            :cardTitle="item.cardTitle"
            :cardInfo="item.cardInfo"
            :buttonText="item.buttonText"
            :buttonFunc="item.buttonFunc"></Item>
        </div>
    </div>
</template>

<script>
import Item from '../../atoms/Item/Item.vue';

export default {
    setup() {


        return {}
    },
    name: 'ItemList',
    components: {
    Item
},
    props:{
        Items:{
            type: Array,
            required: true
        }
    }
}
</script>

<style lang="scss" scoped></style>