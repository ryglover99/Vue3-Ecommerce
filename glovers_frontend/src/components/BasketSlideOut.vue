<template class="parent">
  <div class="container d-flex flex-column shadow-lg">
    <div class="row mb-4">
      <div class="col d-flex justify-content-start">
        <h2>My Cart</h2>
      </div>
      <div class="col d-flex justify-content-end">
        <button @click="$emit('hideBasketEvent')">
          <img src="@/assets/img/icons8-x-50.png" />
        </button>
      </div>
    </div>
    <div class="alerting row border-bottom border-light mb-5">
      <div class="col h-100 alert alert-success rounded" role="alert">
        <p class="d-flex align-items-center h-100 m-0">
          You've got FREE delivery. Start checkout now!
        </p>
      </div>
    </div>
    <p :hidden="store.getBasketCount > 0" class="text-secondary text-center">
      It looks like your cart is empty!
    </p>
    <div class="productsWrap">
      <ol class="list-group">
        <li
          v-for="product in getAllBasketProducts()"
          :key="product.product.id"
          class="list-group-item d-flex justify-content-between align-items-start"
        >
          <img :src="'/src/assets/img/' + product.product.image" width="50" height="50" />
          <div class="ms-2 me-auto">
            <div class="fw-bold">{{ product.product.title }}</div>
            <div class="col-12">{{ product.product.description }}</div>
            <div class="col-12">£{{ product.product.price }}</div>
          </div>
          <span class="badge text-bg-dark rounded-pill"> x {{ product.quantity }}</span>
        </li>
      </ol>
    </div>
    <hr :hidden="store.getBasketCount <= 0" />
    <span :hidden="store.getBasketCount <= 0" class="text-end fs-5">Total: £{{ sumTotal() }}</span>
    <div class="row mt-auto d-flex">
      <div class="col-12 d-flex justify-content-end">
        <div :hidden="store.getBasketCount <= 0" @click="pushToCheckout()" class="btn btn-success">
          Go to checkout
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, type PropType } from 'vue'
import type IProduct from '@/interfaces/IProduct'
import { useBasketStore } from '@/store/BasketStore'

export default defineComponent({
  setup() {
    const store = useBasketStore()
    return { store }
  },
  emits: {
    hideBasketEvent: null
  },
  props: {
    listOfProducts: Array as PropType<IProduct[]>
  },
  data() {
    return {}
  },
  methods: {
    getAllBasketProducts() {
      return this.store.getProducts
    },
    pushToCheckout() {
      this.$router.push('/checkout')
    },
    sumTotal() {
      return this.store.getSumTotal
    }
  },
  computed: {},
  mounted() {}
})
</script>

<style scoped>
.parent {
  transition: display 5s;
}

.productsWrap {
  overflow-y: scroll;
  max-height: 310px;
  min-height: 310px;
}

hr {
  margin-top: 3rem;
  margin-bottom: 1rem;
  border: 0;
  border-top: 2px solid rgba(0, 0, 0, 0.5);
}

.container {
  z-index: 9999;
  padding: 2rem;
  height: 100%;
  width: 35vw;
  position: fixed;
  right: 0;
  top: 0;
  margin: 0;
  background-color: white;
}

.alerting {
  height: 50px;
}
</style>
