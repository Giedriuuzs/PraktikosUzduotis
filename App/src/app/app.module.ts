import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatDialogModule } from '@angular/material';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RecordsComponent } from './components/records/records.component';
import { AddRecordComponent } from './components/add-record/add-record.component';
import { CommentsComponent } from './components/comments/comments.component';
import { RecordItemComponent } from './components/record-item/record-item.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    RecordsComponent,
    AddRecordComponent,
    CommentsComponent,
    RecordItemComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatDialogModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [CommentsComponent]
})
export class AppModule { }
