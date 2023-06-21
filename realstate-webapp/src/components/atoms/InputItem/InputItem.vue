<template>
  <div class="form-floating mt-3 col-10 mx-auto">
    <input v-model.trim="internalValue" :type="$props.type" :id="$props.id" class="form-control" :placeholder="$props.placeholder" />
    <label :for="$props.id">{{ $props.label }}</label>
    <small v-if="$props.error" class="error-message">{{ $props.errorMessage.$message }}</small>
  </div>
</template>

<script>
export default {
  name: 'InputItem',
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
      type: Object,
      default: {}
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

