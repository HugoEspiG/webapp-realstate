<template>
    <button :class="[customClass, 'btn']">
        <slot></slot>
    </button>
</template>
  
  
<script>
export default {
    name: 'Button',
    props: {
        customClass: {
            type: String,
            default: ''
        }
    }
}
</script>
  
<style scoped>
.button {
    /* Estilos para el botón */
    padding: 10px 20px;
    border: none;
    background-color: #007bff;
    color: #fff;
    cursor: pointer;
}

.button:hover {
    background-color: #0056b3;
}

.button:focus {
    outline: none;
}
</style>
  