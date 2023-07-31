<template>
    <div class="form-floating mt-3">
      <select v-model="internalValue" :id="id" class="form-select">
        <option v-for="option in options" :value="option.value" :key="option.value">{{ option.label }}</option>
      </select>
      <label :for="id">{{ label }}</label>
      <small v-if="error" class="error-message">{{ errorMessage }}</small>
    </div>
  </template>
  
  <script>
  export default {
    name: 'SelectItem',
    props: {
      modelValue: {
        type: [String, Number],
        required: true
      },
      id: {
        type: String,
        required: true
      },
      options: {
        type: Array,
        required: true
      },
      label: {
        type: String,
        default: ''
      },
      error: {
        type: Boolean,
        default: false
      },
      errorMessage: {
        type: String,
        default: ''
      }
    },
    data() {
      return {
        internalValue: this.modelValue
      };
    },
    watch: {
      internalValue(newValue) {
        this.$emit('update:modelValue', newValue);
      },
      modelValue(newValue) {
        this.internalValue = newValue;
      }
    }
  };
  </script>
  
  <style scoped>
  .error-message {
    color: red;
  }
  </style>
  