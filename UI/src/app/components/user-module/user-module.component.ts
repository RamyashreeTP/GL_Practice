import { HttpClient } from '@angular/common/http';
import { Component, Injectable, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-module',
  templateUrl: './user-module.component.html',
  styleUrls: ['./user-module.component.css']
})
@Injectable({
  providedIn: 'root'
})
export class UserModuleComponent implements OnInit {
  tableData: any = [];
  constructor(private http: HttpClient, public restApi: UserService) { }

  ngOnInit() {
    this.getAllUsers();
  }
  getAllUsers() {
    return this.restApi.getUsers().subscribe((data: {}) => {
      this.tableData = data;
    });
  }
   deleteUser(id) {
    if (window.confirm('Are you sure, you want to delete?')){
      this.restApi.deleteUser(id).subscribe(data => {
        this.getAllUsers()
      });
    }
  }
}
