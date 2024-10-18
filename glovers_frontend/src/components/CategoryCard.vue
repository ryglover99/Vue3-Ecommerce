<template>
  <div class="card-cnt col">
    <div class="card" style="width: 18rem; height: auto">
      <img
        class="card-img-top"
        width="auto"
        height="100"
        :src="'/src/assets/img/' + product.image"
        alt="Card image cap"
      />
      <div class="card-body">
        <p class="card-text text-center">{{ helper.uppercaseFirstLetter(product.category) }}</p>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import type IProduct from '@/interfaces/IProduct'
import HelperMethods from '@/Helpers/HelperMethods'
import { defineComponent } from 'vue'
import type { PropType } from 'vue'

export default defineComponent({
  props: {
    product: {
      type: Object as PropType<IProduct>,
      required: true
    }
  },
  data() {
    var helper = new HelperMethods()
    return {
      helper
    }
  },
  methods: {
    getImagePath(image: any) {
      return require(`@/assets/img/${image}`)
    }
  },
  computed: {},
  mounted() {}
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
  object-fit: contain;
}

.card {
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
  justify-content: center;
}
</style>
