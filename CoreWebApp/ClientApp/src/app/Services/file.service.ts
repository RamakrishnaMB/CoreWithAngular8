import { Injectable, Inject } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpHeaders, HttpClient, HttpEvent, HttpRequest } from '@angular/common/http';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class FileService {
  BaseURL: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.BaseURL = baseUrl;
  }

  UploadFile(formData: FormData): Observable<HttpEvent<any>> {
    return this.http.post(this.BaseURL + '/api/UploadFiles/Upload', formData, { reportProgress: true, observe: 'events' })
      .pipe(
        tap(_ => console.log("profile pic upload called !!!")),
        catchError(err => {
          console.log(err);
          return of(null);
        })
      );
  }

}
