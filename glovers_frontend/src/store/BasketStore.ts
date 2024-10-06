import { defineStore } from 'pinia'
import type IProduct from '@/interfaces/IProduct'
import type IBasketProduct from '@/interfaces/IBasketProduct'

const initialState = {
  products: [] as IBasketProduct[]
}
export const useBasketStore = defineStore('basket', {
  state: () => initialState,
  getters: {
    getProducts: (state) => state.products,
    getBasketCount: (state) => {
      let count = 0
      for (let i = 0; i < state.products.length; i++) {
        count += state.products[i].quantity
      }
      return count
    }
  },
  actions: {
    addProduct(product: IProduct) {
      var basketProduct: IBasketProduct = {
        product: product,
        quantity: 1
      }

      const basketAlreadyContainsProduct = this.products.some(
        (basketProduct) => basketProduct.product.id === product.id
      )

      if (basketAlreadyContainsProduct) {
        this.updateProduct(product.id)
      } else {
        this.products.push(basketProduct)
      }
    },
    removeProduct(id: number) {
      const index = this.products.findIndex((item) => item.product.id === id)
      if (index > -1) {
        this.products.splice(index, 1)
      }
    },
    updateProduct(id: number) {
      const index = this.products.findIndex((item) => item.product.id === id)
      var product = this.products[index]

      product.quantity += 1
    }
  }
})
