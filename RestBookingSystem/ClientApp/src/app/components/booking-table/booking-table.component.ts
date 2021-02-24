import {Component, OnDestroy, OnInit} from '@angular/core';
import {ApiService} from '../../../shared/services/api.service';
import {IBooking} from '../../../shared/models/ibooking';
import {Subscription} from 'rxjs';

@Component({
  selector: 'app-booking-table',
  templateUrl: './booking-table.component.html',
  styleUrls: ['./booking-table.component.scss']
})
export class BookingTableComponent implements OnInit, OnDestroy {
  public bookings: Array<IBooking> = [];
  private subscriptions: Subscription = new Subscription();

  constructor(private apiService: ApiService) {
  }

  ngOnInit(): void {
    this.subscriptions.add(this.apiService.getAllBookings().subscribe((bookings) => {
        console.log(bookings);
        this.bookings = bookings;
        this.bookings.sort((a, b) => (a.bookingTime < b.bookingTime) ? -1 : ((a.bookingTime > b.bookingTime) ? 1 : 0));
      })
    );
  }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

}
