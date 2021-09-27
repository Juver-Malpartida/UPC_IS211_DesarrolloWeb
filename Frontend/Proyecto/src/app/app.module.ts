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
import { ResumenHojaRutaComponent } from './pages/resumen-hoja-ruta/resumen-hoja-ruta.component';
import { ListaSolicitudesComponent} from './pages/lista-solicitudes/lista-solicitudes.component';
import { LogoutComponent } from './Acceso/logout/logout.component'
import { RecaptchaFormsModule, RecaptchaModule } from 'ng-recaptcha';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NuevoComponent,
    SolicitudDesvinculacionComponent,
    ListarEmpleadosComponent,
    AsignacionServiciosComponent,
    ResumenHojaRutaComponent,
    ListaSolicitudesComponent,
    LogoutComponent,
  ],

  imports: [
    BrowserModule,    
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    RecaptchaModule,
    RecaptchaFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
