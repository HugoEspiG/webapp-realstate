import './styles/global.scss'


import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'
import './axios'
import store from './vuex.js'
import 'bootstrap/dist/js/bootstrap.min.js';
import 'bootstrap-icons/font/bootstrap-icons.css';


const app = createApp(App)

app.use(createPinia())
app.use(router)
app.use(store)

app.mount('#app')
