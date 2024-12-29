<template>
  <div class="reviewCard p-5">
    <div class="row">
      <div class="col-8 titleCol">
        <h4>"{{ review?.title }}"</h4>
      </div>
      <div class="col-4">
        <span v-for="number in review?.rating"
          ><font-awesome-icon icon="star" size="xl" style="color: #ffd43b"
        /></span>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <small class="fs-6"> - Anonymous</small>
      </div>
    </div>
    <div class="row">
      <p class="fs-5">{{ review?.description }}</p>
    </div>
  </div>
</template>

<script lang="ts">
import type IProduct from '@/interfaces/IProduct'
import HelperMethods from '@/Helpers/HelperMethods'
import { useBasketStore } from '@/store/BasketStore'
import { defineComponent } from 'vue'
import type { Prop, PropType } from 'vue'
import type IReview from '@/interfaces/IReview'

export default defineComponent({
  props: {
    review: Object as PropType<IReview>
  },
  methods: {}
})
</script>

<style scoped></style>
@/store/BasketStore
