import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { User } from '../components/user-module/user-module.component.types';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  apiURL = 'http://localhost:44368/api/v1/users';
  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }  

  getUsers() {
    return this.http.get<any>(this.apiURL + '/getAllUsers')
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }

  getUser(id) {
    return this.http.get<any>(this.apiURL + '/getUser/' + id)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }  

  createUser(user) {
    return this.http.post<User>(this.apiURL + '/createuser', JSON.stringify(user), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }  

  updateUser(user) {
    return this.http.put<User>(this.apiURL + '/updateUser/', JSON.stringify(user), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }

  deleteUser(id){
    return this.http.delete<User>(this.apiURL + '/deleteUser/' + id)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }
  // Error handling 
  handleError(error) {
     let errorMessage = '';
     if(error.error instanceof ErrorEvent) {
       errorMessage = error.error.message;
     } else {
       errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
     }
     window.alert(errorMessage);
     return throwError(errorMessage);
  }
}