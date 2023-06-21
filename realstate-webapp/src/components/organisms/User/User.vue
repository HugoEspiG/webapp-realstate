<template>
    <div>

    </div>
</template>
<script>

import InputItem from '../../atoms/InputItem/InputItem.vue'
import Button from '../../atoms/Button/Button.vue'
import PItem from '../../atoms/PItem/PItem.vue'
import { reactive, computed } from 'vue';
import { RouterLink } from 'vue-router'

export default {
    name: 'User',
    components: {
        Button,
        PItem,
        InputItem
    },
    setup() {
        const state = reactive({
            user: '',
            password: ''
        })
        return {
            state
        }
    },
    methods: {

    }
};
</script>
<style></style>