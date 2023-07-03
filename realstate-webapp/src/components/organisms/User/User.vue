<template>
    <div class="mt-2">
        <p class="fs-1">Bienvenido {{ $route.params.id }}</p>
        <div class="row">
            <div class="col-md-4">
                <p>Foto</p>
            </div>
            <div class="col-md-8">
                <div>
                    <p class="fs-3 mx-auto">Propiedades mas recientes encontradas para ti</p>
                </div>
                <div class="prueba">
                    <p class="fs-3">Tus datos personales</p>
                    <div class="text-end">
                        Aca ira toda la info
                    </div>
                    <Button @click="edit" variant="primary" size="lg" class="mt-2 text-end">
                        Editar
                    </Button>
                </div>
            </div>
        </div>
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

        })
        return {
            state
        }
    },
    methods: {
        edit(){

        }
    }
};
</script>
<style></style>