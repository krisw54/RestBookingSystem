import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {HomeComponent} from './pages/home/home.component';
import {CreateBookingComponent} from './pages/create-booking/create-booking.component';
import {EditBookingComponent} from './pages/edit-booking/edit-booking.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'create-booking',
    component: CreateBookingComponent
  },
  {
    path: 'edit-booking',
    component: EditBookingComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
