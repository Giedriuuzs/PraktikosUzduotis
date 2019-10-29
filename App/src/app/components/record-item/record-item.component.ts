import { Component, OnInit, Input } from '@angular/core';
import { Record } from '../../models/record';
import { MatDialog, MatDialogConfig } from "@angular/material";
import { CommentsComponent } from "../comments/comments.component";
import { setDefaultService } from 'selenium-webdriver/opera';

@Component({
  selector: 'app-record-item',
  templateUrl: './record-item.component.html',
  styleUrls: ['./record-item.component.css']
})
export class RecordItemComponent implements OnInit {
  @Input() record: Record;
  constructor(private dialog: MatDialog) { }

  ngOnInit() {
  }

  openDialog() {

    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = false;
    dialogConfig.autoFocus = true;
    dialogConfig.data = {
      recordId: this.record.id,
      recordTitle: this.record.title,
      recordText: this.record.text
    };
    this.dialog.open(CommentsComponent, dialogConfig);
  }

}
