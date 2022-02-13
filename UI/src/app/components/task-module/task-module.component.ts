import { HttpClient } from '@angular/common/http';
import { Component, Injectable, OnInit } from '@angular/core';
import { TaskService } from 'src/app/services/task.service';


@Component({
  selector: 'app-task-module',
  templateUrl: './task-module.component.html',
  styleUrls: ['./task-module.component.css']
})
@Injectable({
  providedIn: 'root'
})
export class TaskModuleComponent implements OnInit {

  tableData: any = [];
  constructor(private http: HttpClient, public restApi: TaskService) { }

  ngOnInit() {
    this.getAllTasks();
  }
  getAllTasks() {
    return this.restApi.getTasks().subscribe((data: {}) => {
      this.tableData = data;
    });
  }
   deleteTask(id) {
    if (window.confirm('Are you sure, you want to delete?')){
      this.restApi.deleteTask(id).subscribe(data => {
        this.getAllTasks()
      });
    }
  }
}
