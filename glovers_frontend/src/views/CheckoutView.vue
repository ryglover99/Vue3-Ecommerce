<template>
  <div v-if="getAllBasketProducts().length <= 0 && orderStatus == -1">
    <div
      class="d-flex justify-content-center align-items-center text-center flex-column position-absolute"
      style="top: 50%; left: 50%; transform: translate(-50%, -50%)"
    >
      <div>
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
    </div>
  </div>
  <div v-else-if="orderStatus == 1">
    <section class="h-100 gradient-custom">
      <div class="container py-5 h-100">
        <div class="row d-flex justify-content-center align-items-center h-100">
          <div class="col-lg-10 col-xl-8">
            <div class="card" style="border-radius: 10px">
              <div class="card-header px-4 py-5">
                <h5 class="text-muted mb-0">
                  Thanks for your Order,
                  <span class="text-success">{{ orderRequest.firstname }}</span
                  >!
                </h5>
              </div>
              <div class="card-body p-4">
                <div class="d-flex justify-content-between align-items-center mb-4">
                  <p class="lead fw-normal mb-0">Receipt</p>
                </div>
                <div
                  v-for="basketItem in orderRequest.BasketItems"
                  :key="basketItem.product.id"
                  class="card shadow-0 border mb-4"
                >
                  <div class="card-body">
                    <div class="row">
                      <div class="col-md-2">
                        <img
                          :src="'/src/assets/img/' + basketItem.product.image"
                          class="img-fluid"
                          alt="{{basketItem.product.title}}"
                        />
                      </div>
                      <div
                        class="col-md-2 text-center d-flex justify-content-center align-items-center"
                      >
                        <p class="text-muted mb-0">{{ basketItem.product.title }}</p>
                      </div>
                      <div
                        class="col-md-2 text-center d-flex justify-content-center align-items-center"
                      >
                        <p class="text-muted mb-0 small">{{ basketItem.product.category }}</p>
                      </div>
                      <div
                        class="col-md-2 text-center d-flex justify-content-center align-items-center"
                      >
                        <p class="text-muted mb-0 small">{{ basketItem.product.description }}</p>
                      </div>
                      <div
                        class="col-md-2 text-center d-flex justify-content-center align-items-center"
                      >
                        <p class="text-muted mb-0 small">Qty: {{ basketItem.quantity }}</p>
                      </div>
                      <div
                        class="col-md-2 text-center d-flex justify-content-center align-items-center"
                      >
                        <p class="text-muted mb-0 small">£{{ basketItem.product.price }}</p>
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
                            class="progress-bar"
                            role="progressbar"
                            style="width: 65%; border-radius: 16px; background-color: green"
                            aria-valuenow="65"
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
                    <span class="fw-bold me-4">Total</span> £{{ getOrderTotalPrice(orderRequest) }}
                  </p>
                </div>

                <div class="d-flex justify-content-between pt-2">
                  <p class="text-muted mb-0">Order Number : {{ orderResponse.number }}</p>
                </div>

                <div class="d-flex justify-content-between">
                  <p class="text-muted mb-0">
                    Invoice Date : {{ new Date(orderResponse.ts).toLocaleDateString() }}
                  </p>
                </div>

                <div class="d-flex justify-content-between mb-5">
                  <p class="text-muted mb-0">
                    <span class="fw-bold me-4">Delivery Charges:</span>Free
                  </p>
                </div>
              </div>
              <div
                class="card-footer border-0 px-4 py-5"
                style="
                  background-color: green;
                  border-bottom-left-radius: 10px;
                  border-bottom-right-radius: 10px;
                "
              >
                <h5
                  class="d-flex align-items-center justify-content-end text-white text-uppercase mb-0"
                >
                  Total paid:
                  <span class="h2 mb-0 ms-2">£{{ getOrderTotalPrice(orderRequest) }}</span>
                </h5>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
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
              v-model="orderRequest.firstname"
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
              v-model="orderRequest.lastname"
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
            v-model="orderRequest.address"
            required
          />
          <div class="invalid-feedback">Please enter your shipping address.</div>
        </div>

        <div class="mb-3">
          <label for="address2">Address 2 <span class="text-muted">(Optional)</span></label>
          <input
            type="text"
            v-model="orderRequest.address2"
            class="form-control"
            id="address2"
            placeholder="Apartment or suite"
          />
        </div>

        <div class="row">
          <div class="col-md-3 mb-3">
            <label for="zip">Postcode</label>
            <input
              v-model="orderRequest.postcode"
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
              v-model="orderRequest.paymentMethod"
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
              v-model="orderRequest.paymentMethod"
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
import type IOrderRequest from '@/interfaces/IOrderRequest'
import { PaymentMethod } from '@/Enums/PaymentMethod'
import HelperMethods from '@/Helpers/HelperMethods'
import type IOrderResponse from '@/interfaces/IOrderResponse'
import { OrderStatusEnum } from '@/Enums/OrderStatusEnum'
import { createModuleResolutionCache } from 'typescript'

var orderService = new OrderService()
const helper = new HelperMethods()
export default defineComponent({
  props: {},
  data() {
    const store = useBasketStore()
    var orderRequest: IOrderRequest = {
      firstname: '',
      lastname: '',
      address: '',
      address2: '',
      postcode: '',
      paymentMethod: PaymentMethod.CreditCard,
      BasketItems: []
    }
    var orderResponse: IOrderResponse = {
      number: '',
      ts: new Date(),
      status: OrderStatusEnum.Unknown,
      firstname: '',
      lastname: '',
      address: '',
      address2: '',
      postcode: '',
      paymentMethod: PaymentMethod.CreditCard,
      orderProductDetails: []
    }
    var orderStatus = -1
    return {
      orderRequest,
      orderStatus,
      store,
      orderResponse
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

      this.orderRequest.BasketItems = basketProds

      var orderResponse: IOrderResponse | null = await orderService.saveOrder(this.orderRequest)

      let isSuccess = orderResponse != null

      if (isSuccess && orderResponse) {
        this.orderResponse = orderResponse
        this.handleOrderSuccess()
      } else {
        this.handleOrderFailed()
      }
    },
    handleOrderFailed() {
      helper.scrollToTop()
      //TODO: log?
      this.orderStatus = 2
    },

    handleOrderSuccess() {
      helper.scrollToTop()
      this.orderStatus = 1
      this.store.emptyBasket()
      this.$emitter.emit('display-alert', 'This is a test alert!')
    },
    getOrderTotalPrice(order: IOrderRequest): string {
      let sum = 0
      for (let i = 0; i < order.BasketItems.length; i++) {
        let price = order.BasketItems[i].product.price * order.BasketItems[i].quantity
        sum += price
      }
      return sum.toFixed(2)
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
