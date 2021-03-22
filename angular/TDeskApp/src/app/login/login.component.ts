import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { environment } from 'src/environments/environment';
import { ErrorLogin } from '../modal/error';

import { AuthSevice} from '../services/auth-sevice.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  validateForm!: FormGroup;
  validateFormOTP!: FormGroup;
  validateformVerifyOTP!: FormGroup;
  validateFormSignUp!: FormGroup;
  listErrorLogin: ErrorLogin [] = [];
  listErrorInputNumberphone: ErrorLogin [] = [];
  listErrorInputOtp: ErrorLogin [] = [];
  listErrorSignUp: ErrorLogin [] = [];
  phonenumber: string;
  @ViewChild('loginform') loginform: ElementRef;
  @ViewChild('formRegister') formRegister: ElementRef;
  @ViewChild('formOtp') formOtp: ElementRef;
  @ViewChild('formSignUp') formSignUp: ElementRef;
  constructor(
    private fb: FormBuilder, private authService: AuthSevice, private route: Router,
    private notification: NzNotificationService) {}

  ngOnInit(): void {
    if (this.authService.loginIn()){
      this.route.navigate(['welcome']);
    }
    this.validateForm = this.fb.group({
      phonenumber: [null, [Validators.required]],
      password: [null, [Validators.required]],
      remember: [true]
    });
    this.validateFormOTP = this.fb.group({
        phonenumberotp: [null, [Validators.required]]
    });
    this.validateformVerifyOTP = this.fb.group({
      otpcode: [null, [Validators.required]]
    });
    this.validateFormSignUp = this.fb.group({
      name: [null],
      email : [null],
      password : [null, [Validators.required]],
      phoneNumber : [null, [Validators.required]],
      smsOtpToken : [null, [Validators.required]],
      otpCode: [null, [Validators.required]],
      clientId: [null, [Validators.required]],
    });
  }

  submitForm(form: NgForm): void {
    // tslint:disable-next-line:forin
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
    }
    const phonenumber = form.value.phonenumber;
    const password = form.value.password;

    this.authService.login(phonenumber, password, environment.clientInfo.clientId, environment.clientInfo.clientSecret)
    .subscribe(res => {
      this.route.navigate(['welcome']);
    },
    error => {
      console.log('Lỗi đăng nhập', error.error.error);

      this.listErrorLogin = Object.values(error.error);
      // this.notification.create(
      //   'error',
      //   'Thất bại',
      //   'Xin vui lòng kiểm tra lại thông tin tài khoản');
    }
    );
  }
  showInputRegister(): void{
    this.loginform.nativeElement.style.display = 'none';
    console.log(this.loginform.nativeElement);
    this.formRegister.nativeElement.style.display = 'block';
  }
  // tslint:disable-next-line:typedef
  showBackLogin(){
    this.loginform.nativeElement.style.display = 'block';
    console.log(this.loginform.nativeElement);
    this.formRegister.nativeElement.style.display = 'none';
  }
  // tslint:disable-next-line:typedef
  showInputOtp(form: NgForm){
    // tslint:disable-next-line:forin
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
    }
    const phonenumberotp = form.value.phonenumberotp;
    this.authService.sentOtp(phonenumberotp).subscribe(res => {
      console.log('resOpt:', res);
      console.log('sdt', phonenumberotp);
      this.phonenumber = phonenumberotp;
      this.formRegister.nativeElement.style.display = 'none';
      this.formOtp.nativeElement.style.display = 'block';
    },
    error => {
      console.log('Lỗi sent Otp', error.error.error.validationErrors);
      this.listErrorInputNumberphone = Object.values(error.error.error.validationErrors);
    });
  }
  showSignUp(form: NgForm): void {
      const otpcode = form.value.otpcode;
      const phonenumber = this.phonenumber;
      this.authService.verifyOtp(phonenumber, otpcode).subscribe(res => {
        this.formOtp.nativeElement.style.display = 'none';
        this.formSignUp.nativeElement.style.display = 'block';
      },
      error => {
        console.log('Lỗi Otp Token', error.error.error );
        this.listErrorInputOtp = Object.values(error.error.error.validationErrors);
      });
  }
  signUp(form: NgForm): void{
    const name = form.value.otpcode;
    const email = form.value.email;
    const password = form.value.password;
    const phoneNumber = this.phonenumber;
    const smsOtpToken = localStorage.getItem('smstoken');
    const otpCode = '123456';
    const clientId = environment.clientInfo.clientId;
    this.authService.signUp(name, email, password, phoneNumber, smsOtpToken, otpCode, clientId).subscribe(res => {
      this.formSignUp.nativeElement.style.display = 'none';
      this.notification.create(
        'success',
        'Thành công',
        'Đăng ký thành công, quay lại trang đăng nhập'
    );
      this.loginform.nativeElement.style.display = 'block';
    },
    error => {
      this.listErrorSignUp = Object.values(error.error.error.validationErrors);
    });
  }
}
