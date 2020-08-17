import { Component, OnInit } from '@angular/core';
import {MatDialogRef} from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-deleting-sure',
  templateUrl: './dialog-deleting-sure.component.html',
  styleUrls: ['./dialog-deleting-sure.component.scss']
})
export class DialogDeletingSureComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<DialogDeletingSureComponent>,
  ) { }

  ngOnInit(): void {
  }
  onNoClick(): void {
    this.dialogRef.close(false);
  }
  onConfirm(): void{
    this.dialogRef.close(true);
  }
}
