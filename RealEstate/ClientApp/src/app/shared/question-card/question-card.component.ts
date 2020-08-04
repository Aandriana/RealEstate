import {Component, Input, OnInit} from '@angular/core';
import {Questions} from '../../core/models';

@Component({
  selector: 'app-question-card',
  templateUrl: './question-card.component.html',
  styleUrls: ['./question-card.component.scss']
})
export class QuestionCardComponent implements OnInit {
  @Input() question: Questions;
  constructor() { }

  ngOnInit(): void {
  }

}
