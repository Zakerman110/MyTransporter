import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
 
import { order } from '../models/order';
 
@Injectable()
export class OrderService { 
   baseURL:string="https://localhost:7192/gateway/order";
 
   constructor(private http:HttpClient){
   }
 
   getOrders(): Observable<order[]> {
        return this.http.get<order[]>(this.baseURL)
   }

   getOrdersByUserId(id: string): Observable<order[]> {
     return this.http.get<order[]>(this.baseURL + "/byUserId" + "/" + id)
   }

   getPrivacy(): Observable<order[]> {
      return this.http.get<order[]>(this.baseURL + '/privacy')
   }
}