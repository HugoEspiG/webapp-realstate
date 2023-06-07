<template>
    <label :class="[customClass, 'atom-label']">
      <slot></slot>
    </label>
  </template>
  
  <script>
  export default {
    name: 'Label',
    props: {
      customClass: {
        type: String,
        default: ''
      }
    }
  }
  </script>
  
  <style scoped>
  .atom-label {
    /* Estilos personalizados para el átomo de label */
    font-weight: bold;
    color: #333;
  }
  </style>
  