import { Component, OnInit } from '@angular/core';
import { Record } from '../../models/record';
import { RecordService } from '../../services/record.service';

@Component({
  selector: 'app-records',
  templateUrl: './records.component.html',
  styleUrls: ['./records.component.css']
})
export class RecordsComponent implements OnInit {

  records: Record[];

  getRecords(): void {
    this.recordService.getAllRecords()
      .subscribe(records => this.records = records);
  }

  constructor(private recordService: RecordService) { }

  ngOnInit() {
    this.recordService.currentRecords.subscribe(records => this.records = records);
    this.getRecords();
  }

}
