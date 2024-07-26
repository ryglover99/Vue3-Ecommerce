<script lang="ts">
import { defineComponent, type PropType } from 'vue'
import ProductsService from '@/services/ProductsService'
import BasketSlideOut from '@/components/BasketSlideOut.vue'
import { useBasketStore } from '@/store/store'
import ReviewCard from '@/components/ReviewCard.vue'
import type IReview from '@/interfaces/IReview'

import type IProduct from '@/interfaces/IProduct'

const productsService = new ProductsService()

export default defineComponent({
  setup() {},
  props: {
    category: String
  },
  data() {
    return {}
  },
  components: {},
  computed: {},
  methods: {},
  watch: {},
  async mounted() {}
})
</script>

<template>
  {{ category }}
</template>

<style scoped></style>
