<template>
  <div v-if="getAllBasketProducts().length <= 0 || orderStatus != -1">
    <div
      class="d-flex justify-content-center align-items-center text-center flex-column position-absolute"
      style="top: 50%; left: 50%; transform: translate(-50%, -50%)"
    >
      <div v-if="getAllBasketProducts().length <= 0 && orderStatus == -1">
        <img
          width="100"
          height="100"
          src="https://img.icons8.com/ios/100/sad-ghost.png"
          alt="sad-ghost"
        />
        <h3 class="pt-4">Oooops, your cart is empty!</h3>
        <button @click="pushToHome()" class="mt-3 btn btn-secondary btn-lg btn-block">
          Go back
        </button>
      </div>
      <div v-else-if="orderStatus == 1">
        <div class="animation-ctn">
          <div class="icon icon--order-success svg">
            <svg xmlns="http://www.w3.org/2000/svg" width="154px" height="154px">
              <g fill="none" stroke="#22AE73" stroke-width="2">
                <circle
                  cx="77"
                  cy="77"
                  r="72"
                  style="stroke-dasharray: 480px, 480px; stroke-dashoffset: 960px"
                ></circle>
                <circle
                  id="colored"
                  fill="#22AE73"
                  cx="77"
                  cy="77"
                  r="72"
                  style="stroke-dasharray: 480px, 480px; stroke-dashoffset: 960px"
                ></circle>
                <polyline
                  class="st0"
                  stroke="#fff"
                  stroke-width="10"
                  points="43.5,77.8 63.7,97.9 112.2,49.4 "
                  style="stroke-dasharray: 100px, 100px; stroke-dashoffset: 200px"
                />
              </g>
            </svg>
          </div>
        </div>
        <h3 class="mt-4">Thank you!</h3>
        <h4 class="mt-1">your order has been placed and will be out for delivery soon.</h4>
      </div>
      <div v-else-if="orderStatus == 2">
        <div class="animation-ctn">
          <div class="icon icon--order-success svg">
            <svg xmlns="http://www.w3.org/2000/svg" width="154px" height="154px">
              <g fill="none" stroke="#F44812" stroke-width="2">
                <circle
                  cx="77"
                  cy="77"
                  r="72"
                  style="stroke-dasharray: 480px, 480px; stroke-dashoffset: 960px"
                ></circle>
                <circle
                  id="colored"
                  fill="#F44812"
                  cx="77"
                  cy="77"
                  r="72"
                  style="stroke-dasharray: 480px, 480px; stroke-dashoffset: 960px"
                ></circle>
                <polyline
                  class="st0"
                  stroke="#fff"
                  stroke-width="10"
                  points="43.5,77.8  112.2,77.8 "
                  style="stroke-dasharray: 100px, 100px; stroke-dashoffset: 200px"
                />
              </g>
            </svg>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div v-else class="row pt-5 pb-3">
    <div class="col-md-4 order-md-2 mb-4">
      <h4 class="d-flex justify-content-between align-items-center mb-3">
        <span>Your cart</span>
        <span class="badge badge-secondary badge-pill">3</span>
      </h4>
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
    </div>
    <div class="col-md-8 order-md-1">
      <h4 class="mb-3">Billing address</h4>
      <form id="form" class="needs-validation" novalidate="false">
        <div class="row">
          <div class="col-md-6 mb-3">
            <label for="firstName">First name</label>
            <input
              v-model="order.firstname"
              type="text"
              class="form-control"
              id="firstName"
              placeholder=""
              required
            />
            <div class="invalid-feedback">Valid first name is required.</div>
          </div>
          <div class="col-md-6 mb-3">
            <label for="lastName">Last name</label>
            <input
              type="text"
              class="form-control"
              id="lastName"
              placeholder=""
              v-model="order.lastname"
              required
            />
            <div class="invalid-feedback">Valid last name is required.</div>
          </div>
        </div>

        <div class="mb-3">
          <label for="email">Email <span class="text-muted">(Optional)</span></label>
          <input type="email" class="form-control" id="email" placeholder="you@example.com" />
          <div class="invalid-feedback">
            Please enter a valid email address for shipping updates.
          </div>
        </div>

        <div class="mb-3">
          <label for="address">Address</label>
          <input
            type="text"
            class="form-control"
            id="address"
            placeholder="1234 Main St"
            v-model="order.address"
            required
          />
          <div class="invalid-feedback">Please enter your shipping address.</div>
        </div>

        <div class="mb-3">
          <label for="address2">Address 2 <span class="text-muted">(Optional)</span></label>
          <input
            type="text"
            v-model="order.address2"
            class="form-control"
            id="address2"
            placeholder="Apartment or suite"
          />
        </div>

        <div class="row">
          <div class="col-md-3 mb-3">
            <label for="zip">Postcode</label>
            <input
              v-model="order.postcode"
              type="text"
              class="form-control"
              id="zip"
              placeholder=""
              required
            />
            <div class="invalid-feedback">Postcode required.</div>
          </div>
        </div>
        <hr class="mb-4" />
        <div class="custom-control custom-checkbox">
          <input type="checkbox" class="custom-control-input" id="same-address" />
          <label class="custom-control-label mx-3" for="same-address"
            >Shipping address is the same as my billing address</label
          >
        </div>

        <h4 class="mb-3 mt-4">Payment</h4>

        <div class="d-block my-3">
          <div class="custom-control custom-radio">
            <input
              id="credit"
              v-model="order.paymentMethod"
              value="0"
              name="paymentMethod"
              type="radio"
              class="custom-control-input mx-3"
              required
            />
            <label class="custom-control-label" for="credit">Credit card</label>
          </div>
          <div class="custom-control custom-radio">
            <input
              v-model="order.paymentMethod"
              value="1"
              id="debit"
              name="paymentMethod"
              type="radio"
              class="custom-control-input mx-3"
              required
            />
            <label class="custom-control-label" for="debit">Debit card</label>
          </div>
        </div>
        <div class="row">
          <div class="col-md-6 mb-3">
            <label for="cc-name">Name on card</label>
            <input type="text" class="form-control" id="cc-name" placeholder="" required />
            <small class="text-muted">Full name as displayed on card</small>
            <div class="invalid-feedback">Name on card is required</div>
          </div>
          <div class="col-md-6 mb-3">
            <label for="cc-number">Card number</label>
            <input type="text" class="form-control" id="cc-number" placeholder="" required />
            <div class="invalid-feedback">Card number is required</div>
          </div>
        </div>
        <div class="row">
          <div class="col-md-3 mb-3">
            <label for="cc-expiration">Expiration</label>
            <input type="text" class="form-control" id="cc-expiration" placeholder="" required />
            <div class="invalid-feedback">Expiration date required</div>
          </div>
          <div class="col-md-3 mb-3">
            <label for="cc-expiration">CVV</label>
            <input type="text" class="form-control" id="cc-cvv" placeholder="" required />
            <div class="invalid-feedback">Security code required</div>
          </div>
        </div>
        <button
          class="mt-4 mb-4 btn btn-success btn-lg btn-block"
          type="submit"
          @click="onSubmit($event)"
        >
          Complete Order
        </button>
      </form>
    </div>
  </div>
