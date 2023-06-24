  <template>
    <div class="card mb-3 text-center mt-5 mx-auto shadow-lg custom-tam">
      <div class="card-body">
        <PItem variant="fs-3" color="dark" class="my-2 card-title">Log in</PItem>
        <div class="col">
          <form @submit.prevent="submitForm" id="form-log" class="mt-5 col mx-4">
            <InputItem v-model.trim="state.user" type="text" id="user" placeholder="Username" label="Username"
              :error="v$.user.$error" :errorMessage="v$.$errors==undefined?'':v$.$errors[0]" />
            <InputItem v-model.trim="state.password" type="password" id="password" placeholder="Password" label="Password"
              :error="v$.password.$error" :errorMessage="v$.$errors==undefined?'':v$.$errors[v$.$errors.length-1]" />
          </form>
          <Button variant="primary" size="lg" class="mt-3 mw-25" type="submit" form="form-log">Submit</Button>
          <PItem variant="fs-5" color="dark" className="my-2">
            ¿Aún no estás registrado? <RouterLink to="/register"> Registrate</RouterLink>
          </PItem>
          <div className="divider"> OR</div>
          <Button variant="outline-primary" size="lg" className="bi bi-google mt-3 mw-25" type="submit" form="form-log"> Log
            in con Google</Button>
        </div>
      </div>
    </div>
  </template>

<script>
import InputItem from '../../atoms/InputItem/InputItem.vue'
import Button from '../../atoms/Button/Button.vue'
import PItem from '../../atoms/PItem/PItem.vue'
import axios from 'axios';
import { required, email, minLength, maxLength } from '@vuelidate/validators';
import { useVuelidate } from '@vuelidate/core';
import { reactive, computed } from 'vue';
import { RouterLink } from 'vue-router';

  export default {
    name: 'Login',
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
      if (!this.v$.$error && !this.v$.$invalid) {;
        axios.post(variables.MONGOAPI + "Client/Login", {
          Email: this.state.user,
          Password: this.state.password
        }).then((response) => {
          console.log(response.data);
          //window.localStorage.setItem("token",response.data);
        }).catch(e=> console.log(e.response));
      } else {
      }
}
    }
  };
  </script>

  <style>
  .custom-tam {
    width: 35%;
  }
  </style>

