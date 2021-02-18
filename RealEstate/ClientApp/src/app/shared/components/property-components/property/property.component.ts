import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {PropertyByIdModel} from '../../../../core/models';

@Component({
  selector: 'app-property-page',
  templateUrl: './property.component.html',
  styleUrls: ['./property.component.scss']
})
export class PropertyPageComponent implements OnInit {
  @Input() property: PropertyByIdModel;
  @Output() public onComplete: EventEmitter<any> = new EventEmitter();
  @Output() public photoEdit: EventEmitter<any> = new EventEmitter();
  @Output() public delete: EventEmitter<any> = new EventEmitter();
  @Output() public restore: EventEmitter<any> = new EventEmitter();
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
  restoring(): any{
    this.restore.emit();
  }
  getPhoto(photo: string): string {
    return 'http://localhost:52833/' + photo;
  }
}
