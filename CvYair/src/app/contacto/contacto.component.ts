import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MensajeComponent } from '../Home/mensaje/mensaje.component';

@Component({
  selector: 'app-contacto',
  templateUrl: './contacto.component.html',
  styleUrls: ['./contacto.component.scss']
})
export class ContactoComponent implements OnInit {

  comentario : {
    nombreCompleto : string,
    email : string,
    texto: string
  } = {
    nombreCompleto : "",
    email : "",
    texto : ""
  }


  constructor(
  public http : HttpClient,
  public d :MatDialog) { }

  ngOnInit() {


  }


  enviarComentario() {
    this.http.post('http://localhost:5243/api/Comentario/NuevoComentario', {
      NombreCompleto: this.comentario.nombreCompleto,
      Email: this.comentario.email,
      Texto: this.comentario.texto
    }).subscribe((data:any) => {
        if(data) {
          this.d.open(MensajeComponent)
        }
    })
  }

}

export interface Contacto{
  nombreCompleto :string,
  email: string,
  texto: string
}
