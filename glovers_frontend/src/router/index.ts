import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import ProductInfoView from '../views/ProductInfoView.vue'
import CategoryView from '../views/CategoryView.vue'
import CheckoutView from '@/views/CheckoutView.vue'
import OrderConfirmationView from '@/views/OrderConfirmationView.vue'

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
    },
    {
      path: '/checkout',
      name: 'checkout',
      component: CheckoutView,
      props: true
    },
    {
      path: '/order-confirmation',
      name: 'orderConfirmation',
      component: OrderConfirmationView,
      props: true
    }
  ]
})

export default router
