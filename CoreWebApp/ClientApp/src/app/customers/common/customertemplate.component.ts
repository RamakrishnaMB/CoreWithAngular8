import { Component, forwardRef, OnDestroy, ChangeDetectionStrategy, OnInit } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR, FormBuilder, FormGroup, Validators, FormControl, NG_VALIDATORS } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Customers } from '../Customer';
@Component({
  selector: 'app-customertemplate',
  templateUrl: './customertemplate.component.html',
  styleUrls: ['./customertemplate.component.css'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => CustomertemplateComponent),
      multi: true
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => CustomertemplateComponent),
      multi: true,
    }
  ],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CustomertemplateComponent implements ControlValueAccessor, OnDestroy {

  form: FormGroup;
  subscriptions: Subscription[] = [];

  get value(): Customers {
    return this.form.value;
  }

  set value(value: Customers) {
    this.form.setValue(value);
    this.onChange(value);
    this.onTouched();
  }

  get titleControl() {
    return this.form.controls.title;
  }

  get emailControl() {
    return this.form.controls.email;
  }

  constructor(private formBuilder: FormBuilder) {
    this.form = this.formBuilder.group({
      title: ['', Validators.required],
      name: ['', Validators.required],
      telephone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      acceptTerms: [false, Validators.requiredTrue]
    });

    this.subscriptions.push(
      this.form.valueChanges.subscribe(value => {
        this.onChange(value);
        this.onTouched();
      })
    );
  }

  ngOnDestroy() {
    this.subscriptions.forEach(s => s.unsubscribe());
  }

  onChange: any = () => { };
  onTouched: any = () => { };

  registerOnChange(fn) {
    this.onChange = fn;
  }

  writeValue(value) {
    if (value) {
      this.value = value;
    }

    if (value === null) {
      this.form.reset();
    }
  }

  registerOnTouched(fn) {
    this.onTouched = fn;
  }

  validate(_: FormControl) {
    return this.form.valid ? null : { profile: { valid: false, }, };
  }

}