</template>
<script lang="ts">
import { defineComponent, type PropType } from 'vue'
import type IProduct from '@/interfaces/IProduct'
import { useBasketStore } from '@/store/BasketStore'
import OrderService from '@/services/OrderService'
import type IOrder from '@/interfaces/IOrder'
import { PaymentMethod } from '@/Enums/PaymentMethod'
import router from '@/router'

var orderService = new OrderService()

export default defineComponent({
  props: {},
  data() {
    const store = useBasketStore()
    var order: IOrder = {
      firstname: '',
      lastname: '',
      address: '',
      address2: '',
      postcode: '',
      paymentMethod: PaymentMethod.CreditCard,
      BasketItems: []
    }
    var orderStatus = -1
    return {
      order,
      orderStatus,
      store
    }
  },
  components: {},
  computed: {},
  methods: {
    getAllBasketProducts() {
      return this.store.getProducts
    },
    sumTotal() {
      return this.store.getSumTotal
    },
    pushToHome() {
      this.$router.push('/')
    },
    async onSubmit(event: Event): Promise<void> {
      event.preventDefault()

      let form = document.getElementById('form') as HTMLFormElement
      if (!form || !form.checkValidity()) {
        console.log('no valid')
        event.preventDefault()
        console.log(form.reportValidity)
        form.classList.add('was-validated')
        return
      }

      let basketProds = this.getAllBasketProducts()

      if (!basketProds || basketProds.length <= 0) this.handleOrderFailed()

      this.order.BasketItems = basketProds
      let isSuccess = await orderService.saveOrder(this.order)
      isSuccess ? this.handleOrderSuccess() : this.handleOrderFailed()
    },
    handleOrderFailed() {
      //TODO: log?
      this.orderStatus = 2
    },
    handleOrderSuccess() {
      //TODO: log?
      this.orderStatus = 1
      this.store.emptyBasket()
      console.log(this.getAllBasketProducts(), 'prods')
    }
  },
  watch: {},
  mounted() {}
})
</script>
<style scoped>
.productsWrap {
  overflow-y: scroll;
  max-height: 500px;
}

.animation-ctn {
  text-align: center;
  margin-top: 5em;
}

@-webkit-keyframes checkmark {
  0% {
    stroke-dashoffset: 100px;
  }

  100% {
    stroke-dashoffset: 200px;
  }
}

@-ms-keyframes checkmark {
  0% {
    stroke-dashoffset: 100px;
  }

  100% {
    stroke-dashoffset: 200px;
  }
}

@keyframes checkmark {
  0% {
    stroke-dashoffset: 100px;
  }

  100% {
    stroke-dashoffset: 0px;
  }
}

@-webkit-keyframes checkmark-circle {
  0% {
    stroke-dashoffset: 480px;
  }

  100% {
    stroke-dashoffset: 960px;
  }
}

@-ms-keyframes checkmark-circle {
  0% {
    stroke-dashoffset: 240px;
  }

  100% {
    stroke-dashoffset: 480px;
  }
}

@keyframes checkmark-circle {
  0% {
    stroke-dashoffset: 480px;
  }

  100% {
    stroke-dashoffset: 960px;
  }
}

@keyframes colored-circle {
  0% {
    opacity: 0;
  }

  100% {
    opacity: 100;
  }
}

.inlinesvg .svg svg {
  display: inline;
}

.icon--order-success svg polyline {
  -webkit-animation: checkmark 0.25s ease-in-out 0.7s backwards;
  animation: checkmark 0.25s ease-in-out 0.7s backwards;
}

.icon--order-success svg circle {
  -webkit-animation: checkmark-circle 0.6s ease-in-out backwards;
  animation: checkmark-circle 0.6s ease-in-out backwards;
}
.icon--order-success svg circle#colored {
  -webkit-animation: colored-circle 0.6s ease-in-out 0.7s backwards;
  animation: colored-circle 0.6s ease-in-out 0.7s backwards;
}
</style>
