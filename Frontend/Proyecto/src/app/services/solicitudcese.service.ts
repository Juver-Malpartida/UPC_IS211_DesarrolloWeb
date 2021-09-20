import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SolicitudceseService {

  constructor(private readonly http: HttpClient) { }

  __getListSolicitud() {
    return this.http.get('https://localhost:44309/api/Solicitud/GetListSolicitud');
}
}
