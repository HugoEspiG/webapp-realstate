<template>
    <button :class="classes" v-bind="$attrs">
      <slot></slot>
    </button>
  </template>
  
  <script>
  export default {
    name: 'Button',
    props: {
      variant: {
        type: String,
        default: 'primary',
        validator: (value) =>
          ['primary', 'secondary', 'success', 'danger', 'warning', 'info', 'light', 'dark', 'custom', 'outline-primary', 'outline-secundary', 'outline-success', 'outline-danger', 'outline-warning', 'outline-info', 'outline-light', 'dark'].includes(value)
      },
      size: {
        type: String,
        default: 'md',
        validator: (value) => ['sm', 'md', 'lg'].includes(value)
      },
      className: {
        type: String,
        default: ''
      }
    },
    computed: {
      classes() {
        return [
          'btn',
          `btn-${this.variant}`,
          `btn-${this.size}`,
          this.className
        ];
      }
    }
  };
  </script>
  
  <style scoped lang="scss">
 
  </style>
  
  