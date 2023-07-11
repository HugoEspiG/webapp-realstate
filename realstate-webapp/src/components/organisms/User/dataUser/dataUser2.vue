<template>
    <div class="card mb-3 text-center mt-5 mx-auto shadow-lg custom-tam">
        <div>
            <div class="card-body">
                <PItem variant="fs-3" color="dark" class="my-2 card-title">Personal Info</PItem>
                <div class="col" v-for="(value,index) in user.Personal">
                    <div v-if="index != Spouse">
                        <PItem>{{index}}</PItem>
                        <InputItem v-model.trim="phone" :type="text"
                        :id="phone" :placeholder="Phone" :label="value" />
                    </div>
                </div>
            </div>
            
            <div id="SubmitOk" class="alert alert-success alert-dimissible fade show" role="alert" hidden></div>
            <div id="SubmitFail" class="alert alert-danger" role="alert" hidden></div>
        </div>
    </div>
</template>
    
<script>
import { mapGetters } from 'vuex';
import InputItem from '../../../atoms/InputItem/InputItem.vue'
import Button from '../../../atoms/Button/Button.vue'
import PItem from '../../../atoms/PItem/PItem.vue'
import FormItem from '../../../molecules/FormItem/FormItem.vue';
import { required, email, minLength, maxLength } from '@vuelidate/validators';

export default {
    name: 'Register',
    components: {
        Button,
        PItem,
        InputItem,
        FormItem
    },
    computed:{
        ...mapGetters(['user'])
    }
}
</script>

<style>
.custom-tam {
    width: 35%;
}
</style>
    
    