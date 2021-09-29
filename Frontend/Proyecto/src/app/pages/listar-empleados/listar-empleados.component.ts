import { Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { Subject } from 'rxjs';
import { EmpleadoService } from 'src/app/services/empleado.service';

@Component({
  selector: 'app-listar-empleados',
  templateUrl: './listar-empleados.component.html',
  styleUrls: ['./listar-empleados.component.css']
})
export class ListarEmpleadosComponent implements OnInit, OnDestroy {

  empleados = [];
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject<any>();
  @Output() empleadoSelectedEvent = new EventEmitter();

  constructor(private readonly em: EmpleadoService) { }

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }

  __getListEmpleado() {
    this.em.__getListEmpleado().subscribe((rest: any) => {
      this.empleados = rest.data;
      this.dtTrigger.next();
    })
  }

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10
    };
    this.__getListEmpleado();
  }

  empleadoSelected(empleado: any) {
    this.empleadoSelectedEvent.emit(empleado);
  }
}
