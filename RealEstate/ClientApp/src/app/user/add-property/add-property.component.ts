import { Component, OnInit } from '@angular/core';
import {FormArray, FormControl, FormGroup, Validators} from '@angular/forms';
import {PropertyService} from '../../core/services/property.service';
import {Router} from '@angular/router';
import {FileInput} from 'ngx-material-file-input';
import {AgentListModel} from '../../core/models';
import {AgentService} from '../../core/services/agent.service';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.scss']
})
export class AddPropertyComponent implements OnInit {
  isLinear = false;
  pageSize = 5;
  pageNumber = 0;
  button = 'Choose';
  agentList: AgentListModel[];
  agentsArray = new FormArray([]);
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
    questions: this.questionsArray,
    agents: this.agentsArray
  });
  constructor(private propertyService: PropertyService, private router: Router, private agentService: AgentService) { }
  ngOnInit(): void {
    this.getAgents();
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
  onThirdSubmit(): void{
    const length = this.questionsArray.length;
    this.propertyService.thirdStep(length, this.questionsArray);
  }
  addProperty(): void{
    const images: FileInput = this.addPropertyForm.get('photos').value;
    let files: File[] = []
    if (images){
      files = images.files;
    }
    this.propertyService.addProperty(files).subscribe(res => {
      if (!res) { console.error('error'); }
      this.router.navigateByUrl('/home');
    });
  }
  onFourhtSubmit(): void{
    const length = this.agentsArray.length;
    this.propertyService.fourthStep(length, this.agentsArray);
  }
  getAgents(): any {
    this.agentService.getAgents(this.pageNumber, this.pageSize)
      .subscribe(data => this.agentList = data);
  }
  onPageFired(event): any {
    event.pageIndex++;
    this.agentService.getAgents(event.pageIndex, event.pageSize)
      .subscribe(data => this.agentList = data);
  }
  addAgent(id): any{
    const idControl = new FormControl(id);
    for (let i = 0; i < this.agentsArray.length; i++) {
      if (this.agentsArray.at(i).value === id) {
        this.agentsArray.removeAt(i);
        return;
      }
    }
    this.agentsArray.push(idControl);
  }
}
