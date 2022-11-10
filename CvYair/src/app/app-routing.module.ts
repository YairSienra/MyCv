import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './Home/Home.component';

import { SobremiComponent } from './Home/sobremi/sobremi.component';
import { NavBarComponent } from './navBar/navBar.component';


const routes: Routes = [
  {
    path : 'auth',
    loadChildren: () => import('./auth/auth.module').then( m => m.AuthModule)
  },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
