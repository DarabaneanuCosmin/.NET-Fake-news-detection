import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})
export class UserPageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    let profile = document.getElementById('profile');
    let login = document.getElementById('log-in');
    let signup = document.getElementById('sign-up');
    profile.style.display = 'none';
    login.style.display = 'none';
    signup.style.display = 'none';
  }

}
