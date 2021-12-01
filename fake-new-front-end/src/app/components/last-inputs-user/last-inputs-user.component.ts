import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IUserData } from 'src/assets/IUserData';
import { waitForAsync } from '@angular/core/testing';
import { isThisTypeNode } from 'typescript';

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

  constructor(private http:HttpClient) {
    const headers = {
      'Content-Type': 'application/json',
      'Accept': 'application/json',
      'Access-Control-Allow-Headers': 'Content-Type',
      'Access-Control-Allow-Origin':  'http://localhost:5000/api/v1/'
    }

    this.http.get<IUserData>(this.URL, {headers}).subscribe(res =>{
      this.data = res.articles;
      this.error = res.error;
    },
    () => {},
    () => { this.test(); })
   }

   test():void {
    for (let index = 0; index < this.data.length; index++) {
    document.getElementById("news-list").insertAdjacentHTML('beforeend',
      `<li class="list-element" id="item-no-`+ index +`">
      <p class="text title-text" id="title-no-`+ index +`"> ` + this.data[index].title + ` </p>
      <p class="text" id="subject-no-`+ index +`"> ` + this.data[index].subject + ` </p>
      <p class="text" id="content-no-`+ index +`"> ` + this.data[index].text + ` </p>
      <p class="text" id="date-no-`+ index +`"> ` + this.data[index].date + ` </p>
      </li>`);
    }
   }

  ngOnInit(): void {
  }
}
