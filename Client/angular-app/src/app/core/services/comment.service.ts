import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
 
import { CommentDto } from '../interfaces/comment.interface';
 
@Injectable()
export class CommentService { 
   baseURL:string="https://localhost:7192/gateway/comment";
 
   constructor(private http:HttpClient){
   }
 
   getComments(): Observable<CommentDto[]> {
        return this.http.get<CommentDto[]>(this.baseURL)
   }
}