import { Component, OnInit } from '@angular/core';
import {NotificationService} from '../../../core/services/notificationService';
import {ActivatedRoute, Router} from '@angular/router';
import {AuthService} from '../../../core/services/auth.service';

@Component({
  selector: 'app-confirmation',
  templateUrl: './confirmation.component.html',
  styleUrls: ['./confirmation.component.scss']
})
export class ConfirmationComponent implements OnInit {
  confirmed: boolean;
  constructor(private notificationService: NotificationService,
              private router: Router,
              private route: ActivatedRoute,
              private authService: AuthService
              ) { }

  ngOnInit(): any{
    this.confirmed = false;
    this.route.queryParams.subscribe(query => {
      const id = query.id;
      const code = query.code;
      this.authService.confirmUser(code, id).subscribe(() => {
        this.confirmed = true;
      });
    });
  }
}
