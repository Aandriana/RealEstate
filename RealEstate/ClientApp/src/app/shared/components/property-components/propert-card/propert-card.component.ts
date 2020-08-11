import {Component, Input, OnInit} from '@angular/core';
import {PropertyListModel} from '../../../../core/models';
import {Router} from '@angular/router';

@Component({
  selector: 'app-propert-card',
  templateUrl: './propert-card.component.html',
  styleUrls: ['./propert-card.component.scss']
})
export class PropertCardComponent implements OnInit {
  @Input() property: PropertyListModel;
  constructor(private router: Router) { }
  ngOnInit(): void {
  }

  chooseProperty(): void{
    this.router.navigateByUrl(`properties/${this.property.id}`);
  }
}