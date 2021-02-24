import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-title-header',
  templateUrl: './title-header.component.html',
  styleUrls: ['./title-header.component.scss']
})
export class TitleHeaderComponent {
  @Input() public mainHeading: string = 'Welcome to your restaurant booking system';
  @Input() public subHeading: string = 'View, create or edit your bookings';

  constructor() {
  }

}
