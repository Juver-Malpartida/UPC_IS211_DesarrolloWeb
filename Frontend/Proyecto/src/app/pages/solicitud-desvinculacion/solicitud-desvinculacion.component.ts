import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SolicitudceseService } from 'src/app/services/solicitudcese.service';

@Component({
  selector: 'app-solicitud-desvinculacion',
  templateUrl: './solicitud-desvinculacion.component.html',
  styleUrls: ['./solicitud-desvinculacion.component.css']
})
export class SolicitudDesvinculacionComponent implements OnInit {

  motivosCese = [
    {desc: "Termino de contrato"},
    {desc: "Rendimiento"},
    {desc: "Indisciplina"}
  ];
  isBuscarEmpleadosModalVisible: boolean = false;
  ShowBuscarEmpleadosModal() {
    this.isBuscarEmpleadosModalVisible = true;
  }

  solicitudForm = this.fb.group({
    empleado: this.fb.group({
      nombres: ['', Validators.required],
      areaId: [''],
      area: ['', Validators.required],
      cargoId: [''],
      cargo: ['', Validators.required],
      contratoId: [''],
      fechaInicio: ['', Validators.required],
      fechaFin: ['', Validators.required]
    }),
    solicitud: this.fb.group({
      numero: [''],
      estado: [''],
      fechaSolicitud: [new Date().toISOString().split('T')[0], Validators.required],
      fechaCese: ['', Validators.required],
      motivo: ['', Validators.required],
      archivos: [''],
      observacion: ['']
    })

  })

  constructor(private fb: FormBuilder, private readonly ss: SolicitudceseService, private router: Router) { }

  ngOnInit(): void {
  }

  onGuardar(): void {
    if(!this.solicitudForm.valid) {
      alert('Fomularion invalido');
      return;
    }

    const token = sessionStorage.getItem('token');
    const header = { Authorization: 'Bearer ' + token };  
    this.ss.postInsertSolicitud(this.solicitudForm.value, header).subscribe((rest: any) => {
      console.log(rest);
      if(rest.isSuccess) {
        alert("Solicitud de cese creada con ID: " + rest.data.idSolCese);

        this.router.navigateByUrl('/listarsolicitud', { skipLocationChange: false}).then( () => {
          this.router.navigate(['listarsolicitud']);
          window.location.reload();
        })

      } else {
        alert(rest.errorCode);
      }
    })
    console.log(this.solicitudForm);
  }
  onAnular(): void {

  }
  onEliminar(): void {

  }
  onCancelar(): void {

  }

  handleEmpleadoSelectedEvent(e: any): void {
    this.isBuscarEmpleadosModalVisible =  false;
    this.solicitudForm.get('empleado')?.get('nombres')?.setValue(e.nombreEmpleado);
    this.solicitudForm.get('empleado')?.get('areaId')?.setValue(e.idArea);
    this.solicitudForm.get('empleado')?.get('area')?.setValue(e.descArea);
    this.solicitudForm.get('empleado')?.get('cargoId')?.setValue(e.idCargo);
    this.solicitudForm.get('empleado')?.get('cargo')?.setValue(e.descCargo);
    this.solicitudForm.get('empleado')?.get('fechaInicio')?.setValue(e.fechaInicioCont.split('T')[0]);
    this.solicitudForm.get('empleado')?.get('fechaFin')?.setValue(e.fechaFinCont.split('T')[0]);
    this.solicitudForm.get('empleado')?.get('contratoId')?.setValue(e.idContrato);
  }
}
