import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { LoguearseService } from '../auth/pages/login/loguearse.service';
import { Contacto, ContactoComponent } from '../contacto/contacto.component';


import { ServiceButtonService } from '../ServiceButton.service';


@Component({
  selector: 'app-Home',
  templateUrl: './Home.component.html',
  styleUrls: ['./Home.component.scss']
})
export class HomeComponent implements OnInit {




  url : string = "http://localhost:5243/api/Cv/";
  data : any

  constructor(private s : ServiceButtonService,
    public u : LoguearseService,
    public d : MatDialog,
    private http : HttpClient,

   ) {
  }

  ngOnInit() {
    this.obtenerCv()
  }


  obtenerCv() {
  this.s.http.get(this.url + "a5sd465as56d4a6s5456a").subscribe((data) => {
    this.data = data
  })
  }

  toSobreMi() {
    document.getElementById('sobreMi')?.scrollIntoView({behavior: 'smooth'})
  }

  openDialog() {
   this.d.open(ContactoComponent, {
    width : '500px',
    data : ''
   }).afterClosed().subscribe((data: boolean) => {
        if(data == false) {
          return
        }
   })
  }




}

