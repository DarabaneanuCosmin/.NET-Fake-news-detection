import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IUserData } from 'src/assets/IUserData';
import { Router } from '@angular/router';


@Component({
  selector: 'app-last-inputs-user',
  templateUrl: './last-inputs-user.component.html',
  styleUrls: ['./last-inputs-user.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class LastInputsUserComponent implements OnInit {
  private URL = "http://localhost:5000/api/v1/UserData?token=" + localStorage.getItem("user");
  data: any[];
  error: string;

  constructor(private http:HttpClient,  private router: Router) {
    const headers = {
      'Content-Type': 'application/json',
      'Accept': 'application/json',
      'Access-Control-Allow-Headers': 'Content-Type',
      'Access-Control-Allow-Origin':  'http://localhost:5000/api/v1/'
    }
    const now = new Date();

    if (now.getTime()> (parseInt(localStorage.getItem("expiry")) * 1000))
      this.router.navigate([""]);
    else{
      console.log("intru sa fac call la url");
      console.log(this.URL + localStorage.getItem("user"));
      this.http.get<IUserData>(this.URL + localStorage.getItem("user"), {headers}).subscribe(res =>{
  
      this.data = res.articles;
      this.error = res.error;
    },
    () => {},
    () => {
      console.log("incep printarea");
      this.test(); })
  }
   }

   test():void {
    let answer ="";
    for (let index = 0; index < this.data.length; index++) {
    console.log(this.data[index].is_fake);
      if (this.data[index].is_fake)
        answer = "Yes";
      else
        answer = "No";
    document.getElementById("news-list").insertAdjacentHTML('beforeend',
      `<li class="list-element" id="item-no-`+ index +`">
      <p class="text title-text" id="title-no-`+ index +`"> ` + this.data[index].title + ` </p>
      <p class="text" id="subject-no-`+ index +`"> ` + this.data[index].subject + ` </p>
      <p class="text" id="content-no-`+ index +`"> ` + this.data[index].text + ` </p>
      <p class="text" id="date-no-`+ index +`"> ` + this.data[index].date_article + ` </p>
      <p class="text-title" id="response-no-`+ index +`"> Answer: ` + answer + ` </p>
      </li>`);
    }
   }

  ngOnInit(): void {
  }
}
