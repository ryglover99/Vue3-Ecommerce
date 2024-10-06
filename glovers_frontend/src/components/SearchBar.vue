<template>
  <div class="search">
    <form id="searchForm" class="d-flex" role="search">
      <input
        v-model="searchTerm"
        class="form-control me-2"
        type="search"
        placeholder="Search products"
        aria-label="Search"
      />
    </form>
    <div
      class="search-results"
      :class="{
        'search-results-active': findProductsBasedOnTerm && findProductsBasedOnTerm.length > 0
      }"
    >
      <ul>
        <li
          v-for="product in findProductsBasedOnTerm"
          :key="product.id"
          @click="goToProductPage(product.id)"
        >
          {{ product.title }}
          <small class="text-muted fst-italic">{{ product.description }}</small>
        </li>
      </ul>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import { useBasketStore } from '@/store/BasketStore'
import { useSharedStore } from '@/store/SharedStore'

export default defineComponent({
  setup() {
    const store = useBasketStore()
    const sharedStore = useSharedStore()
    return { store, sharedStore }
  },
  emits: {
    showBasketEvent: null
  },
  props: {},
  data() {
    const searchTerm: string = ''
    const showBasket: boolean = false
    return {
      searchTerm,
      showBasket
    }
  },
  methods: {
    goToProductPage(id: number) {
      this.searchTerm = ''
      this.$router.push(`/product/${id}`)
    }
  },
  computed: {
    findProductsBasedOnTerm() {
      if (!this.searchTerm) return

      return this.sharedStore.products.filter((p) => {
        return p.title.toLowerCase().includes(this.searchTerm.toLowerCase())
      })
    }
  },
  mounted() {}
})
</script>

<style scoped>
.upper-navbar {
  height: 40%;
  width: 100%;
}

.search {
  flex: 1;
  position: relative;
  max-width: 900px;
  display: flex;
  align-items: center;
  height: 100%;
  justify-content: start;
  padding-left: 5%;

  form {
    width: 100%;
  }
}

.upper-navbar-container {
  width: 100%;
  height: 100%;
  margin: auto;
  display: flex;
  align-items: center;
}

.basket {
  position: relative;
}

.basket img {
  width: 25px;
  height: 25px;
  z-index: 10;
}

.basket .count {
  top: 20px;
  left: 70%;
  z-index: 11;
  display: flex;
  position: absolute;
  justify-content: center;
  align-items: center;
  font-size: 12px;
  border-radius: 50%;
  background-color: red;
  font-weight: bold;
  color: white;
  width: 15px;
  height: 15px;
}

.logo {
  width: 20%;
  height: 100%;
  padding: 0px 15px 0px 20px;
  display: flex;
  justify-content: start;
  align-items: center;

  img {
    width: 190px;
  }
}

.upper-nav {
  display: flex;
  justify-content: center;
}
.innerNav-container {
  width: 100%;
  margin: auto;
  display: flex;
}
#navbarSupportedContent {
  justify-content: space-around;
}

.form-inline {
  display: flex;
}

.nav-item {
  margin-right: 10%;
}

.nav-item:last-child {
  margin-right: 0;
}

.search-bar {
  width: 100%;
  padding: 10px;
  font-size: 16px;
}

#searchForm {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 10px;
}

.form-control {
  width: calc(100% - 120px); /* Adjust this value based on the button width */
  padding: 10px;
  font-size: 16px;
}

.btn {
  width: 100px;
  padding: 10px;
}

.search-results {
  position: absolute;
  top: 100%; /* Positioned right below the input */
  left: 0;
  width: 100%;
  background-color: #fff;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  max-height: 300px; /* Scroll if too many results */
  overflow-y: auto;
  visibility: hidden;
  opacity: 0;
  transform: translateY(-20px);
  transition:
    transform 0.3s ease,
    opacity 0.3s ease,
    visibility 0.3s;
  z-index: 1000;
}

.search .search-results ul {
  list-style-type: none;
  padding: 0;
  margin: 0;
}

.search .search-results li {
  padding: 10px;
  border-bottom: 1px solid #eee;
  cursor: pointer;
}

.search .search-results li:hover {
  background-color: #f9f9f9;
}

/* Show results when the search term has value */
.search-results-active {
  visibility: visible;
  opacity: 1;
  transform: translateY(0);
}
</style>
