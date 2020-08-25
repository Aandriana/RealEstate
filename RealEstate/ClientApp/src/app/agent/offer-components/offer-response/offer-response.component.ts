import { Component, OnInit } from '@angular/core';
import {AnswersArray, GetQuestionModel, PropertyByIdModel} from '../../../core/models';
import {FormArray, FormControl, FormGroup, Validators} from '@angular/forms';
import {PropertyService} from '../../../core/services/property.service';
import {ActivatedRoute, Router} from '@angular/router';
import {OfferService} from '../../../core/services/offer.service';

@Component({
  selector: 'app-offer-response',
  templateUrl: './offer-response.component.html',
  styleUrls: ['./offer-response.component.scss']
})
export class OfferResponseComponent implements OnInit {
  id: any;
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
    response: new FormControl(2),
    answers: this.answers
  });
  async ngOnInit(): Promise<void> {
    this.answerArray = [];
    await this.idInit();
    await this.propertyInit();
  }
  idInit(): void {
    this.route.params.subscribe(value => {
      this.id = value.id;
    });
  }
  propertyInit(): any{
    this.offerService.getPropertyId(this.id).subscribe((data: any) => {
      this.propertyId = data;
      this.propertyService.getQuestions(this.propertyId)
        .subscribe(next => {
          this.questions = next;
          this.answersInit();
        });
    });
  }
  answersInit(): any {
    for (let i = 0; i < this.questions.length; i++) {
      this.answers.push(new FormControl(''));
    }
  }
  send(): any{
    this.offerService.acceptAgentResponse(this.id, this.offerForm.value, this.arrayInit()).subscribe(() => this.router.navigateByUrl('agent/offers'));
  }
  arrayInit(): any{
    for (let i = 0; i < this.answers.length; i++) {
      this.answerArray.push({ answerText: this.answers.at(i).value, question: this.questions[i].question});
    }
    return this.answerArray;
  }
}
