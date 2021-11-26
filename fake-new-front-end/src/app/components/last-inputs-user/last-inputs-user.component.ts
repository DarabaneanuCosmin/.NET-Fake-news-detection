import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IData } from './IData';
import { waitForAsync } from '@angular/core/testing';

@Component({
  selector: 'app-last-inputs-user',
  templateUrl: './last-inputs-user.component.html',
  styleUrls: ['./last-inputs-user.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class LastInputsUserComponent implements OnInit {
  private URL = "/assets/history.json";
  request: any[];

  constructor(private http:HttpClient) {
    this.http.get<IData[]>(this.URL).subscribe(
      data =>{
        this.request = data;
        console.log(data);
      },
      () => {},
      () => this.test()
    );
   }

   test():void {
    for (let index = 0; index < this.request.length; index++) {
    document.getElementById("news-list").insertAdjacentHTML('beforeend',
      `<li class="list-element" id="item-no-`+ index +`">
      <p class="text title-text" id="title-no-`+ index +`"> ` + this.request[index].title + ` </p>
      <p class="text" id="subject-no-`+ index +`"> ` + this.request[index].subject + ` </p>
      <p class="text" id="content-no-`+ index +`"> ` + this.request[index].text + ` </p>
      <p class="text" id="date-no-`+ index +`"> ` + this.request[index].date + ` </p>
      </li>`);
    }
   }

  ngOnInit(): void {
  }
}
