import {Component, Input, OnInit} from '@angular/core';
import {Answers} from '../../../../core/models';

@Component({
  selector: 'app-question-answer',
  templateUrl: './question-answer.component.html',
  styleUrls: ['./question-answer.component.scss']
})
export class QuestionAnswerComponent implements OnInit {
  @Input() answers: Answers;
  constructor() { }

  ngOnInit(): void {
  }

}
