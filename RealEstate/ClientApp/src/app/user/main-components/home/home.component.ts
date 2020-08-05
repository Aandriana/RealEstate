import {Component, HostListener, OnInit} from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  scrolled = 0;
  @HostListener('window:scroll', ['$event'])
  onWindowScroll($event): any {
    const numb = window.scrollY;
    if (numb >= 50){
      this.scrolled = 1;
    }
    else {
      this.scrolled = 0;
    }
  }

  constructor( private router: Router) { }

  ngOnInit(): void {
  }
  myProperties(): any{
     this.router.navigateByUrl('/properties');
  }
  addProperty(): any{
     this.router.navigateByUrl('properties/add');
  }
  agentsList(): any{
     this.router.navigateByUrl('agents');
  }

}
