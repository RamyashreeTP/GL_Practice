import { Component, NgModule, OnInit } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectModuleComponent } from '../project-module/project-module.component';
import { TaskModuleComponent } from '../task-module/task-module.component';
import { UserModuleComponent } from '../user-module/user-module.component';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})

export class SidebarComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
