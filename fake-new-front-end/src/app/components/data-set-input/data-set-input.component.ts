import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IInputData } from 'src/assets/IInputData';

@Component({
  selector: 'app-data-set-input',
  templateUrl: './data-set-input.component.html',
  styleUrls: ['./data-set-input.component.css']
})
export class DataSetInputComponent implements OnInit {
  private URL = 'http://localhost:5000/api/v1/UserData';

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
  }

  onClick(inputValue){

    const headers = {
     'Content-Type': 'application/json',
     'Accept': 'application/json',
     'Access-Control-Allow-Headers': 'Content-Type',
     'Access-Control-Allow-Origin':  'http://localhost:5000/api/v1/'
   }

   this.http.post<IInputData>(this.URL,{
     token: localStorage.getItem("user"),
     title: inputValue["title"],
     text: inputValue["text"],
     subject: inputValue["subject"],
     date_article: inputValue["date"]
   }, {headers}).subscribe( res => {
   });
 }
}
