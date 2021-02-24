import {Component, OnInit} from '@angular/core';
import {IBooking} from '../../../shared/models/ibooking';
import {Router} from '@angular/router';

@Component({
  selector: 'app-edit-booking',
  templateUrl: './edit-booking.component.html',
  styleUrls: ['./edit-booking.component.scss']
})
export class EditBookingComponent implements OnInit {
  public booking: IBooking;

  constructor(private router: Router) {
  }

  ngOnInit(): void {
    this.booking = window.history.state.booking;
    if (!this.booking) {
      this.router.navigate(['']);
    }
  }
}
