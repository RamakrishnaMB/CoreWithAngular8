import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Customers } from '../customers/Customer';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { tap, catchError } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

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

  GetCustomerById(Cid: number): Observable<Customers> {
    return this.http.get<Customers>(this.BaseURL + 'api/Customers/GetCustomerbyIDAsync/' + Cid).pipe(catchError(this.handleError<Customers>('get customer error in service'))
    );
  }

  AddCustomer(Customer: Customers): Observable<Customers> {
    return this.http.post<Customers>(this.BaseURL + 'api/customers/AddCustomerAsync', Customer, httpOptions).pipe(
      tap((Customer: Customers) => console.log(`New customer added successfully! his id = ${Customer.cid}`)),
      catchError(this.handleError<Customers>('add customer error in service'))
    );
  }

  UpdateCustomer(customer: Customers): Observable<Customers> {
    return this.http.put<Customers>(this.BaseURL + 'api/customers/UpdateCustomerAsync', customer, httpOptions).pipe(
      tap((customer: Customers) => console.log(`Customer updated successfully! his id = ${customer.cid}`)),
      catchError(this.handleError<Customers>('UpdateCustomererror in service'))
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
