import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TaskService } from 'src/app/services/task.service';

@Component({
  selector: 'app-create-task',
  templateUrl: './create-task.component.html',
  styleUrls: ['./create-task.component.css']
})
export class CreateTaskComponent implements OnInit {
  @Input() taskDetails = { id:'',projectid: '',assignto:'',status:'', detail:'',createdon: ''}
  constructor(
    public restApi: TaskService, 
    public router: Router
  ) { }
  ngOnInit() { }
  addTask() {
    this.restApi.createTask(this.taskDetails).subscribe((data: {}) => {
      this.router.navigate(['/task-component'])
    })
  }
}
