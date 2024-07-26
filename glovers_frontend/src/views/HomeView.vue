<script lang="ts">
import { defineComponent, type PropType } from 'vue'

import ProductCard from '@/components/ProductCard.vue'
import CategoryCard from '@/components/CategoryCard.vue'
import ProductsService from '@/services/ProductsService'

import type IProduct from '@/interfaces/IProduct'
import 'vue3-carousel/dist/carousel.css'
import { Carousel, Slide, Pagination, Navigation } from 'vue3-carousel'
import image1 from '@/assets/img/person.jpg'
import image2 from '@/assets/img/veg.jpg'

const productsService = new ProductsService()

export default defineComponent({
  props: {
    toggleBasketSlideEvent: Boolean as PropType<boolean>
  },
  data() {
    const allProducts: IProduct[] = []
    const categories: string[] = []
    const productsInEachCategory: IProduct[] = []

    const images = [
      { id: 1, url: image1, overlayText: 'Skip the queue and order directly from your home!' },
      {
        id: 2,
        url: image2,
        overlayText: 'With thousands of fresh produce, you are bound to find your next go-to meal!'
      }
    ]
    return {
      // Reactive data here
      images,
      allProducts,
      categories,
      productsInEachCategory
    }
  },
  components: {
    CategoryCard,
    ProductCard,
    Carousel,
    Slide,
    Pagination,
    Navigation
  },
  computed: {},
  methods: {
    async getProductsInCategory(category: string): Promise<IProduct[]> {
      return await productsService.getAllProductsInCategory(category)
    },

    async getAllCategories(): Promise<void> {
      this.categories = await productsService.getAllCategories()
    },

    async getLimitedProducts(amount: number): Promise<void> {
      this.allProducts = await productsService.getLimitedProducts(amount)
    },

    async getFirstProductInEachCategory(): Promise<void> {
      if (this.categories.length <= 0) return

      let products: IProduct[] = []

      for (let i = 0; i < this.categories.length; i++) {
        let category = this.categories[i]
        let responseList = await this.getProductsInCategory(category)

        if (responseList.length < 0) return
        products.push(responseList[0]) // first product
      }

      this.productsInEachCategory = products.splice(0, 8)
    },
    pushToCategory(category: string) {
      this.$router.push(`/category/${category}`)
    }
  },
  watch: {},
  async mounted() {
    await this.getAllCategories()
    await Promise.all([this.getFirstProductInEachCategory(), this.getLimitedProducts(12)])
  }
})
</script>

<template>
  <section class="carouselSec">
    <div class="row">
      <Carousel :autoplay="10000" :wrap-around="true" :itemsToShow="1">
        <Slide v-for="image in images" :key="image.id">
          <div class="carousel__item">
            <div class="caro-div">
              <img :src="image.url" />
              <div class="overlay d-flex flex-column">
                <h2>{{ image.overlayText }}</h2>
                <button class="btn btn-success mt-4">Explore</button>
              </div>
            </div>
          </div>
        </Slide>
      </Carousel>
    </div>
  </section>

  <section id="featuredCategories" class="pagesec">
    <div class="row gy-5">
      <div class="productsSec-popProducts"><h2 class="col">Featured Categories</h2></div>
      <CategoryCard
        @click="pushToCategory(product.category.toLowerCase())"
        v-for="product in productsInEachCategory"
        :key="product.id"
        :product="product"
      ></CategoryCard>
    </div>
  </section>

  <section class="pagesec">
    <div class="row d-flex flex-row justify-content-between h-100 w-100 g-3">
      <div class="col-6 feat-card h-100">
        <div class="content-wrap d-flex justify-content-start align-items-start flex-column">
          <span class="w-100">Find your Fresh Fruit</span>
          <p class="w-100">
            For the topping on your cake or for the grazers, view our fresh fruits now.
          </p>
          <button class="btn btn-light">Shop now</button>
        </div>
        <img
          class="mw-100 h-100 object-fit-cover w-100 rounded-sm"
          src="@/assets/img/strawbs.jpg"
        />
      </div>
      <div class="col-6 feat-card h-100">
        <div class="content-wrap d-flex justify-content-start align-items-start flex-column">
          <span class="w-100">View all Meat</span>
          <p class="w-100">Straight from the butchers table and right onto your grill.</p>
          <button class="btn btn-light">Shop now</button>
        </div>
        <img class="mw-100 h-100 w-100 object-fit-cover rounded-sm" src="@/assets/img/steak.jpg" />
      </div>
    </div>
  </section>

  <section id="productsSec" class="pagesec">
    <div class="container-fluid row gy-5">
      <div class="productsSec-popProducts"><h2 class="col">Popular Products</h2></div>
      <ProductCard
        v-for="product in allProducts"
        :key="product.id"
        :product="product"
      ></ProductCard>
    </div>
  </section>
</template>

<style>
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
  margin-left: auto;
  margin-right: auto;
  display: flex;
  justify-content: center;
  flex-direction: column;
}

.pagesec-overflown {
  margin-top: 6rem;
  display: flex;
  justify-content: center;
  flex-direction: column;
}

.productsSec-popProducts {
  margin-left: 10px;
}
</style>
