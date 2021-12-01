import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})
export class UserPageComponent implements OnInit {

  constructor() {
 }

  ngOnInit(): void {
    let login = document.getElementById('log-in');
    let signup = document.getElementById('sign-up');
    login.classList.add("hide-btn");
    signup.classList.add("hide-btn");
  }

}
