import { Component, OnInit } from '@angular/core';
import { FormBuilder,Validators } from '@angular/forms';

@Component({
  selector: 'app-asignacion-herram',
  templateUrl: './asignacion-herram.component.html',
  styleUrls: ['./asignacion-herram.component.css']
})
export class AsignacionHerramComponent implements OnInit {
  soliHerramientasForm = this.fb.group({

      codigo: ['', Validators.required],
      descripcion: ['', Validators.required],
      montoactual: ['', Validators.required],
      estado: ['', Validators.required],
      penalidad: ['', Validators.required],
      total: ['', Validators.required]
    })
  

  constructor(private fb: FormBuilder) { }

 
  ngOnInit(): void {
  }

  onGuardar(): void {

  }
  onAnular(): void {

  }
  onEliminar(): void {

  }
  onCancelar(): void {

  }

}
