import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient, HttpEvent, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { retry, map } from 'rxjs/operators';



const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class ReportsService {
  //npm install file-saver –save  is installed to intitate download service from core web api.
  BaseURL: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.BaseURL = baseUrl;
  }


  DownloadFile(): Observable<any> {
    return this.http.post(this.BaseURL + 'api/ReportsPDF/downloadSamplePDF', httpOptions,
      { responseType: 'blob' }).pipe(retry(3),
        map(
          (res) => {
            var blob = new Blob([res as BlobPart], { type: 'application/pdf' })
            return blob;
          }));
  }


}
