import { Trip } from './../models/trip';
import { DayOfWork } from './../models/day-of-work';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TripCalculationService {

  private readonly controllerUrl = 'api/Trip';
  constructor(
    private http: HttpClient
  ) {}

  calculateTrip(dow: DayOfWork): Observable<Trip> {
    return this.http.post<Trip>(`${environment.hostUrl}/${this.controllerUrl}`, dow);
  }
}
