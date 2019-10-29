import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Comment } from '../models/comment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  private commentsSource = new BehaviorSubject([]);
  currentComments = this.commentsSource.asObservable();

  constructor(private http: HttpClient) { }

  changeComments(comments: Comment[]): void {
    this.commentsSource.next(comments);
  }

  private commentsUrl = 'https://localhost:5001/comments';

  getAllComments(): Observable<Comment[]> {
    return this.http.get<Comment[]>
      (this.commentsUrl)
  }

  getCommentsOnRecords(fkRecord): Observable<Comment[]> {
    return this.http.get<Comment[]>
      (this.commentsUrl + '/' + fkRecord)
  }

  insertComment(comment: Comment): Observable<Comment> {
    return this.http.post<Comment>(
      this.commentsUrl, comment)
  }

  updateComment(comment: Comment): Observable<void> {
    return this.http.put<void>(
      this.commentsUrl + comment.id, comment

    )
  }
  deleteComment(id: string) {
    return this.http.delete(
      this.commentsUrl + id
    )
  }
}