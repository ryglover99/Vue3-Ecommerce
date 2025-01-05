<template>
  <div class="nav-wrapper">
    <div class="upper-navbar">
      <div class="upper-navbar-container">
        <div class="logo" @click="pushHome()" style="cursor: pointer">
          <img src="@/assets/img/green-go-logo.png" />
        </div>
        <SearchBar></SearchBar>
        <div class="btn btn-lg btn-green" @click="pushToSignInOrBackToShop()">
          {{ signInButtonText }}
        </div>
        <div class="basket">
          <button @click="showBasketSlide(true)" class="d-flex align-items-center">
            <span :hidden="store.getBasketCount <= 0" class="count">{{
              store.getBasketCount
            }}</span>
            <div class="d-flex align-items-center text-center justify-content-center">
              <img src="@/assets/img/icons8-shopping-bag-50.png" />
              <p class="px-3 fs-5 m-0 p-0">£{{ store.getSumTotal.toFixed(2) }}</p>
            </div>
          </button>
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
  props: {},
  data() {
    const signInButtonText = 'Sign in'
    const store = useBasketStore()
    return {
      store,
      signInButtonText
    }
  },
  methods: {
    pushHome() {
      this.$router.push('/')
    },
    showBasketSlide(shouldShow: boolean) {
      this.$emitter.emit('show-basket-slide', shouldShow)
    },
    pushToSignInOrBackToShop() {
      if (this.isUserOnSignInPage()) {
        this.$router.push('/')
      } else {
        this.$router.push('/sign-in')
      }
    },
    isUserOnSignInPage() {
      return this.$router.currentRoute.value.name == 'signin'
    },
    generateSignInButtonText() {
      if (this.isUserOnSignInPage()) {
        this.signInButtonText = 'Back to shop'
      } else {
        this.signInButtonText = 'Sign in'
      }
    }
  },
  computed: {},
  watch: {
    async $route() {
      this.generateSignInButtonText()
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
  justify-content: space-between;
}

.basket {
  width: 120px;
  justify-content: center;
  align-items: center;
  right: 100px;
  height: 50px;
  display: flex;
}

.basket img {
  position: relative;
  width: 25px;
  height: 25px;
  z-index: 10;
}

.basket .count {
  top: 13px;
  left: 30px;
  z-index: 11;
  display: flex;
  position: relative;
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
