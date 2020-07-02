import { JwtHelperService } from '@auth0/angular-jwt';

export class jwtService{
  constructor(
    private jwtHelper: JwtHelperService
  ) {}
}

function logout() {

}

logout() {
  localStorage.removeItem('token');
}
