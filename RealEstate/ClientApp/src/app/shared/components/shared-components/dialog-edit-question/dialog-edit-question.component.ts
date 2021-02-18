import {Component, Inject, Input, OnInit} from '@angular/core';
import {FormGroup} from '@angular/forms';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-edit-question',
  templateUrl: './dialog-edit-question.component.html',
  styleUrls: ['./dialog-edit-question.component.scss']
})
export class DialogEditQuestionComponent implements OnInit {
  constructor( public dialogRef: MatDialogRef<DialogEditQuestionComponent>, @Inject(MAT_DIALOG_DATA) public data: FormGroup) { }
  ngOnInit(): void {
  }
  save(): any {
    this.dialogRef.close(this.data.value);
  }

  close(): any {
    this.dialogRef.close();
  }
}
