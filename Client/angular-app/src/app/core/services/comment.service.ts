import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
 
import { comment } from '../models/comment';
 
@Injectable()
export class CommentService { 
   baseURL:string="https://localhost:7192/gateway/comment";
 
   constructor(private http:HttpClient){
   }
 
   getComments(): Observable<comment[]> {
        return this.http.get<comment[]>(this.baseURL)
   }
}