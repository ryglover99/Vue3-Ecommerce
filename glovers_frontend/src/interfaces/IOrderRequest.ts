import type IBasketProduct from './IBasketProduct'
import type IProduct from './IProduct'
import type { PaymentMethod } from '@/Enums/PaymentMethod'

export default interface IOrderRequest {
  firstname: string
  lastname: string
  address: string
  address2: string
  postcode: string
  paymentMethod: PaymentMethod
  BasketItems: IBasketProduct[]
}
