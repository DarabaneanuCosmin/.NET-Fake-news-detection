import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    let home  = document.getElementById('home')
    let user = document.getElementById('user');
    home.style.display = 'none';
    user.style.display = 'none';
  }

}
