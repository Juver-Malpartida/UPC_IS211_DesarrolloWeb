import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EmpleadoService {

  constructor(private readonly http: HttpClient) { }

  __getListEmpleado() {
    return this.http.get('https://localhost:44309/api/Empleado/GetListEmpleado');
}

}
