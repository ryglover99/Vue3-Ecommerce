<script lang="ts">
import { defineComponent, type PropType } from 'vue'
import ProductsService from '@/services/ProductsService'
import { useSharedStore } from '@/store/SharedStore'
import { Categories } from '@/Enums/CategoriesEnum'
import ProductCard from '@/components/ProductCard.vue'
import type IProduct from '@/interfaces/IProduct'
import HelperMethods from '@/Helpers/HelperMethods'

export default defineComponent({
  setup() {},
  props: {
    category: String
  },
  data() {
    const helper = new HelperMethods()
    var sharedStore = useSharedStore()
    return {
      helper,
      sharedStore
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
    }
  },
  watch: {},
  async mounted() {}
})
</script>

<template>
  <section id="productsSec" class="pagesec">
    <div class="container-fluid row gy-5">
      <div class="productsSec-popProducts">
        <h2 class="col">{{ helper.uppercaseFirstLetter(category) }}</h2>
      </div>
      <ProductCard
        v-for="product in sharedStore.getAllProductsInCategory(catStringToEnum(category))"
        :key="product.id"
        :product="product"
      ></ProductCard>
    </div>
  </section>
</template>

<style scoped></style>
@/store/BasketStore
