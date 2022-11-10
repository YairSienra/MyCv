import { animate, style, transition, trigger } from '@angular/animations';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-experiencia',
  templateUrl: './experiencia.component.html',
  styleUrls: ['./experiencia.component.scss'],
  animations :[
    trigger('fade', [
     // state(),
      transition('click => *', [
        style({ opacity:0}),
        animate(2000)
      ])
    ])
  ]
})

export class ExperienciaComponent implements OnInit {

  @Input('datos') data : any

  constructor() { }

  ngOnInit() {
  }

}
