import { Component, OnInit } from '@angular/core';
import { SwiperComponent } from "swiper/angular";

// import Swiper core and required modules
import SwiperCore, { Navigation } from "swiper";
import { comment } from 'src/app/core/models/comment';
import { CommentService } from 'src/app/core/services/comment.service';

// install Swiper modules
SwiperCore.use([Navigation]);

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(public commentService: CommentService) { }

  comments: comment[] = [];

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
