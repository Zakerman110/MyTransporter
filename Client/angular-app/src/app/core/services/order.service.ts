import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
 
import { NewOrder, OrderDto } from '../interfaces/order.interface';
import { VehicleOrderDto } from '../interfaces/vehicle.interface';

const httpOptions = {
   headers: new HttpHeaders({'Content-Type': 'application/json'})
 } 
 
@Injectable()
export class OrderService { 
   baseURL:string="https://localhost:7192/gateway/order";
 
   constructor(private http:HttpClient){
   }
 
   getOrders(): Observable<OrderDto[]> {
        return this.http.get<OrderDto[]>(this.baseURL)
   }

   getFreeVehicles(date: string): Observable<VehicleOrderDto[]> {
      const query = JSON.stringify(date);
      console.log("Date to search vehicles:");
      console.log(query);
      const myurl = this.baseURL + "/vehicle" + "/freeOnDate" + "?date=" + query.replace(/['"]+/g, '');
      console.log("URL is:");
      console.log(myurl);
      return this.http.get<VehicleOrderDto[]>(myurl)
      //return this.http.get<VehicleOrderDto[]>(this.baseURL + "/vehicle" + "/freeOnDate" + "?date=2022-03-16T08:00:17.000Z")
   }

   getOrdersByUserId(id: string): Observable<OrderDto[]> {
     return this.http.get<OrderDto[]>(this.baseURL + "/byUserId" + "/" + id)
   }

   addOrder(order: NewOrder): Observable<unknown> {
      const body = JSON.stringify(order);
      console.log("Add Order");
      console.log(body);
      return this.http.post(this.baseURL, body, httpOptions);
   }
  

   getPrivacy(): Observable<OrderDto[]> {
      return this.http.get<OrderDto[]>(this.baseURL + '/privacy')
   }
}