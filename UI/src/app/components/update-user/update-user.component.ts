import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
  styleUrls: ['./update-user.component.css']
})
export class UpdateUserComponent implements OnInit {
  id = this.actRoute.snapshot.params['id'];
  userData: any = {};
  constructor( public restApi: UserService,
    public actRoute: ActivatedRoute,
    public router: Router) { }

  ngOnInit() {
    this.restApi.getUser(this.id).subscribe((data: {}) => {
      this.userData = data;
    })
  }
  updateUser() {
    if(window.confirm('Are you sure, you want to update?')){
      this.restApi.updateUser(this.userData).subscribe(data => {
        this.router.navigate(['/user-component'])
      })
    }
  }
}
