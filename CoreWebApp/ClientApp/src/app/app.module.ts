import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CustomersComponent } from './customers/customers.component';
import { CustomerService } from './Services/customer.service';
import { AddCustomerComponent } from './customers/add-customer/add-customer.component';

import { ReactiveFormsModule } from '@angular/forms';
import { CustomertemplateComponent } from './customers/common/customertemplate.component';
import { EditCustomerComponent } from './customers/edit-customer/edit-customer.component';
import { DeleteCustomerComponent } from './customers/delete-customer/delete-customer.component';
import { ContactusComponent } from './contactus/contactus.component';
import { ContactusService } from './Services/contactus.service';
import { ToastrNotificationComponent } from './toastr-notification/toastr-notification.component';
import { NotificationModule } from './toastr-notification/notification/notification.module';
import { ReportsComponent } from './reports/reports.component';
import { ReportsService } from './Services/reports.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    CustomersComponent,
    AddCustomerComponent,
    CustomertemplateComponent,
    EditCustomerComponent,
    DeleteCustomerComponent,
    ContactusComponent,
    ReportsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    NotificationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'customer', component: CustomersComponent },
      { path: 'addcustomer', component: AddCustomerComponent },
      { path: 'editcustomer/:cid', component: EditCustomerComponent },
      { path: 'deletecustomer/:cid', component: DeleteCustomerComponent },
      { path: 'contactus', component: ContactusComponent },
      { path: 'reports', component: ReportsComponent }
    ])
  ],
  providers: [CustomerService, ContactusService, ReportsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
