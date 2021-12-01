import { HttpClient } from '@angular/common/http';
import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { ISingIn } from 'src/assets/singInInterface';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  private URL = 'http://localhost:5000/api/v1/signIn';

  constructor(private http:HttpClient,
    private router: Router) {
   }
   
  ngOnInit(): void {

  }

  onClick(inputValue){
    const headers = {
      'Content-Type': 'application/json',
      'Accept': 'application/json',
      'Access-Control-Allow-Headers': 'Content-Type',
      'Access-Control-Allow-Origin':  'http://localhost:5000/api/v1/'
    }
  
    this.http.post<ISingIn>(this.URL,{
      email_address: inputValue["email-address"],
      first_name: inputValue["first-name"],
      last_name: inputValue["last-name"],
      password: inputValue["password"]
    }, {headers}).subscribe( res => {
      if(!res.error){
        localStorage.setItem("user", res.token);
        this.router.navigate(['/profile']);
      }
      this.close_modal("sign_up");

    });
  }
  close_modal(elem: string) {
    let modal_t  = document.getElementById(elem)
    modal_t.classList.remove('sshow')
    modal_t.classList.add('hhidden');
}

}