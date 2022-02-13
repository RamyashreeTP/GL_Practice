import { Routes } from "@angular/router";
import { AddUserComponent } from "./components/add-user/add-user.component";
import { CreateProjectComponent } from "./components/create-project/create-project.component";
import { CreateTaskComponent } from "./components/create-task/create-task.component";
import { CreateUserComponent } from "./components/create-user/create-user.component";
import { LoginComponent } from "./components/login/login.component";
import { MainContentComponent } from "./components/main-content/main-content.component";
import { ProjectModuleComponent } from "./components/project-module/project-module.component";
import { TaskModuleComponent } from "./components/task-module/task-module.component";
import { UpdateProjectComponent } from "./components/update-project/update-project.component";
import { UpdateTaskComponent } from "./components/update-task/update-task.component";
import { UpdateUserComponent } from "./components/update-user/update-user.component";
import { UserModuleComponent } from "./components/user-module/user-module.component";
import { AuthGuard } from "./helpers/auth.guard";

export const routes: Routes = [
    { path: 'user-component', component: UserModuleComponent },
    { path: 'project-component', component: ProjectModuleComponent },
    { path: 'task-component', component: TaskModuleComponent },
    { path: 'add-user', component: AddUserComponent },
    { path: 'main-content', component: MainContentComponent },
    { path: 'login', component: LoginComponent},
    { path: 'update-user', component: UpdateUserComponent},
    { path: 'create-user', component: CreateUserComponent},
    { path: 'update-project', component: UpdateProjectComponent},
    { path: 'create-project', component: CreateProjectComponent},
    { path: 'update-task', component: UpdateTaskComponent},
    { path: 'create-task', component: CreateTaskComponent}
  ];