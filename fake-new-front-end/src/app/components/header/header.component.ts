import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IUser } from 'src/app/final-pages/user-page/IUser';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['../modal/modal.component.css', './header.component.css']
})
export class HeaderComponent implements OnInit {

  private URL = 'https://localhost:5001/api/v1/UserAuthentification?email=darabaneanucosmin81@gmail.com';
  //private URL = "/assets/user.json";
  request: any[];

  private headerDict = {
    'Content-Type': 'application/json',
    'Accept': 'application/json',
    'Access-Control-Allow-Headers': 'Content-Type',
    'Access-Control-Allow-Origin':  'https://localhost:5001/api/v1/',
  }

  private requestOptions = {                                                                                                                                                                                 
    headers: new HttpHeaders(this.headerDict), 
  };
  


  constructor(private http:HttpClient) {
    // this.http.get<IUser[]>(this.URL, this.requestOptions).subscribe(
    //   data =>{
    //     this.request = data;
    //     console.log(data);
    //   },
    //   () => {},
    //   () => this.update()
    // );
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

}
