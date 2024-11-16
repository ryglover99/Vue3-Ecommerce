import type IOrder from '@/interfaces/IOrder'
import type IOrderService from '@/interfaces/IOrderService'
import { PaymentMethod } from '@/Enums/PaymentMethod'
import axios from 'axios'

export default class OrderService implements IOrderService {
  private baseUrl: string = 'https://localhost:44316/api/Order'
  private static defaultOrderResponse: IOrder = {
    firstname: '',
    lastname: '',
    address: '',
    address2: '',
    postcode: '',
    paymentMethod: PaymentMethod.CreditCard,
    BasketItems: []
  }
  async saveOrder(order: IOrder): Promise<boolean> {
    console.log(order, 'IORDER')
    let response = await axios.put(`${this.baseUrl}`, order)
    return response.status === 200
  }
}
