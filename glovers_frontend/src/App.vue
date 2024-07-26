<template>
  <header class="d-flex flex-column h-auto">
    <div
      class="w-100 d-flex align-items-center mb-4 text-secondary"
      style="height: 35px; background-color: rgba(0, 0, 0, 0.16)"
    >
      <div class="container">
        <div class="row">
          <div class="col">
            <span style="padding-left: 20px"
              >We deliver within 3 business days to ensure your products are fresh!</span
            >
          </div>
        </div>
      </div>
    </div>
    <div class="nav-wrap">
      <NavBar @show-basket-event="toggleBasketSlideCallback"></NavBar>
    </div>
  </header>
  <main>
    <section>
      <BasketSlideOut @hide-basket-event="hideBasket" v-if="toggleBasketSlide"></BasketSlideOut>
    </section>
    <div class="container">
      <RouterView :toggleBasketSlideEvent="toggleBasketSlide" />
    </div>
  </main>
  <footer
    class="d-flex w-100 flex-wrap justify-content-between align-items-center py-3 mb-4 border-top"
    style="margin-top: 100px"
  >
    <div class="col-md-4 d-flex align-items-center">
      <a href="/" class="mb-3 me-2 mb-md-0 text-body-secondary text-decoration-none lh-1">
        <svg class="bi" width="30" height="24"><use xlink:href="#bootstrap"></use></svg>
      </a>
      <span class="mb-3 mb-md-0 text-body-secondary">© 2024 Company, Inc</span>
    </div>
    <ul class="nav col-md-4 justify-content-end list-unstyled d-flex"></ul>
  </footer>
</template>

<script lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import NavBar from './components/NavBar.vue'
import BasketSlideOut from './components/BasketSlideOut.vue'
import { defineComponent } from 'vue'

export default defineComponent({
  data() {
    const toggleBasketSlide: boolean = false
    return {
      toggleBasketSlide
    }
  },
  components: {
    NavBar,
    BasketSlideOut
  },
  computed: {},
  methods: {
    toggleBasketSlideCallback() {
      console.log('hit')
      this.toggleBasketSlide = !this.toggleBasketSlide
      console.log(this.toggleBasketSlide)
    },
    hideBasket() {
      this.toggleBasketSlide = false
    }
  },
  watch: {}
})
</script>

<style>
main {
  min-height: 100vh;
  margin-top: 100px;
}
.nav-wrap {
  padding-top: 20px;
  padding-left: 8%;
  padding-right: 12%;
  position: fixed;
  top: 0;
  background-color: white;
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
  display: flex;
  align-items: end;
  width: 100%;
  height: 9rem;
  border-bottom: 1px rgba(146, 146, 146, 0.288) solid;
}

.wrapper {
  display: flex;
  flex-direction: column;
  justify-content: baseline;
  height: auto;
  width: 100%;
}
</style>
