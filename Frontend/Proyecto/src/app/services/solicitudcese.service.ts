import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SolicitudceseService {

  constructor(private readonly http: HttpClient) { }

  __getListSolicitud() {
    return this.http.get('https://localhost:44309/api/Solicitud/GetSolicitudes');
  }

  postInsertSolicitud(data : any, headers : any) {
    console.log(data);
    const insertSolicitudData : any = {
      idContrato: data.empleado.contratoId,
      motivoCese: data.solicitud.motivo,
      estado:  'A',
      fechaCese: data.solicitud.fechaCese,
      activo: true,
      usuarioCrea: 'jmalpartida',
      usuarioModificacion: 'jmalpartida'
    };
    return this.http.post<any>('https://localhost:44309/api/Solicitud/InsertSolicitud', insertSolicitudData, {headers});
  }
}
