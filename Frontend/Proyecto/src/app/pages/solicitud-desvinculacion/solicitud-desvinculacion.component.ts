import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-solicitud-desvinculacion',
  templateUrl: './solicitud-desvinculacion.component.html',
  styleUrls: ['./solicitud-desvinculacion.component.css']
})
export class SolicitudDesvinculacionComponent implements OnInit {

  solicitudForm = this.fb.group({
    empleado: this.fb.group({
      nombres: ['', Validators.required],
      area: ['', Validators.required],
      cargo: ['', Validators.required],
      fechaInicio: ['', Validators.required],
      fechaFin: ['', Validators.required]
    }),
    solicitud: this.fb.group({
      numero: ['SC-00234', Validators.required],
      estado: [''],
      fechaSolicitud: [''],
      fechaCese: [''],
      motivo: [''],
      archivos: [''],
      observacion: ['']
    })

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
