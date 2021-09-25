import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './Acceso/login/login.component';
import { NuevoComponent } from './Acceso/nuevo/nuevo.component';
import { AppComponent } from './app.component';
import { AsignacionServiciosComponent } from './pages/asignacion-servicios/asignacion-servicios.component';
import { ListarEmpleadosComponent } from './pages/listar-empleados/listar-empleados.component';
import { ResumenHojaRutaComponent } from './pages/resumen-hoja-ruta/resumen-hoja-ruta.component';
import { ListaSolicitudesComponent } from './pages/lista-solicitudes/lista-solicitudes.component';
import { SolicitudDesvinculacionComponent } from './pages/solicitud-desvinculacion/solicitud-desvinculacion.component';
import { AsignacionHerramComponent } from './pages/asignacion-herram/asignacion-herram.component';
import { LogoutComponent } from './Acceso/logout/logout.component';



const appRoutes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: "login", component: LoginComponent },
  { path: 'logout', component: LogoutComponent },
  { path: "nuevo", component: NuevoComponent, patMatch: "full" },
  { path: "solicitud", component: SolicitudDesvinculacionComponent },
  { path: "listarempleados", component: ListarEmpleadosComponent },
  { path: "listarsolicitud", component: ListaSolicitudesComponent },
  { path: "asignacionservicios/:id", component: AsignacionServiciosComponent},
  { path: "asignacionherram/:id" , component: AsignacionHerramComponent},
  { path: "resumenhojaruta/:id",component: ResumenHojaRutaComponent}
]

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
