import { Component, OnInit } from '@angular/core';
import { EmpleadoService } from 'src/app/services/empleado.service';

@Component({
  selector: 'app-listar-empleados',
  templateUrl: './listar-empleados.component.html',
  styleUrls: ['./listar-empleados.component.css']
})
export class ListarEmpleadosComponent implements OnInit {

  empleado = [];

  constructor(private readonly em: EmpleadoService) { }

  __getListEmpleado() {
    this.em.__getListEmpleado().subscribe((rest: any) => {

      this.empleado = rest;
      console.log(rest)
    })
  }

  ngOnInit(): void {

    this.__getListEmpleado();
  }

}
