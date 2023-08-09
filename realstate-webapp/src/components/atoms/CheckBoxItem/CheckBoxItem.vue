<template>
    <div class="form-check">
      <input v-model.trim="internalValue" :type="$props.type" :id="$props.id" value="" class="form-check-input" />
      <label :for="$props.id" class="form-check-label">{{ $props.label }}</label>
      <small v-if="$props.error" class="error-message">{{ $props.errorMessage}}</small>
    </div>
  </template>
  
  <script>
  export default {
    name: 'CheckBoxItem',
    props: {
      modelValue: {
        type: [String, Number],
        required: true
      },
      type: {
        type: String,
        default: 'text'
      },
      id: {
        type: String,
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
  
  