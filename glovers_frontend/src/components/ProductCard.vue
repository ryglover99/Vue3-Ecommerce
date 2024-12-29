<template>
  <div class="card-cnt col">
    <div class="card" style="width: 18rem; height: auto">
      <img
        @click="goToProductPage(product.id)"
        class="card-img-top"
        width="auto"
        height="100"
        :src="'/src/assets/img/' + product.image"
        alt="Product Image"
      />
      <div class="card-body">
        <span @click="goToProductPage(product.id)" class="pc_category">
          {{ helper.uppercaseFirstLetter(product.category) }}</span
        >
        <div @click="goToProductPage(product.id)" class="card-title-box">
          <h5 class="card-title">
            {{ product.title }}
          </h5>
        </div>
        <p @click="goToProductPage(product.id)" class="card-text">{{ product.description }}</p>
        <div class="row d-flex flex-nowrap">
          <div class="col">
            <span v-for="number in starList">
              <font-awesome-icon v-if="number == 1" icon="star" size="lg" style="color: #ffd43b" />
              <font-awesome-icon v-else icon="star-half-stroke" size="lg" style="color: #ffd43b" />
            </span>
          </div>
        </div>
        <div class="row mt-4">
          <div @click="goToProductPage(product.id)" class="col-8 d-flex align-items-center">
            <p class="d-flex justify-content-left align-items-center fs-5 font-weight-bold p-0 m-0">
              {{ '£' + product.price }}
            </p>
          </div>
          <div class="col-4">
            <a
              href="javascript:void(0)"
              @click="saveProductToStore(product)"
              class="d-flex w-100 align-items-center justify-content-between btn btn-success"
              >Add <img src="@/assets/img/plus.png" width="19" height="19"
            /></a>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import type IProduct from '@/interfaces/IProduct'
import HelperMethods from '@/Helpers/HelperMethods'
import { useBasketStore } from '@/store/BasketStore'
import { defineComponent } from 'vue'
import type { PropType } from 'vue'
import ProductsService from '@/services/ProductsService'

const productsService = new ProductsService()

export default defineComponent({
  setup() {
    const store = useBasketStore()
    return { store }
  },
  props: {
    product: {
      type: Object as PropType<IProduct>,
      required: true
    }
  },
  data() {
    var avgRating = 0
    var starList: number[] = []
    var helper = new HelperMethods()
    return {
      helper,
      avgRating,
      starList
    }
  },
  methods: {
    saveProductToStore(product: IProduct) {
      this.store.addProduct(this.product)
    },
    trimProductTitleToFour(title: string): string {
      return title.split(' ').slice(0, 4).join(' ')
    },
    addScrollingTextClassToElements() {
      var cardTitles = document.getElementsByClassName('card-title')
      for (let i = 0; i < cardTitles.length; i++) {
        let isTextOverflown = cardTitles[i].clientHeight + 5 < cardTitles[i].scrollHeight // add 5 to buffer, as font, line space can cause small issues
        if (isTextOverflown) {
          cardTitles[i].addEventListener('mouseenter', function (this: any) {
            this.style.transform = `translateY(-${cardTitles[i].scrollHeight - 15}px)`
          })
          cardTitles[i].addEventListener('mouseleave', function (this: any) {
            this.style.transform = `translateY(0)`
          })
        }
      }
    },
    goToProductPage(id: number) {
      this.$router.push(`/product/${id}`)
    },
    async getReviewsForProduct(id: number): Promise<number[]> {
      let reviews = await productsService.getAllReviewForProduct(id)
      let ratingsList: number[] = []

      reviews.forEach((review) => {
        ratingsList.push(review.rating)
      })

      return ratingsList
    },
    async calculateAverageRating(product: IProduct) {
      let rats = await this.getReviewsForProduct(product.id)
      let total = 0

      for (let i = 0; i < rats.length; i++) {
        let rat = rats[i]
        total += rat
      }

      let avg = total / rats.length

      this.avgRating = avg

      var numWholeStars = avg

      if (avg.toString().includes('.')) {
        let numWholeStarsString = avg.toString().split('.')[0]
        numWholeStars = parseInt(numWholeStarsString)
        this.starList.push(0)
      }

      for (let i = 0; i < numWholeStars; i++) {
        this.starList.unshift(1)
      }
    }
  },
  computed: {},
  async mounted() {
    if (this.product) {
      await this.calculateAverageRating(this.product)
    }

    this.addScrollingTextClassToElements()
  }
})
</script>

<style scoped>
.card-title-box {
  padding: 5px 0px 5px 0px;
  height: 40px;
  overflow: hidden;
  margin-bottom: 10px;
}
.card-img-top {
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 10px;
  height: 150px;
  object-fit: contain;
}

.card {
  height: 100%;
  padding: 10px 0px 10px 0px;
}

.card:hover {
  border: rgb(105, 167, 12) 1px solid;
  box-shadow: 0px 2px 2px 2px #47464609;
  cursor: pointer;
}
/* Hide scrollbar for Chrome, Safari and Opera */
.card-title::-webkit-scrollbar {
  display: none;
}

/* Hide scrollbar for IE, Edge and Firefox */
.card-title {
  transition: transform, 2s;
  height: 20px;
  padding: 0;
  margin: 0;
  -ms-overflow-style: none; /* IE and Edge */
  scrollbar-width: none; /* Firefox */
}

.card-cnt {
  display: flex;
}

.card-cnt.col {
  flex: 0 0 0%;
}

.card-body {
  display: flex;
  flex-direction: column;
  justify-content: end;
}

.card-body .btn {
  text-align: center;
  height: 35px;
  width: 35%;
}
</style>
@/store/BasketStore
