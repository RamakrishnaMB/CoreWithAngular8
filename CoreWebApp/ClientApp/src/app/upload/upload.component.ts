import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HttpEventType, HttpClient } from '@angular/common/http';
import { FileService } from '../Services/file.service';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  public progress: number;
  public message: string;
  @Output() public onUploadFinished = new EventEmitter();

  constructor(private http: HttpClient, private fileService: FileService) { }

  ngOnInit() {
  }

  public uploadFile = (files) => {
    debugger;
    if (files.length === 0) {
      return;
    }

    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    this.fileService.UploadFile(formData).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress)
        this.progress = Math.round(100 * event.loaded / event.total);
      else if (event.type === HttpEventType.Response) {
        this.message = 'Upload success.';
        this.onUploadFinished.emit(event.body);
      }
    });

    //this.http.post('http://localhost:58272/api/UploadFiles/Upload', formData, { reportProgress: true, observe: 'events' })
    //  .subscribe(event => {
    //    if (event.type === HttpEventType.UploadProgress)
    //      this.progress = Math.round(100 * event.loaded / event.total);
    //    else if (event.type === HttpEventType.Response) {
    //      this.message = 'Upload success.';
    //      this.onUploadFinished.emit(event.body);
    //    }
    //  });
  }

}
