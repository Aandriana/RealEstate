import { Component, OnInit } from '@angular/core';
import {FormArray, FormControl, FormGroup, Validators} from '@angular/forms';
import {PropertyService} from '../../core/services/property.service';
import {Router} from '@angular/router';
import {FileInput} from 'ngx-material-file-input';
import {MatRadioChange} from '@angular/material/radio';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.scss']
})
export class AddPropertyComponent implements OnInit {
  isLinear = false;
   category: number;
  questionsArray = new FormArray([]);
  addPropertyForm = new FormGroup({
    size: new FormControl('', [Validators.required,  Validators.pattern(/^[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?$/)]),
    category: new FormControl('', [Validators.required]),
    floorsNumber: new FormControl('', [Validators.required, Validators.pattern(/(?:\s|^)\d+(?=\s|$)/)]),
    floors: new FormControl('', [Validators.required,  Validators.pattern(/(?:\s|^)\d+(?=\s|$)/)]),
    price: new FormControl('', [Validators.required, Validators.pattern(/^[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?$/)]),
    city: new FormControl('', Validators.required),
    address: new FormControl('', Validators.required),
    buildYear: new FormControl('', Validators.required),
    photos: new FormControl(null),
    questions: this.questionsArray,
  });
  constructor(private propertyService: PropertyService, private router: Router) { }
  ngOnInit(): void {}
  addQuestions(): any{
    this.questionsArray.push(new FormControl(''));
  }
  onChange(mrChange: MatRadioChange): any{
    this.category = mrChange.value;
  }
  onFirstSubmit(): void{
    this.propertyService.firstStep(this.addPropertyForm.value, this.category);
  }
  onSecondSubmit(): void{
    this.propertyService.secondStep(this.addPropertyForm.value);
  }
  onThirdSubmit(): void{
    const length = this.questionsArray.length;
    this.propertyService.thirdStep(length, this.questionsArray);
  }
  onFourthStep(): void{
    const images: FileInput = this.addPropertyForm.get('photos').value;
    let files: File[] = []
    if (images){
      files = images.files;
    }
    this.propertyService.fourthStep(files);
    this.router.navigateByUrl('/property/add/agents');
  }
}
