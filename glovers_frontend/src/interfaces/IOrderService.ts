import type IOrderRequest from './IOrderRequest'
import type IOrderResponse from './IOrderResponse'

export default interface IOrderService {
  saveOrder(order: IOrderRequest): Promise<IOrderResponse | null>
}
