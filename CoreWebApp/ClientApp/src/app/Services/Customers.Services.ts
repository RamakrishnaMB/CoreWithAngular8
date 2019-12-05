import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customers } from '../customers/Customer';
import { Observable } from 'rxjs';



export class CustomersService {
  
  //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //  http.get<Customers[]>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
  //    this.forecasts = result;
  //  }, error => console.error(error));
  //}


  //getAllAttaindees(SessionId: number): Observable<Attaindees[]> {
  //  debugger
  //  return this.http.get<Attaindees[]>(Constants.AllAttaindees + SessionId);
  //}
}
