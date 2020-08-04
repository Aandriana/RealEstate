import {Component, Input, OnInit} from '@angular/core';
import {AgentById, FeedbackList} from '../../core/models';

@Component({
  selector: 'app-feedback-card',
  templateUrl: './feedback-card.component.html',
  styleUrls: ['./feedback-card.component.scss']
})
export class FeedbackCardComponent implements OnInit {
  @Input() feedback: FeedbackList;

  constructor() { }

  ngOnInit(): void {
  }

}
