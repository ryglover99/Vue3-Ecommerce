import type IProduct from './IProduct'

export default interface IReview {
  id: number
  title: string
  rating: number
  productId: number
  product: IProduct
  description: string
}
