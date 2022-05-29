import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
 
import { order } from '../models/order';
import { OrderDto } from '../interfaces/order.interface';
 
@Injectable()
export class OrderService { 
   baseURL:string="https://localhost:7192/gateway/order";
 
   constructor(private http:HttpClient){
   }
 
   getOrders(): Observable<OrderDto[]> {
        return this.http.get<order[]>(this.baseURL)
   }

   getOrdersByUserId(id: string): Observable<OrderDto[]> {
     return this.http.get<OrderDto[]>(this.baseURL + "/byUserId" + "/" + id)
   }

   getPrivacy(): Observable<OrderDto[]> {
      return this.http.get<OrderDto[]>(this.baseURL + '/privacy')
   }
}