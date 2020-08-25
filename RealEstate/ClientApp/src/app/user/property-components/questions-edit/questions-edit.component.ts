import { Component, OnInit } from '@angular/core';
import {GetQuestionModel} from '../../../core/models';
import {PropertyService} from '../../../core/services/property.service';
import {ActivatedRoute} from '@angular/router';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {DialogService} from '../../../core/services/dialog.service';

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
  constructor(private propertyService: PropertyService, private route: ActivatedRoute, public dialog: DialogService) { }
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
    const dialogRef = this.dialog.openDialog()
      .afterClosed()
      .subscribe((item: boolean) => {
        if (item) {
          this.delete(id);
        }
      });
  }
  formInit(qustrionText): FormGroup {
    this.editQuestionForm.setValue({
      question: qustrionText
    });
    return this.editQuestionForm;
  }
  openUpdateDialog(id, text): void {
    const dialogRef = this.dialog.openDialog(this.formInit(text))
      .afterClosed()
      .subscribe((item: any) => {
        this.editQuestionForm.setValue({
          question: item.question
        });
        this.edit(id);
      });
  }
  openAddDialog(): void {
    const dialogRef = this.dialog.openDialog()
      .afterClosed()
      .subscribe((item: any) => {
        this.editQuestionForm.setValue({
          question: item.question
        });
        this.add();
      });
  }
}
