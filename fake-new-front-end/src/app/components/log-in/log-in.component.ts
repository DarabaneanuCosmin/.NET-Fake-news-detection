import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ISingIn } from 'src/assets/singInInterface';
import jwt_decode from 'jwt-decode';
@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css'],
})
export class LogInComponent implements OnInit {
  private URL = 'http://localhost:5000/api/v1/LogIn';

  constructor(private http:HttpClient,
    private router: Router) { }

  ngOnInit(): void {}
  onClick(inputValue){
     const headers = {
      'Content-Type': 'application/json',
      'Accept': 'application/json',
      'Access-Control-Allow-Headers': 'Content-Type',
      'Access-Control-Allow-Origin':  'http://localhost:5000/api/v1/'
    }

    if(inputValue["email-address"] == "" || inputValue["password"] == "")
      {
        this.close_modal("log_in");
        this.open("incorrect_input");
    }else{
      const now = new Date();
      this.http.post<ISingIn>(this.URL,{
        email_address: inputValue["email-address"],
       encryptedPassword: inputValue["password"]
      }, {headers, observe: 'response'}).subscribe( res => {
        if(res.status == 200){
          console.log("user token");
          console.log(localStorage.getItem("user"));
          let tokenInfo = this.getDecodedAccessToken(res.body.token);
          localStorage.setItem("user", res.body.token);
          localStorage.setItem("fakenewsemail", inputValue["email-address"]);
          localStorage.setItem("expiry", tokenInfo.exp);
          console.log(localStorage.getItem("user"));

          this.router.navigate(['profile']);
        }
        else
        {
          this.open("incorrect_input");
        }
        this.close_modal("log_in");
      });
    }
  }
  
close_modal(elem: string) {
  let modal_t  = document.getElementById(elem)
  modal_t.classList.remove('sshow')
  modal_t.classList.add('hhidden');
}

open(elem: string){
  let modal_t  = document.getElementById(elem)
  modal_t.classList.remove('hhidden')
  modal_t.classList.add('sshow');
}

getDecodedAccessToken(token: string): any {
  try{
      return jwt_decode(token);
  }
  catch(Error){
      return null;
  }
}

}
