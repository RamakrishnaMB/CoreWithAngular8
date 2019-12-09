import { Component, OnInit } from '@angular/core';
import { Customers } from './Customer';
import { Observable } from 'rxjs';
import { CustomerService } from '../Services/customer.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  lstCustomers: Customers[];
  constructor(private CustService: CustomerService) { }

  ngOnInit() {
    this.GetCustomers();
  }

  GetCustomers(): void {
    debugger;
    this.CustService.GetCustomers().subscribe(cust => this.lstCustomers = cust);
  }


}
