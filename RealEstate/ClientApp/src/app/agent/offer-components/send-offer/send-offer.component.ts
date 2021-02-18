import { Component, OnInit } from '@angular/core';
import {PropertyService} from '../../../core/services/property.service';
import {ActivatedRoute, Router} from '@angular/router';
import {AnswersArray, GetQuestionModel} from '../../../core/models';
import {FormArray, FormControl, FormGroup, Validators} from '@angular/forms';
import {OfferService} from '../../../core/services/offer.service';

@Component({
  selector: 'app-send-offer',
  templateUrl: './send-offer.component.html',
  styleUrls: ['./send-offer.component.scss']
})
export class SendOfferComponent implements OnInit {
  propertyId: any;
  length: number;
  questions: GetQuestionModel[];
  answers = new FormArray([]);
  constructor(private propertyService: PropertyService, private route: ActivatedRoute, private offerService: OfferService, private router: Router) {
  }
  answerArray: AnswersArray[];
  offerForm = new FormGroup({
    comment: new FormControl(''),
    rate: new FormControl('', [Validators.required, Validators.pattern(/^[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?$/)]),
    propertyId: new FormControl(''),
    answers: this.answers
  });
  async ngOnInit(): Promise<void> {
    this.answerArray = [];
    await this.idInit();
    await this.getQuestions();
  }
  idInit(): void {
    this.route.params.subscribe(value => {
      this.propertyId = value.id;
      this.offerForm.patchValue({
        propertyId: value.id
      });
    });
  }
  getQuestions(): any {
    this.propertyService.getQuestions(this.propertyId)
      .subscribe(data => {
        this.questions = data;
        this.answersInit();
      });
  }
  answersInit(): any {
    for (let i = 0; i < this.questions.length; i++) {
      this.answers.push(new FormControl(''));
    }
  }
  send(): any{
    this.offerService.sendOfferAsAgent(this.offerForm.value, this.arrayInit()).subscribe(() => this.router.navigateByUrl('agent/offers'));
  }
  arrayInit(): any{
    for (let i = 0; i < this.answers.length; i++) {
      this.answerArray.push({ answerText: this.answers.at(i).value, question: this.questions[i].question});
    }
    return this.answerArray;
  }
}
