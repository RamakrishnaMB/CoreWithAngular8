import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Customers } from '../Customer';
import { CustomerService } from '../../Services/customer.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css']
})
export class AddCustomerComponent implements OnInit {
  registerForm: FormGroup;
  submitted = false;
  customer: Customers;
  

  constructor(private formBuilder: FormBuilder, private CustService: CustomerService, private _router: Router) { }

  ngOnInit() {

    this.registerForm = this.formBuilder.group({
      title: ['', Validators.required],
      name: ['', Validators.required],
      telephone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      acceptTerms: [false, Validators.requiredTrue]
    });

  }

  // convenience getter for easy access to form fields
  get f() { return this.registerForm.controls; }

  onSubmit() {
    this.submitted = true;
    debugger;
    // stop here if form is invalid
    if (this.registerForm.invalid) {
      return;
    }

    // display form values on success
    //  alert('SUCCESS!! :-)\n\n' + JSON.stringify(this.registerForm.value, null, 4));
    this.customer = new Customers();
    this.customer.name = this.registerForm.value.name;
    this.customer.telephone = this.registerForm.value.telephone;
    this.customer.email = this.registerForm.value.email;
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
    this.submitted = false;
    this.registerForm.reset();
  }

}
