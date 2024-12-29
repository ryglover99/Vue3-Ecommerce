<template>
  <div class="nav-wrapper">
    <div class="upper-navbar">
      <div class="upper-navbar-container">
        <div class="logo" @click="pushHome()" style="cursor: pointer">
          <img src="@/assets/img/green-go-logo.png" />
        </div>
        <SearchBar></SearchBar>
        <div class="basket">
          <button @click="$emit('showBasketEvent')">
            <span :hidden="store.getBasketCount <= 0" class="count">{{
              store.getBasketCount
            }}</span>
            <img src="@/assets/img/icons8-shopping-bag-50.png" />
          </button>
          <div
            class="alert-wrap position-absolute px-2 pb-1 pt-1 bg-danger text-center d-flex align-items-center justify-content-center"
            style="width: fit-content; left: 50%; transform: translateX(-50%); border-radius: 10px"
          >
            <p class="w-100 p-0 m-0" style="text-wrap: nowrap">{{ alertMessage }}</p>
          </div>
        </div>
      </div>
    </div>
    <nav class="navbar navbar-expand-lg">
      <div class="innerNav-container">
        <div class="container-fluid p-0">
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
        </div>
      </div>
    </nav>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import { useBasketStore } from '@/store/BasketStore'
import SearchBar from '@/components/SearchBar.vue'

export default defineComponent({
  components: {
    SearchBar
  },
  emits: {
    showBasketEvent: null
  },
  props: {},
  data() {
    var alertMessage: string = 'TEST MESSAGE'
    const store = useBasketStore()
    const showBasket: boolean = false
    return {
      alertMessage,
      showBasket,
      store
    }
  },
  methods: {
    pushHome() {
      this.$router.push('/')
    }
  },
  computed: {},
  watch: {
    alertMessage() {
      return this.alertMessage
    }
  },
  mounted() {
    this.$emitter.on('display-alert', (message: any) => {
      this.alertMessage = message
      setTimeout(() => {
        this.alertMessage = ''
      }, 3000)
    })
  }
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
  position: absolute;
  right: 100px;
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
  display: flex;
  justify-content: start;
  align-items: center;

  img {
    width: 140px;
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
@/store/BasketStore
