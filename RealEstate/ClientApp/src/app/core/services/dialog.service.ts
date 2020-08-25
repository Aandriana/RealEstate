import { Injectable } from '@angular/core';
import {DialogEditQuestionComponent} from '../../shared/components/shared-components';
import {MatDialog, MatDialogRef} from '@angular/material/dialog';
import {FormControl, FormGroup} from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class DialogService {

  constructor(
    private dialog: MatDialog,
  ) { }
  openDialog(text?: FormGroup): MatDialogRef<any> {
    if (!text) {
      text = new FormGroup({
        question: new FormControl(''),
      });
    }
    return this.dialog.open(DialogEditQuestionComponent, {
      data: text,
      width: '700px',
      height: '150px'
    });
  }

}
