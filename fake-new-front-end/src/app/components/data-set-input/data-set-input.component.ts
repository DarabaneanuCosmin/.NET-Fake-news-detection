import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IInputData } from 'src/assets/IInputData';
import { Router } from '@angular/router';

@Component({
  selector: 'app-data-set-input',
  templateUrl: './data-set-input.component.html',
  styleUrls: ['./data-set-input.component.css']
})
export class DataSetInputComponent implements OnInit {
  private URL = 'http://localhost:5000/api/v1';
  public result = "";

  constructor(private http:HttpClient, private router:Router) { }
  ngOnInit(): void {
  }

  onClick(inputValue){
    const now = new Date();

    const headers = {
     'Content-Type': 'application/json',
     'Accept': 'application/json',
     'Access-Control-Allow-Headers': 'Content-Type',
     'Access-Control-Allow-Origin':  'http://localhost:5000/api/v1/'
   }
   console.log(now.getTime(), parseInt(localStorage.getItem("expiry")));
   if (now.getTime()> (parseInt(localStorage.getItem("expiry")) * 1000))
     this.router.navigate([""]);
  else{
   if(inputValue["title"] == "" || inputValue["text"] == "" || inputValue["subject"]== "" || inputValue["date"] == "")
   {
     this.open("incorrect_input");
   }else{
    this.http.post<Boolean>(this.URL + "/MachineLearning",{
      title: inputValue["title"],
      text: inputValue["text"],
      subject: inputValue["subject"],
      date_article: inputValue["date"]
    }, {headers}).subscribe( res =>
      {
        console.log("value: ")
        console.log(res.valueOf());
        if(res.valueOf())
          this.result = "Yes";
        else
          this.result = "No";
        if(localStorage.getItem("user") != null){
          console.log("urmeaza sa fie inserat articolul in BD");
          this.http.post<IInputData>(this.URL + "/UserData",{
            token: localStorage.getItem("user"),
            title: inputValue["title"],
            text: inputValue["text"],
            subject: inputValue["subject"],
            date_article: inputValue["date"],
            is_fake: true
          }, {headers, observe: 'response'}).subscribe(async res =>{
            if (res.status == 201){
              await new Promise(f => setTimeout(f, 1000));
              this.reloadComponent();
            }
            else if (res.status == 401)
              this.router.navigate([""]);
          });
        }
      });
   }
 }
}
 
 open(elem: string){
  let modal_t  = document.getElementById(elem)
  modal_t.classList.remove('hhidden')
  modal_t.classList.add('sshow');
}


reloadComponent() {
  let currentUrl = this.router.url;
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate([currentUrl]);
  }

}
