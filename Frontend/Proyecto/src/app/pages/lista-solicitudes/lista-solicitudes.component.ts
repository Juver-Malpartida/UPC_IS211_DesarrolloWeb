import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { SolicitudceseService} from 'src/app/services/solicitudcese.service';


@Component({
  selector: 'app-lista-solicitudes',
  templateUrl: './lista-solicitudes.component.html',
  styleUrls: ['./lista-solicitudes.component.css']
})
export class ListaSolicitudesComponent implements OnInit, OnDestroy {

  solicitudes = [];
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject<any>();

  constructor(private readonly em: SolicitudceseService ) { }

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }

  __getListSolicitud() {
     this.em.__getListSolicitud().subscribe((rest: any) => {
       this.solicitudes = rest.data;
       this.dtTrigger.next();
     })
}

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10
    };
    this.__getListSolicitud()
  }

}
