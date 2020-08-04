import {Component, Input, OnInit} from '@angular/core';
import {Offers} from '../../core/models';

@Component({
  selector: 'app-offer-card',
  templateUrl: './offer-card.component.html',
  styleUrls: ['./offer-card.component.scss']
})
export class OfferCardComponent implements OnInit {
  @Input() offer: Offers;
  constructor() { }

  ngOnInit(): void {
  }

}
