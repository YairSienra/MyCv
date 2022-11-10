import { animate, style, transition, trigger } from '@angular/animations';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {
  UntypedFormBuilder,
  FormControl,
  UntypedFormGroup,
  FormGroupName,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { faL } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.scss'],
  animations: [
    trigger('fade', [
      // state(),
      transition('void => *', [style({ opacity: 0 }), animate(2000)]),
    ]),
  ],
})
export class RegistroComponent implements OnInit {
  datos: datosRegistro = {
    NombreCompleto: '',
    Email: '',
    Password: '',
  };

  registro!: UntypedFormGroup;

  emailError: boolean = false;
  nameError: boolean = false;
  password: boolean = false

  constructor(
    private http: HttpClient,
    public route: Router,
    private formBuilder: UntypedFormBuilder
  ) {}

  ngOnInit(): void {
    this.registro = this.formBuilder.group({
      NombreCompleto: [
        '',
        [
          Validators.minLength(5),
          Validators.maxLength(15),
          Validators.required,
        ],
      ],
      Email: [
        '',
        [
          Validators.email,
          Validators.required,
          Validators.pattern(/^([\w\.\-_]+)?\w+@[\w-_]+(\.\w+){1,}$/gim),
        ],
      ],
      Password: ['', [Validators.required, Validators.minLength(7), Validators.maxLength(15)]],
    });


  }

  onSubmit() {
    if (this.registro.invalid) {
      debugger;
      var name = this.registro.get('NombreCompleto')
      var email = this.registro.get('Email')
      var Password = this.registro.get('Password')
      if (name?.errors) {
        this.nameError = true;
      } else {
        this.nameError = false
      }
      if(email?.errors){
        this.emailError = true
      }else {
        this.emailError = false
      }
      if(Password?.errors){
        this.password = true
      } else {
        this.password = false
      }
      return;
    } else {
      this.registrarse();
    }
  }

  registrarse() {
    this.datos = this.registro.getRawValue();
    this.http
      .post('http://localhost:5243/api/Usuario/registro', {
        NombreCompleto: this.datos.NombreCompleto,
        Email: this.datos.Email,
        Password: this.datos.Password,
      })
      .subscribe((data: any) => {});
    this.route.navigate(['auth/login']);
  }
}

export interface datosRegistro {
  NombreCompleto: string;
  Email: string;
  Password: string;
}
