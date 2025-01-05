<template>
  <header class="d-flex flex-column">
    <div
      class="w-100 d-flex align-items-center mb-4 text-secondary"
      style="height: 35px; background-color: rgba(0, 0, 0, 0.16)"
    >
      <div class="container">
        <div class="row">
          <div class="col">
            <span>We deliver within 3 business days to ensure your products are fresh!</span>
          </div>
        </div>
      </div>
    </div>
    <div class="nav-wrap">
      <NavBar></NavBar>
    </div>
  </header>
  <main>
    <BasketSlideOut></BasketSlideOut>
    <div class="container">
      <RouterView />
    </div>
  </main>
  <footer class="d-flex w-100 flex-wrap justify-content-between align-items-center py-4">
    <div class="col-md-4 d-flex align-items-center">
      <a href="/" class="mb-3 me-2 mb-md-0 text-body-secondary text-decoration-none lh-1">
        <svg class="bi" width="30" height="24"><use xlink:href="#bootstrap"></use></svg>
      </a>
      <span class="mb-3 mb-md-0 text-body-secondary">© 2024 Green Go, Inc</span>
    </div>
    <ul class="nav col-md-4 justify-content-end list-unstyled d-flex"></ul>
    <div class="logo" style="cursor: pointer">
      <img src="@/assets/img/green-go-logo.png" width="100" class="mx-4" />
    </div>
  </footer>
</template>

<script lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import NavBar from './components/NavBar.vue'
import BasketSlideOut from './components/BasketSlideOut.vue'
import { defineComponent } from 'vue'
import ProductsService from './services/ProductsService'
import { useSharedStore } from '@/store/SharedStore'
import HelperMethods from './Helpers/HelperMethods'

const productsService = new ProductsService()
const helper = new HelperMethods()

export default defineComponent({
  data() {
    var sharedStore = useSharedStore()
    const toggleBasketSlide: boolean = false
    return {
      toggleBasketSlide,
      sharedStore
    }
  },
  components: {
    NavBar,
    BasketSlideOut
  },
  computed: {},
  watch: {
    async $route() {
      this.hideBasket()
      helper.scrollToTop()
    }
  },
  methods: {
    hideBasket() {
      this.$emitter.emit('show-basket-slide', false)
    },
    async populateProductsInStore() {
      let prods = await productsService.getAllProducts()
      this.sharedStore.populateProductList(prods)
    },
    async initialize() {
      await Promise.all([this.populateProductsInStore()])
    }
  },
  async mounted() {
    await this.initialize()
  }
})
</script>

<style>
body {
  height: 100%;
  background-color: white !important;
}

section {
  padding-bottom: 100px;
}

main {
  min-height: 100vh;
}

.nav-wrap {
  padding-left: 5%;
  padding-right: 5%;
  top: 0;
  width: 100%;
  z-index: 999;
}
button,
input[type='submit'],
input[type='reset'] {
  background: none;
  color: inherit;
  border: none;
  padding: 0;
  font: inherit;
  cursor: pointer;
  outline: inherit;
}

header {
  background-color: white;
  position: sticky;
  top: 0;
  z-index: 9999;
  display: flex;
  align-items: end;
  width: 100%;
  border-bottom: 2px rgba(209, 209, 208, 0.541) solid;
}

footer {
  bottom: 0;
  background-color: white;
  border-top: 2px rgba(209, 209, 208, 0.541) solid;
}

.wrapper {
  display: flex;
  flex-direction: column;
  justify-content: baseline;
  height: auto;
  width: 100%;
}
</style>
