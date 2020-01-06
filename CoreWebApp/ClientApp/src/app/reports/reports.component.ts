import { Component, OnInit } from '@angular/core';
import { ReportsService } from '../Services/reports.service';
import { saveAs } from 'file-saver';


@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})


export class ReportsComponent implements OnInit {

  constructor(private DownloadService: ReportsService) { }

  ngOnInit() {
  }


  downloadSampleCSVFiles() {

    this.DownloadService.DownloadFile()
      .subscribe(
        success => {
          debugger;
          saveAs(success, "myfileName.pdf");
        },
        err => {
          alert("Server error while downloading file.");
        }
      );
  }

}
