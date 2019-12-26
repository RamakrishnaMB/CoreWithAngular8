import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ToastrNotificationComponent } from '../toastr-notification.component';
import { ToastrNotificationService } from '../../Services/toastr-notification.service';    



@NgModule({
  declarations: [ToastrNotificationComponent],
  imports: [
    BrowserModule
  ],
  exports: [
    ToastrNotificationComponent
  ],
  providers: [
    ToastrNotificationService
  ]
})
export class NotificationModule { }
