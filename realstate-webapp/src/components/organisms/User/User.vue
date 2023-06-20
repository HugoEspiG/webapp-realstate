<template>
    <div>

    </div>
</template>
<script>

import InputItem from '../../atoms/InputItem/InputItem.vue'
import Button from '../../atoms/Button/Button.vue'
import PItem from '../../atoms/PItem/PItem.vue'
import { required, email, minLength, maxLength } from '@vuelidate/validators';
import { useVuelidate } from '@vuelidate/core';
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
        const rules = computed(() => {
            return {
                user: { required, email },
                password: { required, minLength: minLength(6), maxLength: maxLength(20) }
            }
        })
        const v$ = useVuelidate(rules, state)

        return {
            state,
            v$
        }
    },
    methods: {
        submitForm() {
            this.v$.$validate()
            if (!this.v$.$error) {
                alert("Completo")
            } else {
                alert("Incompleto")
            }
            console.log('Username:', this.state.user);
            console.log('Password:', this.state.password);
        }
    }
};
</script>
<style></style>