import { Component } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Anddes';
  token = sessionStorage.getItem('token');
  user = sessionStorage.getItem('user');
}
