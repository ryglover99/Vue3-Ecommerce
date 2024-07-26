<template>
  <div class="nav-wrapper">
    <div class="upper-navbar">
      <div class="upper-navbar-container">
        <div class="logo" @click="pushHome()" style="cursor: pointer">
          <img src="@/assets/img/logo.svg" />
        </div>
        <div class="search">
          <form class="d-flex" role="search">
            <input
              class="form-control me-2"
              type="search"
              placeholder="Search"
              aria-label="Search"
            />
            <button class="btn btn-outline-success" type="submit">Search</button>
          </form>
        </div>
        <div class="basket">
          <button @click="$emit('showBasketEvent')">
            <span :hidden="store.getBasketCount <= 0" class="count">{{
              store.getBasketCount
            }}</span>
            <img src="@/assets/img/icons8-shopping-bag-50.png" />
          </button>
        </div>
      </div>
    </div>
    <nav class="navbar navbar-expand-lg">
      <div class="innerNav-container">
        <div class="container-fluid">
          <button
            class="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span class="navbar-toggler-icon"></span>
          </button>
          <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav me-auto mb-2 mb-lg-0">
              <li class="nav-item">
                <a class="nav-link active" aria-current="page" href="#">Home</a>
              </li>
              <li class="nav-item dropdown">
                <a
                  class="nav-link dropdown-toggle"
                  href="#"
                  role="button"
                  data-bs-toggle="dropdown"
                  aria-expanded="false"
                >
                  Stores
                </a>
                <ul class="dropdown-menu">
                  <li><a class="dropdown-item" href="#">Action</a></li>
                  <li><a class="dropdown-item" href="#">Another action</a></li>
                  <li><hr class="dropdown-divider" /></li>
                  <li><a class="dropdown-item" href="#">Something else here</a></li>
                </ul>
              </li>
              <li class="nav-item dropdown">
                <a
                  class="nav-link dropdown-toggle"
                  href="#"
                  role="button"
                  data-bs-toggle="dropdown"
                  aria-expanded="false"
                >
                  Shop
                </a>
                <ul class="dropdown-menu">
                  <li><a class="dropdown-item" href="#">Action</a></li>
                  <li><a class="dropdown-item" href="#">Another action</a></li>
                  <li><hr class="dropdown-divider" /></li>
                  <li><a class="dropdown-item" href="#">Something else here</a></li>
                </ul>
              </li>
              <li class="nav-item dropdown">
                <a
                  class="nav-link dropdown-toggle"
                  href="#"
                  role="button"
                  data-bs-toggle="dropdown"
                  aria-expanded="false"
                >
                  Mega menu
                </a>
                <ul class="dropdown-menu">
                  <li><a class="dropdown-item" href="#">Action</a></li>
                  <li><a class="dropdown-item" href="#">Another action</a></li>
                  <li><hr class="dropdown-divider" /></li>
                  <li><a class="dropdown-item" href="#">Something else here</a></li>
                </ul>
              </li>
              <li class="nav-item dropdown">
                <a
                  class="nav-link dropdown-toggle"
                  href="#"
                  role="button"
                  data-bs-toggle="dropdown"
                  aria-expanded="false"
                >
                  Pages
                </a>
                <ul class="dropdown-menu">
                  <li><a class="dropdown-item" href="#">Action</a></li>
                  <li><a class="dropdown-item" href="#">Another action</a></li>
                  <li><hr class="dropdown-divider" /></li>
                  <li><a class="dropdown-item" href="#">Something else here</a></li>
                </ul>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </nav>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import { useBasketStore } from '@/store/store'
export default defineComponent({
  setup() {
    const store = useBasketStore()
    return { store }
  },
  emits: {
    showBasketEvent: null
  },
  props: {},
  data() {
    const showBasket: boolean = false
    return {
      showBasket
    }
  },
  methods: {
    pushHome() {
      this.$router.push('/')
    }
  },
  computed: {},
  mounted() {}
})
</script>

<style scoped>
.upper-navbar {
  height: 40%;
  width: 100%;
}

.search {
  display: flex;
  align-items: center;
  width: 100%;
  height: 100%;
  justify-content: start;
  padding-left: 5%;

  form {
    width: 65%;
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
</style>
