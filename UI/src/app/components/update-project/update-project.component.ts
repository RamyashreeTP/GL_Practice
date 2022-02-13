import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProjectService } from 'src/app/services/project.service';

@Component({
  selector: 'app-update-project',
  templateUrl: './update-project.component.html',
  styleUrls: ['./update-project.component.css']
})
export class UpdateProjectComponent implements OnInit {
  id = this.actRoute.snapshot.params['id'];
  projectData: any = {};
  constructor( public restApi: ProjectService,
    public actRoute: ActivatedRoute,
    public router: Router) { }

  ngOnInit() {
    this.restApi.getproject(this.id).subscribe((data: {}) => {
      this.projectData = data;
    })
  }
  updatepProject() {
    if(window.confirm('Are you sure, you want to update?')){
      this.restApi.updateproject(this.projectData).subscribe(data => {
        this.router.navigate(['/project-component'])
      })
    }
  }
}
