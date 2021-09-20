import { Component, OnInit } from '@angular/core';
import { SolicitudceseService} from 'src/app/services/solicitudcese.service';


@Component({
  selector: 'app-lista-solicitudes',
  templateUrl: './lista-solicitudes.component.html',
  styleUrls: ['./lista-solicitudes.component.css']
})
export class ListaSolicitudesComponent implements OnInit {

  solicitud = [];

  constructor(private readonly em: SolicitudceseService ) { }

  __getListSolicitud() {
     this.em.__getListSolicitud().subscribe((rest: any) => {
      
       this.solicitud = rest;
       console.log(rest)
     })
}

  ngOnInit(): void {
    this.__getListSolicitud()
  }

}
