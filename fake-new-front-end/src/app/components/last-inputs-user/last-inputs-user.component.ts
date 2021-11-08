import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-last-inputs-user',
  templateUrl: './last-inputs-user.component.html',
  styleUrls: ['./last-inputs-user.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class LastInputsUserComponent implements OnInit {

  constructor() {
   }
  ngOnInit(): void {
    let data: string[] =["Title", "Subject", "Content", "Date"];
    for (let index = 0; index < 10; index++) {
    document.getElementById("news-list").insertAdjacentHTML('beforeend',
      `<li class="list-element" id="item-no-`+ index +`">
      <p class="text title-text" id="title-no-`+ index +`"> ` + data[0] + ` </p>
      <p class="text" id="subject-no-`+ index +`"> ` + data[1] + ` </p>
      <p class="text" id="content-no-`+ index +`"> ` + data[2] + ` </p>
      <p class="text" id="date-no-`+ index +`"> ` + data[3] + ` </p>
      </li>`);
    }
  }
}
