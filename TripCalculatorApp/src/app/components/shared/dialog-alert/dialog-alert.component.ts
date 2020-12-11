import { DialogData } from './../../../utils/dialog-data';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-alert',
  templateUrl: './dialog-alert.component.html',
  styleUrls: ['./dialog-alert.component.sass']
})
export class DialogAlertComponent implements OnInit {

  title: string;
  message: string;

  constructor(
    public dialogRef: MatDialogRef<DialogAlertComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {
    this.title = data.title;
    this.message = data.message;
  }

  ngOnInit(): void {
  }

}
