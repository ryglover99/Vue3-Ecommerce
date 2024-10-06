<script lang="ts">
import { defineComponent, type PropType } from 'vue'
import ProductsService from '@/services/ProductsService'
import BasketSlideOut from '@/components/BasketSlideOut.vue'
import { useBasketStore } from '@/store/BasketStore'
import ReviewCard  from '@/components/ReviewCard.vue'
import type IReview from '@/interfaces/IReview'

import type IProduct from '@/interfaces/IProduct'
import HelperMethods from '@/Helpers/HelperMethods'

const productsService = new ProductsService()
const helper = new HelperMethods();

export default defineComponent({
  setup() {
    const store = useBasketStore()
    return { store }
  },
  props: {
    id: String
  },
  data() {
    var product: IProduct = {
      id: -1,
      title: '',
      description: '',
      image: '',
      price: 0,
      category: '',
      nutritionImage:''
    }

    var reviews: IReview[] = [{
      id:-1,
      product: product,
      productId:-1,
      rating:0,
      description:"",
      title:""
    }]

    return {
      product,
      reviews
      // Reactive data here
    }
  },
  components: {
    BasketSlideOut,
    ReviewCard
  },
  computed: {
    shouldShowBasket() {
      return
    }
  },
  methods: {
    saveProductToStore(product: IProduct) {
      console.log('adding', product)
      this.store.addProduct(this.product)
    },
    async getProductById(id: string) {
      let idInt = Number.parseInt(id)
      if (!idInt) return
      return await productsService.getProduct(idInt)
    },
    async getAllReviewsForProduct(productId:number){
      let reviews = await productsService.getAllReviewForProduct(productId);
      console.log(reviews, "rev");
      return reviews;
    }
  },
  watch: {},
  async mounted() {
    helper.scrollToTop();
    if (this.id == null) return
    var prod = await this.getProductById(this.id)
    if (!prod) return
    this.product = prod
    let inff = parseInt(this.id)
    console.log(inff, "ingf");
    this.reviews = await this.getAllReviewsForProduct(parseInt(this.id))
  }
})
</script>

<template>
  <section class="pt-5 pb-3">
    <div class="prod-info">
      <div class="row">
        <div class="col-3">
          <img :src="'/src/assets/img/' + product.image" />
        </div>
        <div class="col-9 d-flex flex-column justify-content-center">
          <div class="row">
            <h2>{{ product.title }}</h2>
          </div>
          <div class="row">
            <p class="fs-5">{{ product.description }}</p>
          </div>
          <hr></hr>
          <div class="row">
            <div class="col-2">
              <h4>£{{ product.price }}</h4>
            </div>
            <div class="col-10">
              <button @click="saveProductToStore(product)" class="btn btn-success">Add to cart</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
  <section class="mt-5">
    <div class="row gx-5 d-flex justify-content-evenly">
      <div class="col-4 d-flex align-items-center justify-content-center"> 
        <img  class="w-100 h-100" :src="'/src/assets/img/nutrition/' + product.nutritionImage" />
      </div>
      <div class="col-7 border d-flex flex-column">
        <ReviewCard v-for="review in reviews" :review="review"></ReviewCard>
      </div>
    </div>
  </section>
</template>

<style scoped>
.caro-div {
  overflow: hidden;
  position: relative;
}

.caro-div h2 {
  font-size: 30px;
  color: white;
  width: 70%;
}

.caro-div .overlay {
  border-radius: 25% 74% 75% 25% / 0% 75% 25% 62%;
  display: flex;
  align-items: center;
  justify-content: center;
  text-align: center;
  left: 0;
  top: 0;
  width: 50%;
  height: 500px;
  position: absolute;
  background-color: rgb(72, 172, 72);
}

.overlay-dark {
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.178);
}
.rounded-lg {
  border-radius: 20px;
}

.rounded-sm {
  border-radius: 10px;
}
.feat-card {
  overflow: hidden;
  position: relative;
  max-height: 200px;
}

.feat-card img {
  padding: 0;
  margin: 0;
  z-index: 1;
}

.feat-card:hover {
  cursor: pointer;
}

.feat-card .content-wrap {
  padding-left: 4%;
  text-align: left;
  position: absolute;
  top: 50%;
  color: white;
  z-index: 10;
  font-size: 30px;
  transform: translateY(-50%);
}

.feat-card .content-wrap p {
  font-size: 13px;
}

.feat-card::after {
  border-radius: 10px;
  content: '';
  width: calc(100% - 18px);
  height: 100%;
  display: block;
  top: 0;
  left: 50%;
  transform: translateX(-50%);
  position: absolute;
  background-color: rgba(0, 0, 0, 0.493);
}

#carouselWrappedUp {
  width: 75%;
  margin: auto;
}
.carouselSec {
  height: 100%;
  width: 100%;
}
.carousel__item {
  min-height: 500px;
  width: 97%;
  color: white;
  font-size: 20px;
  display: flex;
  justify-content: center;
  align-items: center;
}

.carousel__track {
  margin: 0 !important;
}

.carousel__item img {
  border-radius: 20px;
  width: 100%;
  height: 100%;
}

.carousel__slide {
  padding: 20px;
}

.carousel__prev,
.carousel__next {
  box-sizing: content-box;
  border: 5px solid white;
}

.pagesec {
  margin-top: 6rem;
  width: 80%;
  margin-left: auto;
  margin-right: auto;
  display: flex;
  justify-content: center;
  flex-direction: column;
}

.pagesec-overflown {
  margin-top: 6rem;
  width: 80%;
  display: flex;
  justify-content: center;
  flex-direction: column;
}

.productsSec-popProducts {
  margin-left: 10px;
}
</style>
@/store/BasketStore