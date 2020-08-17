import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {PropertyByIdModel} from '../../../../core/models';

@Component({
  selector: 'app-property-page',
  templateUrl: './property.component.html',
  styleUrls: ['./property.component.scss']
})
export class PropertyPageComponent implements OnInit {
  @Input() property: PropertyByIdModel;
  @Input() button: string;
  @Output() public onComplete: EventEmitter<any> = new EventEmitter();
  @Output() public photoEdit: EventEmitter<any> = new EventEmitter();
  @Output() public delete: EventEmitter<any> = new EventEmitter();
  @Output() public showOffers: EventEmitter<any> = new EventEmitter();
  @Output() public showQuestions: EventEmitter<any> = new EventEmitter();
  ngOnInit(): void {
  }
  buildUrl(slide: string): string {
    return `${slide}`;
  }
  runOnComplete(): void {
    this.onComplete.emit();
  }
  editor(): void {
    this.photoEdit.emit();
  }
  deleting(): void{
    this.delete.emit();
  }
  offersShow(): void{
    this.showOffers.emit();
  }
  questionsEdit(): void{
    this.showQuestions.emit();
  }
}
