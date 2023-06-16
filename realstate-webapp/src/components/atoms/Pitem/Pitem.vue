<template>
  <p :class="classes" v-bind="$attrs">
    <slot></slot>
  </p>
</template>

<script>
export default {
  name: 'PItem',
  props: {
    variant: {
      type: String,
      default: ''
    },
    color: {
      type: String,
      default: ''
    },
    className: {
      type: String,
      default: ''
    }
  },
  computed: {
    classes() {
      return [
        this.variant,
        `text-${this.color}`,
        this.className
      ];
    }
  }
};
</script>

<style scoped>
/* Estilos personalizados */
</style>
