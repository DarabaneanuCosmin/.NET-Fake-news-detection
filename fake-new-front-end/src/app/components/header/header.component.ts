import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['../modal/modal.component.css', './header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor() { }

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

}
