import { Component, inject } from '@angular/core';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms'
import { AuthService } from '../../auth/auth-service';
import { Auth_Token } from '../../data/intarfaces/auth.interface';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login-page',
  imports: [ ReactiveFormsModule],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.scss'
})

export class LoginPageComponent {

  authService = inject(AuthService)

  form = new FormGroup({
    username: new FormControl(null,Validators.required),
    password: new FormControl(null,Validators.required)
  })

  logtoken!: Auth_Token;

  constructor(private router: Router) {}

  onSubmit(){
    if(this.form.valid)
    {
      //@ts-ignore
      this.authService.login(this.form.value.username,this.form.value.password)
      .subscribe(res => {
        //console.log(res)
        this.logtoken = res;
        console.log(this.logtoken)
          if (this.logtoken != null)
          {
            if(this.logtoken["role"] == "student")
            {
              this.router.navigate(['/StudentTask'], { queryParams: { Studentid: this.logtoken["id"], Headerstr: "Личный кабинет студента", isTeacher: false} });
            }
            if(this.logtoken["role"] == "teacher")
            {
              this.router.navigate(['/TeacherDiscipline'], { queryParams: { Teacherid: this.logtoken["id"], Headers: "Личный кабинет преподавателя", isTeacher: true} });
            }
          }
      })
    }
  }
}
