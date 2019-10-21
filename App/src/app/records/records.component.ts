import { Component, OnInit } from '@angular/core';
import { Record } from '../record';
import { RecordsMock } from '../mock-records';

@Component({
  selector: 'app-records',
  templateUrl: './records.component.html',
  styleUrls: ['./records.component.css']
})
export class RecordsComponent implements OnInit {

  records = RecordsMock;

  constructor() { }

  ngOnInit() {
  }
}
