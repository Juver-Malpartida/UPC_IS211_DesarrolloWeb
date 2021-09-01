import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './Acceso/login/login.component';
import { NuevoComponent } from './Acceso/nuevo/nuevo.component';
import { AppComponent } from './app.component';
import { ListarEmpleadosComponent } from './pages/listar-empleados/listar-empleados.component';
import { SolicitudDesvinculacionComponent } from './pages/solicitud-desvinculacion/solicitud-desvinculacion.component';


const appRoutes = [
  { path: "", component: AppComponent, patMatch: "full" },
  { path: "login", component: LoginComponent },
  { path: "nuevo", component: NuevoComponent, patMatch: "full" },
  { path: "solicitud", component: SolicitudDesvinculacionComponent },
  { path: "listarempleados", component: ListarEmpleadosComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
