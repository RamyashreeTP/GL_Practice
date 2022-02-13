import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { MainContentComponent } from './components/main-content/main-content.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { UserModuleComponent } from './components/user-module/user-module.component';
import { TaskModuleComponent } from './components/task-module/task-module.component';
import { ProjectModuleComponent } from './components/project-module/project-module.component';
import { RouterModule } from '@angular/router';
import {routes} from './app.routes';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddUserComponent } from './components/add-user/add-user.component';
import { CreateUserComponent } from './components/create-user/create-user.component';
import { UpdateUserComponent } from './components/update-user/update-user.component';
import { CreateProjectComponent } from './components/create-project/create-project.component';
import { UpdateProjectComponent } from './components/update-project/update-project.component';
import { UpdateTaskComponent } from './components/update-task/update-task.component';
import { CreateTaskComponent } from './components/create-task/create-task.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    MainContentComponent,
    SidebarComponent,
    UserModuleComponent,
    TaskModuleComponent,
    ProjectModuleComponent,
    AddUserComponent,
    CreateUserComponent,
    UpdateUserComponent,
    CreateProjectComponent,
    UpdateProjectComponent,
    UpdateTaskComponent,
    CreateTaskComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    HttpClientModule,
    FormsModule, ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
  
})
export class AppModule { }
