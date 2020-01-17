import { Injectable, Inject } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpHeaders, HttpClient, HttpEvent, HttpRequest, HttpParams } from '@angular/common/http';
import { tap, catchError } from 'rxjs/operators';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};


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


  DeleteProfilePic(filePath: string): Observable<any> {
    debugger;

    //let params: HttpParams = new HttpParams();
    //params = params.set('FilePath', filePath);
    //const path = {
    //  FilePath: filePath
    //};
    //var body = JSON.stringify({ FilePath: filePath });
    //const params = new HttpParams()
    //  .set('FilePath', filePath)

    return this.http.post(this.BaseURL + 'api/UploadFiles/deleteProfilePic?FilePath=' + filePath, '', httpOptions).pipe(
      tap(_ => console.log("DeleteProfilePic called !!!")),
      catchError(err => {
        console.log(err);
        return of(null);
      })
    );

  }

}
