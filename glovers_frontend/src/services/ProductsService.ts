import axios from 'axios'
import type IProduct from '@/interfaces/IProduct'
import type IReview from '@/interfaces/IReview'
import type IProductsService from '@/interfaces/IProductsService'

export default class ProductsService implements IProductsService {
  private baseUrl: string = 'https://localhost:44316/api/Products'

  private static defaultProductResponse: IProduct = {
    id: 0,
    title: '',
    price: 0,
    category: '',
    description: '',
    image: '',
    nutritionImage: ''
  }

  private static defaultReviewResponse: IReview = {
    id: 0,
    title: '',
    rating: 0,
    productId: -1,
    product: this.defaultProductResponse,
    description: ''
  }

  public async getAllProducts(): Promise<IProduct[]> {
    let response = await axios.get(`${this.baseUrl}/getAllProducts`)
    if (response.status == 200) {
      return response.data as IProduct[]
    } else {
      console.log(response, 'Failed to get all')
    }
    return [ProductsService.defaultProductResponse]
  }

  public async getProduct(id: number): Promise<IProduct> {
    let response = await axios.get(`${this.baseUrl}/getProduct/${id}`)
    if (response.status == 200) {
      return response.data as IProduct
    } else {
      console.log(response, `Failed to get product with id ${id}`)
    }
    return ProductsService.defaultProductResponse
  }

  public async getLimitedProducts(amount: number): Promise<IProduct[]> {
    let response = await axios.get(`${this.baseUrl}/getAllProducts/${amount}`)
    if (response.status == 200) {
      return response.data as IProduct[]
    } else {
      console.log(response, `Failed to get ${amount} products`)
    }
    return [ProductsService.defaultProductResponse]
  }

  public async getAllCategories(): Promise<string[]> {
    let defaultResp = ['']
    let response = await axios.get(`${this.baseUrl}/getAllCategories`)
    if (response.status == 200) {
      return response.data as string[]
    } else {
      console.log(response, `Failed to get products`)
    }
    return defaultResp
  }

  public async getAllProductsInCategory(category: string): Promise<IProduct[]> {
    let response = await axios.get(`${this.baseUrl}/getAllProducts/${category}`)
    if (response.status == 200) {
      return response.data as IProduct[]
    } else {
      console.log(response, `Failed to get all products in category: ${category}`)
    }
    return [ProductsService.defaultProductResponse]
  }

  public async getAllReviewForProduct(productId: number): Promise<IReview[]> {
    console.log()
    let response = await axios.get(`${this.baseUrl}/getReviews/${productId}`)
    if (response.status == 200) {
      return response.data as IReview[]
    } else {
      console.log(response, `Failed to get all reviews for product with id: ${productId}`)
    }
    return [ProductsService.defaultReviewResponse]
  }
}
