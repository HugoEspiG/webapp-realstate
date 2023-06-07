<template>
    <p :class="[customClass, 'Pitem']">
      <slot></slot>
    </p>
  </template>
  
  <script>
  export default {
    name: 'Pitem',
    props: {
      customClass: {
        type: String,
        default: ''
      }
    }
  }
  </script>
  
  <style scoped>
  .Pitem {
    /* Estilos personalizados para el átomo de párrafo */
    /* font-size: 16px;
    line-height: 1.5;
    margin-bottom: 10px; */
    font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
  }
  </style>
   
  