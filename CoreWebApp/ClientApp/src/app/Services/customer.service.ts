import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Customers } from '../customers/Customer';
import { HttpClient } from '@angular/common/http';
import { tap, catchError } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';


@Injectable()
export class CustomerService {

  BaseURL: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.BaseURL = baseUrl;
  }


  GetCustomers(): Observable<Customers[]> {
    debugger;
    return this.http.get<Customers[]>(this.BaseURL + 'api/Customers/GetDetails').pipe(
      tap(_ => console.log("fetched customer data from service")), catchError(this.handleError<Customers[]>('GetCustomers', []))
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