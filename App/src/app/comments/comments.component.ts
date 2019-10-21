import { Component, OnInit } from '@angular/core';
import { CommentsMock } from '../comments-mock';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css']
})
export class CommentsComponent implements OnInit {

  comments = CommentsMock;

  constructor() { }

  ngOnInit() {
  }

}
