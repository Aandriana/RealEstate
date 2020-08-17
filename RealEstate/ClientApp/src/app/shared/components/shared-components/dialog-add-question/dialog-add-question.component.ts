import { Component, OnInit } from '@angular/core';
import {MatDialogRef} from '@angular/material/dialog';
import {FormControl, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-dialog-add-question',
  templateUrl: './dialog-add-question.component.html',
  styleUrls: ['./dialog-add-question.component.scss']
})
export class DialogAddQuestionComponent implements OnInit {
  editQuestionForm = new FormGroup({
    question: new FormControl('', Validators.required),
  });
  constructor(public dialogRef: MatDialogRef<DialogAddQuestionComponent>) { }

  ngOnInit(): void {
  }
  save(): any {
    this.dialogRef.close(this.editQuestionForm.value);
  }

  close(): any {
    this.dialogRef.close();
  }
}
