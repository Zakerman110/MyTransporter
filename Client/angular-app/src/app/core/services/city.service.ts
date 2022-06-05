import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
 
import { CityDto } from '../interfaces/city.interface';

const httpOptions = {
   headers: new HttpHeaders({'Content-Type': 'application/json'})
 } 
 
@Injectable()
export class CityService { 
   baseURL:string="https://localhost:7192/gateway/city";
 
   constructor(private http:HttpClient){
   }
 
   getCities(): Observable<CityDto[]> {
        return this.http.get<CityDto[]>(this.baseURL)
   }
}