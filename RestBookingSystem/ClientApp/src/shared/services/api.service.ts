import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {map} from 'rxjs/operators';
import {IBooking} from '../models/ibooking';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl: string = '/api/';

  private headers = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };

  constructor(private http: HttpClient) {
  }

  public getAllBookings(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}booking`)
      .pipe(
        map((response) => response)
      );
  }

  public createBooking(bookingData: any): Observable<any> {
    const body = JSON.stringify({
      numberOfPeople: bookingData.diners,
      bookingTime: bookingData.dateTime,
      contactNumber: bookingData.number,
      contactName: bookingData.name,
      tableNumber: bookingData.tableNo,
    } as IBooking);
    return this.http.post<any>(`${this.baseUrl}booking`, body, this.headers)
      .pipe(
        map((response) => response)
      );
  }

  public editBooking(bookingData: any, bookingId: number): Observable<any> {
    const body = JSON.stringify({
      bookingId: bookingId,
      numberOfPeople: bookingData.diners,
      bookingTime: bookingData.dateTime,
      contactNumber: bookingData.number,
      contactName: bookingData.name,
      tableNumber: bookingData.tableNo,
    } as IBooking);
    return this.http.put<any>(`${this.baseUrl}booking`, body, this.headers)
      .pipe(
        map((response) => response)
      );
  }
}
