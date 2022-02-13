import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskService } from 'src/app/services/task.service';

@Component({
  selector: 'app-update-task',
  templateUrl: './update-task.component.html',
  styleUrls: ['./update-task.component.css']
})
export class UpdateTaskComponent implements OnInit {
  id = this.actRoute.snapshot.params['id'];
  taskData: any = {};
  constructor( public restApi: TaskService,
    public actRoute: ActivatedRoute,
    public router: Router) { }

  ngOnInit() {
    this.restApi.getTask(this.id).subscribe((data: {}) => {
      this.taskData = data;
    })
  }
  updatepTask() {
    if(window.confirm('Are you sure, you want to update?')){
      this.restApi.updateTask(this.taskData).subscribe(data => {
        this.router.navigate(['/task-component'])
      })
    }
  }
}
