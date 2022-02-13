import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Task } from '../components/Task-module/Task-module.component.types';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  apiURL = 'http://localhost:44368/api/v1/tasks';
  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }  

  getTasks() {
    return this.http.get<any>(this.apiURL + '/getAllTasks')
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }

  getTask(id) {
    return this.http.get<any>(this.apiURL + '/getTask/' + id)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }  

  createTask(Task) {
    return this.http.post<Task>(this.apiURL + '/createTask', JSON.stringify(Task), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }  

  updateTask(Task) {
    return this.http.put<Task>(this.apiURL + '/updateTask/', JSON.stringify(Task), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }

  deleteTask(id){
    return this.http.delete<Task>(this.apiURL + '/deleteTask/' + id)
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
}``