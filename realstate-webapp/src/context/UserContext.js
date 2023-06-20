import { reactive, provide, inject } from 'vue';

const user = reactive({
    user: '',
    password:'',
    questions:[]
});

function setUser(userData) {
    user=userData
}

// Función para restablecer los datos del usuario
function resetUser() {
    user.username = '';
    user.email = '';
    user.questions='';
}

// Exporta la función de configuración del proveedor del contexto del usuario
export function provideUser() {
    provide('user', {
        user,
        setUser,
        resetUser,
    });
}

// Exporta la función de inyección para acceder al contexto del usuario en componentes secundarios
export function useUser() {
    const context = inject('user');
    if (!context) {
        throw new Error('No se pudo encontrar el contexto del usuario');
    }
    return context;
}
