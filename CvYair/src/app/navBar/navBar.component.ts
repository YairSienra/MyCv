
import { Component, HostListener, OnInit } from '@angular/core';
import { LoguearseService } from '../auth/pages/login/loguearse.service';

@Component({
  selector: 'app-navBar',
  templateUrl: './navBar.component.html',
  styleUrls: ['./navBar.component.scss']
})
export class NavBarComponent implements OnInit {



  title = 'mouse-hover'
  showImage0 : boolean;
  showImage : boolean;
  showImage2 : boolean;
  showImage3: boolean;
  showImage4: boolean

  constructor(public u : LoguearseService) {

    this.showImage0 = true
    this.showImage = false
    this.showImage2 = false
    this.showImage3 = false
    this.showImage4 = false


  }

  ngOnInit() {

  }


showPic(bool : boolean) {
  this.showImage = bool

}


picAlways(show : boolean) {
  if(this.showImage == true) {
      this.showImage0 = false


  }
}
toSobreMi() {
  document.getElementById('sobreMi')?.scrollIntoView({behavior: 'smooth'})
}
toEstudios() {
  document.getElementById('estudios')?.scrollIntoView({behavior: 'smooth'})
}
toExp() {
  document.getElementById('exp')?.scrollIntoView({behavior: 'smooth'})
}
toSkills() {
  document.getElementById('skills')?.scrollIntoView({behavior: 'smooth'})
}


navBar: boolean = false
@HostListener('window:scroll', ['$event']) onScroll() {
  if(window.screenY > 1){
    this.navBar = true
  } else {
    this.navBar = false
  }
}
}
