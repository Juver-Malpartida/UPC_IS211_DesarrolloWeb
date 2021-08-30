import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './Acceso/login/login.component';
import { NuevoComponent } from './Acceso/nuevo/nuevo.component';
import { AppComponent } from './app.component';


const appRoutes =[
  { path: "", component: AppComponent,patMatch:"full"},
  { path: "login", component: LoginComponent},
  { path: "nuevo", component: NuevoComponent,patMatch:"full"},
]

@NgModule({
  imports:[RouterModule.forRoot(appRoutes)],
  exports:[RouterModule]
  })
  export class AppRoutingModule{}
