<template>
  <div class="form-floating mt-3">
    <input v-model.trim="internalValue" :type="$props.type" :id="$props.id" class="form-control" :placeholder="$props.placeholder" min="1900-01-01" max="2005-12-31"/>
    <small v-if="$props.error" class="error-message">{{ $props.errorMessage}}</small>
  </div>
</template>

<script>
export default {
  name: 'DatePickerItem',
  props: {
    modelValue: {
      type: [String, Number],
      required: true
    },
    type: {
      type: String,
      default: 'date'
    },
    id: {
      type: String,
      required: true
    },
    placeholder: {
      type: String,
      default: ''
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