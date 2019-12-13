import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Customers } from '../Customer';
import { CustomerService } from '../../Services/customer.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-customer',
  templateUrl: './edit-customer.component.html',
  styleUrls: ['./edit-customer.component.css']
})
export class EditCustomerComponent implements OnInit {
  editForm: FormGroup;
  customer: Customers;
  constructor(private formBuilder: FormBuilder, private CustService: CustomerService, private _router: Router) {

  }


  get f() {
    return this.editForm.controls;
  }

  ngOnInit() {
    this.editForm = this.formBuilder.group({
      // title: ['', Validators.required],
      cid:[''],
      name: ['', Validators.required],
      telephone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
      //  acceptTerms: [false, Validators.requiredTrue]
    });
    debugger;


    this.CustService.GetCustomerById(1006).subscribe(data => {
      this.editForm.setValue({
        name: data.name,
        telephone: data.telephone,
        email: data.email,
        cid: data.cid
      });
    });
  }

  onSubmit() {
    debugger;
    // stop here if form is invalid
    if (this.editForm.invalid) {
      return;
    }

    // display form values on success
    //  alert('SUCCESS!! :-)\n\n' + JSON.stringify(this.registerForm.value, null, 4));
    this.customer = new Customers();
    this.customer.name = this.editForm.value.cmnCustomerFields.name;
    this.customer.telephone = this.editForm.value.cmnCustomerFields.telephone;
    this.customer.email = this.editForm.value.cmnCustomerFields.email;
    //this.CustService.AddCustomer(this.customer).subscribe(
    //  (data: Customers) => {
    //    // log the employee object after the post is completed
    //    console.log(data);
    //    this.editForm.reset();
    //    this._router.navigate(['/customer']);
    //  },
    //  (error: any) => { console.log(error); }
    //);

  }

  onReset() {
    this.editForm.reset();
  }

}
