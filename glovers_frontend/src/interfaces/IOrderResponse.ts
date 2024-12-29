import type { OrderStatusEnum } from '@/Enums/OrderStatusEnum'
import type IBasketProduct from './IBasketProduct'
import type { PaymentMethod } from '@/Enums/PaymentMethod'

export default interface IOrderResponse {
  number: string
  ts: Date
  status: OrderStatusEnum
  orderProductDetails: IBasketProduct[]
  firstname: string
  lastname: string
  address: string
  address2: string
  postcode: string
  paymentMethod: PaymentMethod
}
