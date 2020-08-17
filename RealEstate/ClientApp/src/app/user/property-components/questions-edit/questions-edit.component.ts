import { Component, OnInit } from '@angular/core';
import {GetQuestionModel} from '../../../core/models';
import {PropertyService} from '../../../core/services/property.service';
import {ActivatedRoute} from '@angular/router';
import {DialogDeletingSureComponent, DialogEditQuestionComponent} from '../../../shared/components/shared-components';
import {MatDialog} from '@angular/material/dialog';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {DialogAddQuestionComponent} from '../../../shared/components/shared-components/dialog-add-question/dialog-add-question.component';

@Component({
  selector: 'app-questions-edit',
  templateUrl: './questions-edit.component.html',
  styleUrls: ['./questions-edit.component.scss']
})
export class QuestionsEditComponent implements OnInit {
questions: GetQuestionModel[];
propertyId: any;
  editQuestionForm = new FormGroup({
    question: new FormControl('', Validators.required),
  });
  constructor(private propertyService: PropertyService, private route: ActivatedRoute, public dialog: MatDialog) { }
  ngOnInit(): void {
    this.route.params.subscribe(value => {
      this.propertyId = value.id;
    });
    this.propertyService.getQuestions(this.propertyId)
      .subscribe(data => this.questions = data);
  }
  delete(id): void {
    this.propertyService.deleteQuestion(id).subscribe(() =>
        this.ngOnInit()
      );
  }
  edit(id): void{
    this.propertyService.updateQuestion(id, this.editQuestionForm.value).subscribe(() =>
      this.ngOnInit()
    );
  }
  add(): void{
    this.propertyService.addQuestion(this.propertyId, this.editQuestionForm.value).subscribe(() =>
      this.ngOnInit()
    );
  }
  openDeleteDialog(id): void {
    const dialogRef = this.dialog.open(DialogDeletingSureComponent, {
      width: '300px',
    }).afterClosed()
      .subscribe((item: boolean) => {
        if (item) {
          this.delete(id);
        }
      });
  }
  formInit(qustrionText): FormGroup{
    this.editQuestionForm.setValue({
      question: qustrionText
    });
    return this.editQuestionForm;
  }
  openUpdateDialog(id, text): void {
    const dialogRef = this.dialog.open(DialogEditQuestionComponent, {
      data: this.formInit(text),
      width: '700px',
      height: '150px'
    }).afterClosed()
      .subscribe((item: any) => {
        this.editQuestionForm.setValue({
          question: item.question
        });
        this.edit(id);
      });
  }
  openAddDialog(): void {
    const dialogRef = this.dialog.open(DialogAddQuestionComponent, {
      width: '700px',
      height: '150px'
    }).afterClosed()
      .subscribe((item: any) => {
        this.editQuestionForm.setValue({
          question: item.question
        });
        this.add();
      });
  }
}
