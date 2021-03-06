import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Injectable, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { retry, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
@Injectable({ providedIn: 'root' })
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  loading = false;
  submitted = false;
  apiURL = 'http://localhost:44368/api/v1/authentication';
  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private router: Router,
    private route: ActivatedRoute
  ) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  get f() { return this.form.controls; }
  ngOnInit() {
    this.form = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }
  onSubmit() {
    this.router.navigate(['/main-content']);
    /* this.submitted = true;
    if (this.form.invalid) {
      return;
    }
    this.loading = true;
    return this.http.get<any>(this.apiURL + '/login/uname=' + this.f.username.value + 'pwd=' + this.f.password.value)
      .pipe(
        retry(1),
        catchError(this.handleError))
      .subscribe({
        next: () => {
          this.router.navigate(['/main-content']);
        }
      }); */
  }
  handleError(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
  }
}
