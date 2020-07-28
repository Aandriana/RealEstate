import {Component, Input, OnInit} from '@angular/core';
import {PropertyByIdModel} from '../../core/models';

@Component({
  selector: 'app-property-page',
  templateUrl: './property-page.component.html',
  styleUrls: ['./property-page.component.scss']
})
export class PropertyPageComponent implements OnInit {
  @Input() property: PropertyByIdModel;
ngOnInit(): void {}
}
