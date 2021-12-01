import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ISingIn } from 'src/assets/singInInterface';


@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css'],
})
export class LogInComponent implements OnInit {
  private URL = 'https://localhost:5001/api/v1/UserAuthentification';

  constructor(private http:HttpClient,
    private router: Router) { }

  ngOnInit(): void {}
  onClick(inputValue){
     const headers = {
      'Content-Type': 'application/json',
      'Accept': 'application/json',
      'Access-Control-Allow-Headers': 'Content-Type',
      'Access-Control-Allow-Origin':  'https://localhost:5001/api/v1/'
    }
  
    this.http.post<ISingIn>(this.URL,{
      email: inputValue["email-address"],
      password: inputValue["password"]
    }, {headers}).subscribe( res => {
      if(res.response == "The user has been logged in."){
        localStorage.setItem("user", res.token);
        this.router.navigate(['/profile']);
      }
      this.close_modal("log_in");
      console.log("Wrong user.");

    });
  }
  
  close_modal(elem: string) {
    let modal_t  = document.getElementById(elem)
    modal_t.classList.remove('sshow')
    modal_t.classList.add('hhidden');
}

}
