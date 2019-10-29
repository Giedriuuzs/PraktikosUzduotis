import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Comment } from '../../models/comment';
import { Record } from '../../models/record';
import { CommentService } from '../../services/comment.service';
import { RecordService } from '../../services/record.service';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css']
})
export class CommentsComponent implements OnInit {

  records: Record[];
  comments: Comment[];
  comment: Comment = {
    id: 0,
    email: null,
    text: null,
    time: null,
    fkRecord: null
  };

  constructor(
    public dialogRef: MatDialogRef<CommentsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private commentService: CommentService,
    private recordService: RecordService) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

  getComments(): void {
    this.commentService.getCommentsOnRecords(this.data.recordId)
      .subscribe(comments => this.comments = comments);
  }

  onClick(): void {
    this.comment.time = new Date().toLocaleString();
    this.comment.fkRecord = this.data.recordId;

    this.commentService.insertComment(this.comment).subscribe(() => {
      this.commentService.getCommentsOnRecords(this.data.recordId).subscribe(comments => {
        this.recordService.getAllRecords().subscribe(records => {
          this.records = records;
          this.recordService.changeRecords(this.records);
          this.comments = comments;
        })
      });
    });
  }
  ngOnInit() {
    this.commentService.currentComments.subscribe(comments => this.comments = comments);
    this.recordService.currentRecords.subscribe(records => this.records = records);
    this.getComments();
  }

}
