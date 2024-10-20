import { defineStore } from 'pinia'
import type IProduct from '@/interfaces/IProduct'

const initialState = {
  products: [] as IProduct[]
}

export const useSharedStore = defineStore('shared', {
  state: () => initialState,
  getters: {
    getProducts: (state) => state.products,
    getProductsCount: (state) => {
      return state.products.length
    },
    getAllProductsInCategory: (state) => {
      return (category: Categories) =>
        state.products.filter((product) => (product.category as Categories) === category)
    }
  },
  actions: {
    populateProductList(products: IProduct[]) {
      this.products = products
    },
    clearProductsList(id: number) {
      this.products = []
    }
  }
})
