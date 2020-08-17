import {Component, OnInit} from '@angular/core';
import {JwtService} from './core/services/jwt.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'ClientApp';

  constructor(private jwtService: JwtService, private rourter: Router) {}

  ngOnInit(): void {
    console.log(this.rourter.url);
    if (this.rourter.url === '/') {
      if (this.jwtService.getRole() === 'Agent') {
        this.rourter.navigateByUrl('agent/home');
      }
      if (this.jwtService.getRole() === 'User') {
        this.rourter.navigateByUrl('home');
      }
      if (!this.jwtService.checkToken()) {
        this.rourter.navigateByUrl('login');
      }
    }
  }
}
