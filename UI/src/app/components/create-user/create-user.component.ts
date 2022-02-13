import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {

  @Input() userDetails = { firstname: '', lastname:'',email: ''}
  constructor(
    public restApi: UserService, 
    public router: Router
  ) { }
  ngOnInit() { }
  addUser() {
    this.restApi.createUser(this.userDetails).subscribe((data: {}) => {
      this.router.navigate(['/user-component'])
    })
  }
}
