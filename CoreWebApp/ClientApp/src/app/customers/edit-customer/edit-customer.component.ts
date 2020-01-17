import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Customers } from '../Customer';
import { CustomerService } from '../../Services/customer.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FileService } from '../../Services/file.service';

@Component({
  selector: 'app-edit-customer',
  templateUrl: './edit-customer.component.html',
  styleUrls: ['./edit-customer.component.css']
})
export class EditCustomerComponent implements OnInit {
  editForm: FormGroup;
  customer: Customers;
  public response: { 'dbPath': '', 'url': '' };
  isDeleteProfilepic: boolean = false;
  isChangeprofilepic = false;

  constructor(private formBuilder: FormBuilder, private CustService: CustomerService, private _router: Router, private _activatedRoute: ActivatedRoute, private fileService: FileService) {

  }

  ngOnInit() {
    this.editForm = this.formBuilder.group({
      cid: [''],//note: cid is parent form also and inside the cmnCustomerFields, up in update only using cid from editForm not from cmnCustomerFields 
      cmnCustomerFields: [],
      profilePicsrc: ['']
    });
    let Cid = Number(this._activatedRoute.snapshot.paramMap.get('cid'));
    this.CustService.GetCustomerById(Cid).subscribe(data => {
      this.editForm.setValue({
        cmnCustomerFields: data,
        cid: data.cid,
        profilePicsrc: data.profilePic
      });
    });
  }

  public GetProfileImgPath = (serverPath: string) => {
    return `http://localhost:65363/${serverPath}`;
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
    this.customer.profilePic = this.response.dbPath;
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


  changeProfilepic() {

    this.isChangeprofilepic = true;
    alert(this.isChangeprofilepic);
    return false;
  }

  deleteProfilepic(path: string) {
    debugger;
    this.fileService.DeleteProfilePic(path).subscribe(
      (data: any) => {
        // log the employee object after the post is completed
        console.log(data);
      },
      (error: any) => { console.log(error); }
    );

  }


  onReset() {
    this.editForm.reset();
  }

  public uploadFinished = (event) => {
    this.response = event;
  }
}
