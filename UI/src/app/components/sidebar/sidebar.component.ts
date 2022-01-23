import { Component, NgModule, OnInit } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectModuleComponent } from '../project-module/project-module.component';
import { TaskModuleComponent } from '../task-module/task-module.component';
import { UserModuleComponent } from '../user-module/user-module.component';
const routes: Routes = [
  { path: 'user-component', component: UserModuleComponent },
  { path: 'project-component', component: ProjectModuleComponent },
  { path: 'task-component', component: TaskModuleComponent },
];
@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class SidebarComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
