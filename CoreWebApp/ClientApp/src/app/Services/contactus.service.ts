import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { ContactUs } from '../Models/ContactUs';
import { Observable, of } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class ContactusService {

  BaseURL: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.BaseURL = baseUrl;
  }

  ContactUs(contactus: ContactUs): Observable<ContactUs> {
    return this.http.post<ContactUs>(this.BaseURL + 'api/ContactUs/ContactUSEmail', contactus, httpOptions).pipe(
      tap((contactus: ContactUs) => console.log(`contact submitted to webservice`)), catchError(this.handleError<ContactUs>('error in contact us service'))
    );
  }

  //general methods to reuse in functions
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
