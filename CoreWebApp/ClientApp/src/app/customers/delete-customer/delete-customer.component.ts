import { Component, OnInit } from '@angular/core';
import { Customers } from '../Customer';
import { CustomerService } from '../../Services/customer.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-delete-customer',
  templateUrl: './delete-customer.component.html',
  styleUrls: ['./delete-customer.component.css']
})
export class DeleteCustomerComponent implements OnInit {
  customer: Customers;
  Cid: number;
  constructor(private _CustomerService: CustomerService, private _activatedRoute: ActivatedRoute, private _router: Router) { }

  ngOnInit() {
    this.Cid = Number(this._activatedRoute.snapshot.paramMap.get("cid"));
    this._CustomerService.GetCustomerById(this.Cid).subscribe(data => this.customer = data);
  }

  deleteCustomer(CustID: number) {
    this._CustomerService.DeleteCustomer(CustID).subscribe(
      () => {
        console.log(`Customer with ID = ${CustID} deleted.`);
        this._router.navigate(['/customer']);
      }
      , (err) => console.log(err)
    );
  }
}
