import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {OffersListModel} from '../../../../core/models';
import {Router} from '@angular/router';

@Component({
  selector: 'app-get-offer-card-for-agent',
  templateUrl: './get-offer-card-for-agent.component.html',
  styleUrls: ['./get-offer-card-for-agent.component.scss']
})
export class GetOfferCardForAgentComponent implements OnInit {
  @Input() offer: OffersListModel;
  @Output() public accept: EventEmitter<any> = new EventEmitter();
  @Output() public decline: EventEmitter<any> = new EventEmitter();
  panelOpenState = false;

  constructor(private router: Router) {
  }

  ngOnInit(): void {
  }
  goToProperty(id): any{
    this.router.navigateByUrl(`agent/properties/${id}`);
  }
  accepting(): void {
    this.accept.emit();
  }
  declining(): void {
    this.decline.emit();
  }
}

