import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {BookingTableComponent} from './components/booking-table/booking-table.component';
import {HomeComponent} from './pages/home/home.component';
import {HttpClientModule} from '@angular/common/http';
import {CreateBookingComponent} from './pages/create-booking/create-booking.component';
import {BookingFormComponent} from './components/booking-form/booking-form.component';
import {ReactiveFormsModule} from '@angular/forms';
import {EditBookingComponent} from './pages/edit-booking/edit-booking.component';
import {TitleHeaderComponent} from './components/title-header/title-header.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    BookingTableComponent,
    CreateBookingComponent,
    BookingFormComponent,
    EditBookingComponent,
    TitleHeaderComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
