import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import ProductInfoView from '../views/ProductInfoView.vue'
import CategoryView from '../views/CategoryView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/product/:id',
      name: 'product',
      component: ProductInfoView,
      props: true
    },
    {
      path: '/category/:category',
      name: 'category',
      component: CategoryView,
      props: true
    }
  ]
})

export default router
