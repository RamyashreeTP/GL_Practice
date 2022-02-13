import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProjectService } from 'src/app/services/project.service';

@Component({
  selector: 'app-create-project',
  templateUrl: './create-project.component.html',
  styleUrls: ['./create-project.component.css']
})
export class CreateProjectComponent implements OnInit {

  @Input() projectDetails = { id:'',name: '', detail:'',createdon: ''}
  constructor(
    public restApi: ProjectService, 
    public router: Router
  ) { }
  ngOnInit() { }
  addProject() {
    this.restApi.createproject(this.projectDetails).subscribe((data: {}) => {
      this.router.navigate(['/project-component'])
    })
  }
}
