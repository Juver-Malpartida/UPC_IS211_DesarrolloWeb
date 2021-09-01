import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './Acceso/login/login.component';
import { NuevoComponent } from './Acceso/nuevo/nuevo.component';
import { AppComponent } from './app.component';
import { AsignacionServiciosComponent } from './pages/asignacion-servicios/asignacion-servicios.component';
import { ListarEmpleadosComponent } from './pages/listar-empleados/listar-empleados.component';
import { ResumenHojaRutaComponent } from './pages/resumen-hoja-ruta/resumen-hoja-ruta.component';
import { SolicitudDesvinculacionComponent } from './pages/solicitud-desvinculacion/solicitud-desvinculacion.component';


const appRoutes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: "login", component: LoginComponent },
  { path: "nuevo", component: NuevoComponent, patMatch: "full" },
  { path: "solicitud", component: SolicitudDesvinculacionComponent },
  { path: "listarempleados", component: ListarEmpleadosComponent },
  { path: "asignacionservicios/:id", component: AsignacionServiciosComponent},
  { path: "resumenhojaruta/:id",component: ResumenHojaRutaComponent}
]

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
