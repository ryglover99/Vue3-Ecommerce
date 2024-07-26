import './assets/main.css'
import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { faStar } from '@fortawesome/free-solid-svg-icons'
import { faStarHalfStroke } from '@fortawesome/free-solid-svg-icons'
library.add(faStar)
library.add(faStarHalfStroke)
import { createApp } from 'vue'
import { createPinia } from 'pinia'
import App from './App.vue'
import router from './router'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap'

const pinia = createPinia()
const app = createApp(App)
app.component('font-awesome-icon', FontAwesomeIcon)
app.use(pinia)
app.use(router)
app.mount('#app')
