import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['../modal/modal.component.css', './header.component.css']
})
export class HeaderComponent implements OnInit {

  private URL = 'https://localhost:5001/api/v1/UserAuthentification?email=darabaneanucosmin81@gmail.com';
  request: any[];
  email = localStorage.getItem("fakenewsemail");

  private headerDict = {
    'Content-Type': 'application/json',
    'Accept': 'application/json',
    'Access-Control-Allow-Headers': 'Content-Type',
    'Access-Control-Allow-Origin':  'https://localhost:5001/api/v1/',
  }

  constructor(private router:Router) {
   }

  ngOnInit(): void {
  }

  open(elem: string){
    let modal_t  = document.getElementById(elem)
    modal_t.classList.remove('hhidden')
    modal_t.classList.add('sshow');
}
  close(elem: string) {
      let modal_t  = document.getElementById(elem)
      modal_t.classList.remove('sshow')
      modal_t.classList.add('hhidden');
  }

  update() {
    if (this.request[0] != null){
      document.getElementById("user").innerHTML = "Logged in as " + this.request[0].email;
    }
  }

  move() {
    this.router.navigate(['/']);
  }

  logout(){
    localStorage.clear();
    document.getElementById("log-out").classList.add('hhidden');
    this.router.navigate(['/']);
  }
}
