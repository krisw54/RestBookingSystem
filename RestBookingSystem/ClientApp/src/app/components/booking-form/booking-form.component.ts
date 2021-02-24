import {Component, Input, OnDestroy, OnInit} from '@angular/core';
import {AbstractControl, FormControl, FormGroup, Validators} from '@angular/forms';
import {ApiService} from '../../../shared/services/api.service';
import {Router} from '@angular/router';
import {IBooking} from '../../../shared/models/ibooking';
import {Subscription} from 'rxjs';

@Component({
  selector: 'app-booking-form',
  templateUrl: './booking-form.component.html',
  styleUrls: ['./booking-form.component.scss']
})
export class BookingFormComponent implements OnInit, OnDestroy {
  @Input() public isEditing = false;
  @Input() public editingData: IBooking = null;
  public errorMessage: string = null;
  private subscriptions: Subscription = new Subscription();

  public bookingData = new FormGroup({
    tableNo: new FormControl('', [Validators.required, Validators.min(1)]),
    name: new FormControl('', [Validators.required, Validators.minLength(3)]),
    number: new FormControl('', [Validators.required, Validators.minLength(10)]),
    diners: new FormControl('', [Validators.required, Validators.min(1)]),
    dateTime: new FormControl('', [Validators.required])
  });

  constructor(private apiService: ApiService,
              private router: Router) {
  }

  public get tableNo(): AbstractControl {
    return this.bookingData.get('tableNo');
  }

  public get name(): AbstractControl {
    return this.bookingData.get('name');
  }

  public get contactNumber(): AbstractControl {
    return this.bookingData.get('number');
  }

  public get diners(): AbstractControl {
    return this.bookingData.get('diners');
  }

  public get dateTime(): AbstractControl {
    return this.bookingData.get('dateTime');
  }

  ngOnInit(): void {
    if (this.isEditing) {
      this.bookingData.controls.tableNo.setValue(this.editingData.tableNumber);
      this.bookingData.controls.name.setValue(this.editingData.contactName);
      this.bookingData.controls.number.setValue(this.editingData.contactNumber);
      this.bookingData.controls.diners.setValue(this.editingData.numberOfPeople);
      this.bookingData.controls.dateTime.setValue(new Date(this.editingData.bookingTime).toISOString().slice(0, 16));
    }
  }

  createBooking(): void {
    const booking = this.bookingData.getRawValue();
    if (this.isEditing) {
      this.subscriptions.add(this.apiService.editBooking(booking, this.editingData.bookingId)
        .subscribe(() => {
            this.router.navigate(['/']);
          }, error =>
            this.errorMessage = error.error
        ));
    } else {
      this.subscriptions.add(this.apiService.createBooking(booking)
        .subscribe(() => {
            this.router.navigate(['/']);
          }, error => this.errorMessage = error.error
        ));
    }
  }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }
}
