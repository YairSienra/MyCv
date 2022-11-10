import { animate, style, transition, trigger } from '@angular/animations';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, FormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ErrorLoginFailComponent } from 'src/app/Dialogs/errorLoginFail/errorLoginFail.component';

import { LoguearseService } from './loguearse.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'], animations: [
    trigger('fade', [
      // state(),
      transition('void => *', [
        style({ opacity: 0 }),
        animate(2000)
      ])
    ])
  ]
})
export class LoginComponent implements OnInit {

  loginError = false;
  passError = false;

  login!: UntypedFormGroup

  constructor(public u: LoguearseService, private http: HttpClient, private route: Router, private formBuilder: UntypedFormBuilder,  public errorLogin :MatDialog) {

  }

  ngOnInit(): void {
    this.login = this.formBuilder.group({
      Email: ['', [Validators.email, Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
      Password: ['', [Validators.required]]
    })
    this.checkLocalStorage()
  }

  loguearse() {

    if (this.login.invalid) {
      let loginEmail = this.login.get('Email');
      let loginPass = this.login.get('Password');

      if(loginEmail?.errors){
        this.loginError = true
      } else {
        this.loginError = false;
      }

      if(loginPass?.errors){
        this.passError = true;
      } else {
        this.passError = false;
      }

      return
    } else {
      var user =  this.login.get('Email')?.value
      var pass = this.login.get('Password')?.value

      this.http.post('http://localhost:5243/api/Usuario/login', { Email: user, Password: pass }).subscribe((data: any) => {
        if (data != null) {
          localStorage.setItem('token', 'token')
          this.u.flag = true
          this.route.navigate([''])
        } else {
          this.openDialog()
        }
      })
    }

  }

  checkLocalStorage(){
    if (localStorage.getItem('token')) {
      this.u.flag = true
    }
  }

  openDialog(){
    this.errorLogin.open(ErrorLoginFailComponent)
  }


}
