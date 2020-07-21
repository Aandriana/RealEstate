import { Component, OnInit } from '@angular/core';
import {FormArray, FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.scss']
})
export class AddPropertyComponent implements OnInit {
  addPropertyForm = new FormGroup({
    size: new FormControl('', [Validators.required]),
    category: new FormControl('', [Validators.required]),
    floorsNumber: new FormControl('', [Validators.required]),
    floors: new FormControl('', [Validators.required]),
    price: new FormControl('', [Validators.required]),
    city: new FormControl('', Validators.required),
    address: new FormControl('', Validators.required),
    buildYear: new FormControl('', Validators.required),
    photos: new FormControl(null)
  });
  questions = new FormArray([]);
  constructor() { }
  ngOnInit(): void {
  }
  addQuestions(): any{
    this.questions.push(new FormControl(''));
  }


}
