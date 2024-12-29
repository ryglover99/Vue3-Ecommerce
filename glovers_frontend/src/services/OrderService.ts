import type IOrderRequest from '@/interfaces/IOrderRequest'
import type IOrderResponse from '@/interfaces/IOrderResponse'
import type IOrderService from '@/interfaces/IOrderService'
import axios, { type AxiosResponse } from 'axios'

export default class OrderService implements IOrderService {
  private baseUrl: string = 'https://localhost:44316/api/Order'

  async saveOrder(order: IOrderRequest): Promise<IOrderResponse | null> {
    console.log(order, 'IORDER')
    let response = await axios.post(`${this.baseUrl}`, order)
    console.log(response.data, 'response')

    if (this.isResponseSuccess(response)) {
      console.log(response.data as IOrderResponse, 'response.data as IOrderResponse')
      return response.data as IOrderResponse
    }

    return null
  }

  private isResponseSuccess(response: AxiosResponse): boolean {
    return response.status >= 200 && response.status < 300
  }
}
