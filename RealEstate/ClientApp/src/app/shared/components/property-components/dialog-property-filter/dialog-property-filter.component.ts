import {Component, EventEmitter, Inject, OnInit, Output} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {MatRadioChange} from '@angular/material/radio';
import {Filter} from '../../../../core/models';

@Component({
  selector: 'app-dialog-property-filter',
  templateUrl: './dialog-property-filter.component.html',
  styleUrls: ['./dialog-property-filter.component.scss']
})
export class DialogPropertyFilterComponent{
  constructor(
    public dialogRef: MatDialogRef<DialogPropertyFilterComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Filter) {}

  onNoClick(): void {
    this.dialogRef.close({
      status: null,
      category: null,
    });
  }
  onCategoryChange(mrChange: MatRadioChange): any{
    this.data.category = mrChange.value;
  }
  onStatusChange(mrChange: MatRadioChange): any{
    this.data.status = mrChange.value;
  }
}
