import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Filter, GetQuestionModel} from '../../../../core/models';
import {DialogPropertyFilterComponent} from '..';
import {DialogDeletingSureComponent} from '../../shared-components/dialog-deleting-sure/dialog-deleting-sure.component';
import {MatDialog} from '@angular/material/dialog';

@Component({
  selector: 'app-questions-card',
  templateUrl: './questions-card.component.html',
  styleUrls: ['./questions-card.component.scss']
})
export class QuestionsCardComponent implements OnInit {
@Input() question: GetQuestionModel;
  @Output() public delete: EventEmitter<any> = new EventEmitter();
  @Output() public update: EventEmitter<any> = new EventEmitter();
  constructor(public dialog: MatDialog) { }

  ngOnInit(): void {
  }
  edit(): void {
    this.update.emit();
  }
  remove(): void{
    this.delete.emit();
  }
}
