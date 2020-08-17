import {Component, Input, OnInit} from '@angular/core';
import {OffersListModel} from '../../../../core/models';

@Component({
  selector: 'app-offers-card',
  templateUrl: './offers-card.component.html',
  styleUrls: ['./offers-card.component.scss']
})
export class OffersCardComponent implements OnInit {
  @Input() offer: OffersListModel;
  panelOpenState = false;
  constructor() { }

  ngOnInit(): void {
  }

}
