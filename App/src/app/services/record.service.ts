import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Record } from '../models/record';
import { HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable({
  providedIn: 'root'
})
export class RecordService {

  private recordsSource = new BehaviorSubject([]);
  currentRecords = this.recordsSource.asObservable();

  constructor(private http: HttpClient) { }

  changeRecords(records: Record[]): void {
    this.recordsSource.next(records);
  }

  private recordsUrl = 'https://localhost:5001/records';

  getAllRecords(): Observable<Record[]> {
    return this.http.get<Record[]>(this.recordsUrl);
  }

  insertRecord(record: Record): Observable<Record> {
    return this.http.post<Record>(
      this.recordsUrl, record);
  }

  updateRecord(record: Record): Observable<void> {
    return this.http.put<void>(
      this.recordsUrl + record.id, record

    )
  }
  deleteRecord(id: string) {
    return this.http.delete(
      this.recordsUrl + id
    )
  }
}
