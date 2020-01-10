import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Customers } from '../Customer';
import { CustomerService } from '../../Services/customer.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})


export class AddCustomerComponent implements OnInit {
  registerForm: FormGroup;
  customer: Customers;
  public response: { 'dbPath': '' }; 

  constructor(private formBuilder: FormBuilder, private CustService: CustomerService, private _router: Router) {

  }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      cmnCustomerFields: []
    });
  }


  onSubmit() {
    debugger;
    // stop here if form is invalid
    if (this.registerForm.invalid) {
      return;
    }

    // display form values on success
    //  alert('SUCCESS!! :-)\n\n' + JSON.stringify(this.registerForm.value, null, 4));
    this.customer = new Customers();
    this.customer.name = this.registerForm.value.cmnCustomerFields.name;
    this.customer.telephone = this.registerForm.value.cmnCustomerFields.telephone;
    this.customer.email = this.registerForm.value.cmnCustomerFields.email;
    this.CustService.AddCustomer(this.customer).subscribe(
      (data: Customers) => {
        // log the employee object after the post is completed
        console.log(data);
        this.registerForm.reset();
        this._router.navigate(['/customer']);
      },
      (error: any) => { console.log(error); }
    );

  }

  onReset() {
    this.registerForm.reset();
  }


  public uploadFinished = (event) => {
    this.response = event;
  }

}
