import {Component, Input, OnInit} from '@angular/core';
import {AbstractControl} from '@angular/forms';

@Component({
  selector: 'app-mat-error',
  templateUrl: './mat-error.component.html',
  styleUrls: ['./mat-error.component.scss']
})
export class MatErrorComponent implements OnInit {
  @Input() control: AbstractControl | null;
  @Input() patternMessage: string;
  constructor() { }
  errorItem = {};

  ngOnInit(): void {
    this.errorItem = {
      required: 'field required',
      pattern: this.patternMessage,
    };
  }
}
