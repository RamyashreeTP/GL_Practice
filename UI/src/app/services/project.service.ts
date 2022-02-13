import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Project } from '../components/project-module/project-module.component.types';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  apiURL = 'http://localhost:44368/api/v1/projects';
  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }  

  getprojects() {
    return this.http.get<any>(this.apiURL + '/getAllProjects')
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }

  getproject(id) {
    return this.http.get<any>(this.apiURL + '/getProject/' + id)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }  

  createproject(project) {
    return this.http.post<Project>(this.apiURL + '/createProject', JSON.stringify(project), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }  

  updateproject(project) {
    return this.http.put<Project>(this.apiURL + '/updateProject/', JSON.stringify(project), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.handleError)
    )
  }

  deleteproject(id){
    return this.http.delete<Project>(this.apiURL + '/deleteProject/' + id)
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