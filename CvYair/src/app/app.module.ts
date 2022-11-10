import { NgModule } from '@angular/core';

import { HomeComponent } from './Home/Home.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import 'bootstrap/dist/css/bootstrap.min.css';
import { EstudiosComponent } from './Home/estudios/estudios.component';
import { ExperienciaComponent } from './Home/experiencia/experiencia.component';
import { SkillsComponent } from './Home/skills/skills.component';
import { SobremiComponent } from './Home/sobremi/sobremi.component';
import { NavBarComponent } from './navBar/navBar.component';
import { LazyLoadImageModule } from 'ng-lazyload-image';
import {HttpClientModule} from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations'
import { ContactoComponent } from './contacto/contacto.component';
import {MatDialogModule} from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MensajeComponent} from './Home/mensaje/mensaje.component';
import {VgCoreModule} from '@videogular/ngx-videogular/core';
import {VgControlsModule} from '@videogular/ngx-videogular/controls';
import {VgOverlayPlayModule} from '@videogular/ngx-videogular/overlay-play';
import {VgBufferingModule} from '@videogular/ngx-videogular/buffering';
import { ErrorLoginFailComponent } from './Dialogs/errorLoginFail/errorLoginFail.component';
//import {SingleMediaPlayer} from './single-media-player';

@NgModule({
  declarations: [
    AppComponent,
      HomeComponent,
      EstudiosComponent,
      ExperienciaComponent,
      SkillsComponent,
      SobremiComponent,
      NavBarComponent,
      ContactoComponent,
      MensajeComponent,
      ErrorLoginFailComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    LazyLoadImageModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    VgCoreModule,
    VgControlsModule,
    VgOverlayPlayModule,
    VgBufferingModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
