import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from './../../../service/auth.service';
import { UserService } from '../../../service/user.service';
import {
  UntypedFormBuilder,
  UntypedFormControl,
  UntypedFormGroup,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
})
export class RegisterComponent implements OnInit {
  formNo: number = 0;
  userForm: UntypedFormGroup;
  companyForm: UntypedFormGroup;
  data: any = {};

  constructor(
    private router: Router,
    private authService: AuthService,
    private userService: UserService,
    private fb: UntypedFormBuilder
  ) {}

  ngOnInit(): void {
    this.userForm = this.fb.group({
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      email: [null, [Validators.required]],
      password: [null, [Validators.required]],
    });

    this.companyForm = this.fb.group({
      companyName: [null, [Validators.required]],
      addressLine1: [null, [Validators.required]],
      addressLine2: [null, [Validators.required]],
      city: [null, [Validators.required]],
      postalCode: [null, [Validators.required]],
      compEmail: [null, [Validators.required]],
      telephone: [null, Validators.required],
      website: [null, [Validators.required]],
    })
  }

  toLogin() {
    this.router.navigate(['/']);
  }

  submitLogin(): void {
    let data = {
      user: {
        firstName: this.userForm.get('firstName')?.value,
        lastName: this.userForm.get('lastName')?.value,
        email: this.userForm.get('email')?.value,
        phone: this.companyForm.get('compEmail')?.value,
        password: this.userForm.get('password')?.value,
      },
      company: {
        companyName: this.companyForm.get('companyName')?.value,
        addressLine1: this.companyForm.get('addressLine1')?.value,
        addressLine2: this.companyForm.get('addressLine2')?.value,
        city: this.companyForm.get('city')?.value,
        postalCode: this.companyForm.get('postalCode')?.value,
        companyEmail: this.companyForm.get('compEmail')?.value,
        companyContact: this.companyForm.get('telephone')?.value,
        website: this.companyForm.get('website')?.value,
      },
    };

    this.authService.register(data, "SuperAdmin").subscribe(
      (res: any) => {
        this.toLogin();
      }, (err: any) => {
        console.error(err);
      }
    )
  }

  next(): void {
    this.formNo = 1;
  }
}
