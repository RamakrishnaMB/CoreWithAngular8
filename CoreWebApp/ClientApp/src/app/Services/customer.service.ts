import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Customers } from '../customers/Customer';
import { HttpClient } from '@angular/common/http';
import { tap, catchError } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';


@Injectable()
export class CustomerService {

  constructor(private http: HttpClient) { }


  GetCustomers(@Inject('BASE_URL') baseUrl: string): Observable<Customers[]> {
    return this.http.get<Customers[]>(baseUrl+'api/Customers').pipe(
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
