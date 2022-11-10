import { animate, style, transition, trigger } from '@angular/animations';
import { Component, Input } from '@angular/core';
import { LoguearseService } from './auth/pages/login/loguearse.service';
import { ServiceButtonService } from './ServiceButton.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
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
export class AppComponent {
  title = 'CvYair';

  @Input('data') data :any

  constructor(public u : LoguearseService) {

  }

  ngOnInit() {


  }
}
