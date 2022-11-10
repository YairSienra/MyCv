import { animate, style, transition, trigger } from '@angular/animations';
import { Component, Input, OnInit } from '@angular/core';




@Component({
  selector: 'app-sobremi',
  templateUrl: './sobremi.component.html',
  styleUrls: ['./sobremi.component.scss'],
  animations :[
    trigger('fade', [
     // state(),
      transition('void => *', [
        style({ opacity:0}),
        animate(2000)
      ])
    ])
  ]
})
export class SobremiComponent implements OnInit {

  @Input('datos') data: any


  constructor() {}
 

  ngOnInit() {

  }


}
