import { Component, OnInit } from '@angular/core';
import { Record } from '../../models/record';
import { RecordService } from '../../services/record.service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-add-record',
  templateUrl: './add-record.component.html',
  styleUrls: ['./add-record.component.css']
})
export class AddRecordComponent implements OnInit {
  records: Record[];
  record: Record = {
    id: 0,
    title: null,
    email: null,
    text: null,
    time: null,
    commentsNr: 0
  };

  // email = new FormControl('', [
  //   Validators.required,
  //   Validators.email
  // ]);

  constructor(private recordService: RecordService) { }

  onClick(): void {
    this.record.time = new Date().toLocaleString();

    this.recordService.insertRecord(this.record).subscribe(() => {
      this.recordService.getAllRecords().subscribe(records => {
        this.records = records;
        this.recordService.changeRecords(this.records);
      });
    });
  }

  ngOnInit() {
    this.recordService.currentRecords.subscribe(records => this.records = records);
  }
}
