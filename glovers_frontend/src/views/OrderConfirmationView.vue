<template>
  <section class="h-100 gradient-custom">
    <div class="container py-5 h-100">
      <div class="row d-flex justify-content-center align-items-center h-100">
        <div class="col-lg-10 col-xl-8">
          <div class="card" style="border-radius: 10px">
            <div class="card-header px-4 py-5">
              <h5 class="text-muted mb-0">You have successfully placed your order!</h5>
            </div>
            <div class="card-body p-4">
              <div class="d-flex justify-content-between align-items-center mb-4">
                <p class="lead fw-normal mb-0 text-success">Receipt</p>
                <p class="small text-muted mb-0">Receipt Voucher : 1KAU9-84UIL</p>
              </div>

              <div
                class="card shadow-0 border mb-4"
                v-for="product in getAllProducts()"
                :key="product.product.id"
              >
                <div class="card-body">
                  <div class="row">
                    <div class="col-md-2">
                      <img
                        :src="'/src/assets/img/' + product.product.image"
                        class="img-fluid"
                        alt="{{product.product.title}}"
                      />
                    </div>
                    <div
                      class="col-md-2 text-center d-flex justify-content-center align-items-center"
                    >
                      <p class="text-muted mb-0">{{ product.product.title }}</p>
                    </div>
                    <div
                      class="col-md-2 text-center d-flex justify-content-center align-items-center"
                    >
                      <p class="text-muted mb-0 small">{{ product.product.category }}</p>
                    </div>
                    <div
                      class="col-md-2 text-center d-flex justify-content-center align-items-center"
                    >
                      <p class="text-muted mb-0 small">Qty: {{ product.quantity }}</p>
                    </div>
                    <div
                      class="col-md-2 text-center d-flex justify-content-center align-items-center"
                    >
                      <p class="text-muted mb-0 small">
                        {{ '£' + calculateProductTotal(product) }}
                      </p>
                    </div>
                  </div>
                  <hr class="mb-4" style="background-color: #e0e0e0; opacity: 1" />
                  <div class="row d-flex align-items-center">
                    <div class="col-md-2">
                      <p class="text-muted mb-0 small">Track Order</p>
                    </div>
                    <div class="col-md-10">
                      <div class="progress" style="height: 6px; border-radius: 16px">
                        <div
                          class="progress-bar bg-success"
                          role="progressbar"
                          style="width: 15%; border-radius: 16px"
                          aria-valuenow="15"
                          aria-valuemin="0"
                          aria-valuemax="100"
                        ></div>
                      </div>
                      <div class="d-flex justify-content-around mb-1">
                        <p class="text-muted mt-1 mb-0 small ms-xl-5">Out for delivery</p>
                        <p class="text-muted mt-1 mb-0 small ms-xl-5">Delivered</p>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="d-flex justify-content-between pt-2">
                <p class="fw-bold mb-0">Order Details</p>
                <p class="text-muted mb-0">
                  <span class="fw-bold me-4">Total</span> {{ '£' + getBasketTotal() }}
                </p>
              </div>

              <div class="d-flex justify-content-between pt-2">
                <p class="text-muted mb-0">Invoice Number : 788152</p>
                <p class="text-muted mb-0"><span class="fw-bold me-4">Discount</span> £0</p>
              </div>

              <div class="d-flex justify-content-between">
                <p class="text-muted mb-0">
                  Invoice Date : {{ new Date(Date.now()).toLocaleDateString() }}
                </p>
              </div>

              <div class="d-flex justify-content-between mb-5">
                <p class="text-muted mb-0">Recepits Voucher : 1KAU9-84UIL</p>
                <p class="text-muted mb-0">
                  <span class="fw-bold me-4">Delivery Charges</span> Free
                </p>
              </div>
            </div>
            <div
              class="card-footer border-0 px-4 py-5 bg-success"
              style="border-bottom-left-radius: 10px; border-bottom-right-radius: 10px"
            >
              <h5
                class="d-flex align-items-center justify-content-end text-white text-uppercase mb-0"
              >
                Total paid: <span class="h2 mb-0 ms-2">£{{ getBasketTotal() }}</span>
              </h5>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script lang="ts">
import { defineComponent, type PropType } from 'vue'
import { useSharedStore } from '@/store/SharedStore'
import { useBasketStore } from '@/store/BasketStore'
import { Categories } from '@/Enums/CategoriesEnum'
import ProductCard from '@/components/ProductCard.vue'
import type IProduct from '@/interfaces/IProduct'
import HelperMethods from '@/Helpers/HelperMethods'
import type IBasketProduct from '@/interfaces/IBasketProduct'

export default defineComponent({
  setup() {},
  props: {
    category: String
  },
  data() {
    const helper = new HelperMethods()
    var sharedStore = useSharedStore()
    var basketStore = useBasketStore()
    return {
      helper,
      sharedStore,
      basketStore
    }
  },
  components: {
    ProductCard
  },
  computed: {},
  methods: {
    catStringToEnum(str: string | undefined) {
      if (str) {
        str = this.helper.uppercaseFirstLetter(str)
      } else {
        return Categories.NotFound
      }

      console.log(Categories[str as keyof typeof Categories])
      return Categories[str as keyof typeof Categories]
    },
    calculateProductTotal(product: IBasketProduct) {
      return (product.product.price * product.quantity).toFixed(2)
    },
    getAllProducts() {
      return this.basketStore.getProducts
    },
    getBasketTotal() {
      return this.basketStore.getSumTotal
    }
  },
  watch: {},
  async mounted() {}
})
</script>

<style scoped></style>
