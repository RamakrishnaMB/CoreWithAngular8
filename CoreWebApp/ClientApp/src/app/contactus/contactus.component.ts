import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ContactUs } from '../Models/ContactUs';

@Component({
  selector: 'app-contactus',
  templateUrl: './contactus.component.html',
  styleUrls: ['./contactus.component.css']
})
export class ContactusComponent implements OnInit {
  contactUsForm: FormGroup;
  contactUs: ContactUs;

  constructor(private formBuilder: FormBuilder, private _router: Router) { }

  ngOnInit() {
    this.contactUsForm = this.formBuilder.group({
      Name: ['', Validators.required],
      Email: ['', Validators.email, Validators.required],
      Message: ['', Validators.required, Validators.minLength(100)]
    });
  }

  get f() {
    return this.contactUsForm.controls;
  }
  onSubmit() {

    if (this.contactUsForm.invalid) {
      return;
    }

    this.contactUs = new ContactUs();
    this.contactUs.Name = this.contactUsForm.value.Name;
    this.contactUs.Email = this.contactUsForm.value.Email;
    this.contactUs.Message = this.contactUsForm.value.Message;

  }
}
