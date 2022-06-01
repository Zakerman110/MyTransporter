import { Component, OnInit } from '@angular/core';
import { SwiperComponent } from "swiper/angular";

// import Swiper core and required modules
import SwiperCore, { Navigation } from "swiper";
import { CommentService } from 'src/app/core/services/comment.service';
import { CommentDto } from 'src/app/core/interfaces/comment.interface';

// install Swiper modules
SwiperCore.use([Navigation]);

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(public commentService: CommentService) { }

  comments: CommentDto[] = [];

  ngOnInit(): void {
    this.commentService.getComments().subscribe(data => {this.comments = data;})
  }
  
  // @ts-ignore
  onSwiper(swiper) {
    console.log(swiper);
  }
  onSlideChange() {
    console.log('slide change');
  }

}
