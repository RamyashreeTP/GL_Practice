import { HttpClient } from '@angular/common/http';
import { Component, Injectable, OnInit } from '@angular/core';
import { ProjectService } from 'src/app/services/project.service';

@Component({
  selector: 'app-project-module',
  templateUrl: './project-module.component.html',
  styleUrls: ['./project-module.component.css']
})
@Injectable({
  providedIn: 'root'
})
export class ProjectModuleComponent implements OnInit {
  tableData: any = [];
  constructor(private http: HttpClient, public restApi: ProjectService) { }

  ngOnInit() {
    this.getAllProjects();
  }
  getAllProjects() {
    return this.restApi.getprojects().subscribe((data: {}) => {
      this.tableData = data;
    });
  }
   deleteUser(id) {
    if (window.confirm('Are you sure, you want to delete?')){
      this.restApi.deleteproject(id).subscribe(data => {
        this.getAllProjects()
      });
    }
  }
}
