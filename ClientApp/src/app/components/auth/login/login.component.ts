import { Component, OnInit } from '@angular/core';
import {
  UntypedFormBuilder,
  UntypedFormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from './../../../service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent implements OnInit {
  validationForm: UntypedFormGroup;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb: UntypedFormBuilder,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.validationForm = this.fb.group({
      email: [
        '',
        [
          Validators.required,
          Validators.email,
          Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$'),
        ],
      ],
      password: ['', [Validators.required]],
    });
  }

  submitLogin(): void {
    let credentiols: any = {
      email: this.validationForm.get('email')?.value,
      password: this.validationForm.get('password')?.value,
    };

    this.authService.login(credentiols).subscribe(
      (res: any) => {
        localStorage.setItem("token", res.Token);
        this.router.navigate(['/home']);
      },
      (err: any) => {
        console.error(err);
      }
    );
  }
}
