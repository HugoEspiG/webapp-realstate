<template>
    <div class="card mb-3 text-center mt-5 mx-auto shadow-lg custom-tam">
        <div class="card-body">
            <PItem variant="fs-3" color="dark" class="my-2 card-title">Log in</PItem>
            <div class="col">
                <form @submit.prevent="submitForm" id="form-log" class="mt-5 col mx-4">
                    <InputItem v-model.trim="state.user" type="text" id="user" placeholder="Username" label="Username"
                        :error="v$.user.$error" :errorMessage="getErrorMessage('user')" />
                    <InputItem v-model.trim="state.password" type="password" id="password" placeholder="Password"
                        label="Password" :error="v$.password.$error" :errorMessage="getErrorMessage('password')" />
                </form>
                <Button variant="primary" size="lg" class="mt-3 mw-25" type="submit" form="form-log">Save</Button>
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

    }
};
</script>
<style></style>