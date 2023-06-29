<template>
    <div class="form-floating mt-3 col-10 mx-auto">
      <date-picker v-model="internalValue" :config="datePickerConfig"></date-picker>
      <label>{{ label }}</label>
      <small v-if="error" class="error-message">{{ errorMessage }}</small>
    </div>
  </template>
  
  <script>
  import { defineComponent } from 'vue';
  // import DatePicker from 'vue-datepicker';
  
  // export default defineComponent({
  //   name: 'DatePickerItem',
  //   components: {
  //     DatePicker
  //   },
  //   props: {
  //     modelValue: {
  //       type: [String, Date],
  //       required: true
  //     },
  //     label: {
  //       type: String,
  //       default: ''
  //     },
  //     error: {
  //       type: Boolean,
  //       default: false
  //     },
  //     errorMessage: {
  //       type: String,
  //       default: ''
  //     },
  //     datePickerConfig: {
  //       type: Object,
  //       default: () => ({}),
  //     },
  //   },
  //   emits: ['update:modelValue'],
  //   data() {
  //     return {
  //       internalValue: this.modelValue
  //     };
  //   },
  //   watch: {
  //     internalValue(newValue) {
  //       this.$emit('update:modelValue', newValue);
  //     },
  //     modelValue(newValue) {
  //       this.internalValue = newValue;
  //     }
  //   }
  // });
  </script>
  
  <style scoped>
  .error-message {
    color: red;
  }
  </style>
  