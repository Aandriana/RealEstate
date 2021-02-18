import {Component, ElementRef, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-slider-row',
  templateUrl: './slider-row.component.html',
  styleUrls: ['./slider-row.component.scss']
})
export class SliderRowComponent {
  @Input('images') images: string[]
  @Output('removeImg') removeImg = new EventEmitter<string>();
  constructor(private elRef: ElementRef) { }

  onRemove(toRemoveUrl: string): any{
    this.removeImg.emit(toRemoveUrl);
  }

}
