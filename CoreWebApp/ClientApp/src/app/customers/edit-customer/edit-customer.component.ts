import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Customers } from '../Customer';
import { CustomerService } from '../../Services/customer.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-customer',
  templateUrl: './edit-customer.component.html',
  styleUrls: ['./edit-customer.component.css']
})
export class EditCustomerComponent implements OnInit {
  editForm: FormGroup;
  customer: Customers;

  constructor(private formBuilder: FormBuilder, private CustService: CustomerService, private _router: Router, private _activatedRoute: ActivatedRoute) {

  }

  ngOnInit() {
    this.editForm = this.formBuilder.group({
      cid: [''],//note: cid is parent form also and inside the cmnCustomerFields, up in update only using cid from editForm not from cmnCustomerFields 
      cmnCustomerFields: []
    });
    debugger;
    let Cid = Number(this._activatedRoute.snapshot.paramMap.get('cid'));
    this.CustService.GetCustomerById(Cid).subscribe(data => {
      this.editForm.setValue({
        cmnCustomerFields: data,
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
    this.customer.cid = this.editForm.value.cid;
    this.customer.name = this.editForm.value.cmnCustomerFields.name;
    this.customer.telephone = this.editForm.value.cmnCustomerFields.telephone;
    this.customer.email = this.editForm.value.cmnCustomerFields.email;
    this.CustService.UpdateCustomer(this.customer).subscribe(
      (data: Customers) => {
        // log the employee object after the post is completed
        console.log(data);
        this.editForm.reset();
        this._router.navigate(['/customer']);
      },
      (error: any) => { console.log(error); }
    );

  }

  onReset() {
    this.editForm.reset();
  }

}
