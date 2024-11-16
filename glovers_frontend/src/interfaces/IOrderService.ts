import type IOrder from './IOrder'

export default interface IOrderService {
  saveOrder(order: IOrder): Promise<boolean>
}
