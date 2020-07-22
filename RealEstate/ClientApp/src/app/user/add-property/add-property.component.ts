import { Component, OnInit } from '@angular/core';
import {FormArray, FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {PropertyService} from '../../core/services/property.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.scss']
})
export class AddPropertyComponent implements OnInit {
  isLinear = false;
  questionsArray = new FormArray([]);
  addPropertyForm = new FormGroup({
    size: new FormControl('', [Validators.required,  Validators.pattern(/^[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?$/)]),
    category: new FormControl('', [Validators.required]),
    floorsNumber: new FormControl('', [Validators.required, Validators.pattern(/(?<=\s|^)\d+(?=\s|$)/)]),
    floors: new FormControl('', [Validators.required,  Validators.pattern(/(?<=\s|^)\d+(?=\s|$)/)]),
    price: new FormControl('', [Validators.required, Validators.pattern(/^[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?$/)]),
    city: new FormControl('', Validators.required),
    address: new FormControl('', Validators.required),
    buildYear: new FormControl('', Validators.required),
    photos: new FormControl(null),
    questions: this.questionsArray
  });
  constructor(private propertyService: PropertyService, private router: Router) { }
  ngOnInit(): void {
  }
  addQuestions(): any{
    this.questionsArray.push(new FormControl(''));
  }
  onFirstSubmit(): void{
    this.propertyService.firstStep(this.addPropertyForm.value);
  }
  onSecondSubmit(): void{
    this.propertyService.secondStep(this.addPropertyForm.value);
  }
  onThirtSubmit(): void{
    const length = this.questionsArray.length;
    this.propertyService.thirtStep(length, this.questionsArray);
  }
  onSubmit(): void{
    this.propertyService.addProperty(this.addPropertyForm.value).subscribe(res => {
      if (!res) { console.error('error'); }
      this.router.navigateByUrl('/home');
    });
  }
}
