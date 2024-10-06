import type IProduct from './IProduct'
import type IReview from './IReview'

export default interface IProductsService {
  getAllProducts(): Promise<IProduct[]>
  getProduct(id: number): Promise<IProduct>
  getLimitedProducts(amount: number): Promise<IProduct[]>
  getAllCategories(): Promise<string[]>
  getAllProductsInCategory(category: string): Promise<IProduct[]>
  getAllReviewForProduct(productId: number): Promise<IReview[]>
}
