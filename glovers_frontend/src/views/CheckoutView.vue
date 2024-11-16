<template>
  <div class="row pt-5 pb-3">
    <div class="col-md-4 order-md-2 mb-4">
      <h4 class="d-flex justify-content-between align-items-center mb-3">
        <span class="text-muted">Your cart</span>
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
        <hr class="mb-4" />

        <h4 class="mb-3">Payment</h4>

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
        <hr class="mb-4" />
        <button class="btn btn-success btn-lg btn-block" type="submit" @click="onSubmit($event)">
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
  setup() {
    const store = useBasketStore()
    return { store }
  },
  data() {
    var order: IOrder = {
      firstname: '',
      lastname: '',
      address: '',
      address2: '',
      postcode: '',
      paymentMethod: PaymentMethod.CreditCard,
      BasketItems: []
    }
    return {
      order
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
    onSubmit(event: Event): void {
      event.preventDefault()
      // TODO: Check for empty basket?
      console.log('ON SUBMIT')
      let form = document.getElementById('form') as HTMLFormElement
      if (!form || !form.checkValidity()) {
        event.preventDefault()
        form.classList.add('was-validated')
        console.log('badd valid')
        return
      }

      this.order.BasketItems = this.getAllBasketProducts()
      orderService.saveOrder(this.order)
      // Submit to Server
    }
  },
  watch: {},
  mounted() {}
})
</script>
<style>
.productsWrap {
  overflow-y: scroll;
  max-height: 500px;
}
</style>
