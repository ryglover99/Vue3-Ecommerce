import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import ProductInfoView from '../views/ProductInfoView.vue'
import CategoryView from '../views/CategoryView.vue'
import CheckoutView from '@/views/CheckoutView.vue'
import SignInView from '../views/SignInView.vue'

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
      path: '/sign-in',
      name: 'signin',
      component: SignInView
    }
  ]
})

export default router
