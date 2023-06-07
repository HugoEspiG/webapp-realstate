<template>
  <div class="form-floating">
    <input
      :id="name"
      :type="type"
      :name="name"
      class="form-control"
      v-model.trim="v$[model].$model"
      @blur="validateInput"
    />
    <label :for="name" class="floatingInputGrid">{{ label }}</label>
    <div v-if="!v$[model].$pending && v$[model].$error" class="invalid-feedback">
      {{ errors[0] }}
    </div>
  </div>
</template>

<script>
import { useVuelidate } from '@vuelidate/core';

export default {
  name: 'Input',
  props: {
    name: {
      type: String,
      required: true,
    },
    type: {
      type: String,
      default: 'text',
    },
    label: {
      type: String,
      required: true,
    },
    model: {
      type: String,
      required: true,
    },
    validations: {
      type: Object,
      required: true,
    },
  },
  setup(props) {
    const { $v } = useVuelidate(props.validations);
    console.log($v); 

    function validateInput() {
      v$.$touch();
    }

    return {
      v$,
      validateInput,
    };
  },
  computed: {
    errors() {
      const { v$, name } = this;
      if (!v$[name].$dirty) {
        return [];
      }
      return v$[name].$error ? v$[name].$errors : [];
    },
  },
};
</script>

  
<style scoped>
.is-invalid {
  border-color: red;
}

.invalid-feedback {
  color: red;
}
</style>
  