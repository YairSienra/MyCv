import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoguearseService {

flag : boolean = false
constructor(private http : HttpClient, public r : Router) {

}


logueado() {
  if(localStorage.getItem('token')){
    this.flag = true
  }
}
cerrarSesion() {
  if(localStorage.getItem('token')){
    localStorage.removeItem('token')
      this.flag = false
    this.r.navigate(['auth/login'])
  }
}

}
