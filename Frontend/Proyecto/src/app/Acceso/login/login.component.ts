import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent {

  constructor(private route:Router, private fb: FormBuilder, private readonly us: UserService) {}

  loginForm = this.fb.group({
    loginusuario: ['', Validators.required],
    passwordusuario: ['', Validators.required]
  });

  login(data: any) {
    this.us.login(data).subscribe((resp: any) => {
      if(resp.isSuccess) {
        sessionStorage.setItem('token',  resp.data.token);
        sessionStorage.setItem('user', resp.data.nombres);
        this.route.navigateByUrl('/listarsolicitud', { skipLocationChange: false}).then(() => {
          this.route.navigate(['listarsolicitud']);
          window.location.reload();
        })
      } else {
        alert("Usuario o contraseña incorrectos");
      }
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      this.login(this.loginForm.value);
    }
    
  }
}