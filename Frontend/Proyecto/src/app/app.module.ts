import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { LoginComponent } from './Acceso/login/login.component';
import { NuevoComponent } from './Acceso/nuevo/nuevo.component';
import { FormsModule } from '@angular/forms';
import { SolicitudDesvinculacionComponent } from './pages/solicitud-desvinculacion/solicitud-desvinculacion.component';
import { ListarEmpleadosComponent } from './pages/listar-empleados/listar-empleados.component';
import { AsignacionServiciosComponent } from './pages/asignacion-servicios/asignacion-servicios.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NuevoComponent,
    SolicitudDesvinculacionComponent,
    ListarEmpleadosComponent,
    AsignacionServiciosComponent
  ],

  imports: [
    BrowserModule,    
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
