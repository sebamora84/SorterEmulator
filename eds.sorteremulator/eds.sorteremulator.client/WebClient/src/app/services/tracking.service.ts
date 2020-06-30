import { Injectable, EventEmitter } from '@angular/core';

import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import * as signalR from "@aspnet/signalr";
import { GlobalService } from './global.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};
@Injectable({
  providedIn: 'root'
})
export class TrackingService {
  private trackingHubConnection: signalR.HubConnection;
  updateTracking = new EventEmitter<any>();
  deleteTracking = new EventEmitter<any>();  

  constructor(private http: HttpClient, private globalService:GlobalService) { 
    this.buildConnection();
    this.registerEvents();
    this.startConnection();
  }

  public buildConnection = () => {
    this.trackingHubConnection = new signalR.HubConnectionBuilder()
                            .withUrl(this.globalService.endpoint+'TrackingHub')
                            .build();
 
   
  }

  public startConnection =()=> {
    this.trackingHubConnection
    .start()
    .then(() => console.log('Tracking Connection started'))
    .catch(err => console.log('Error while starting Tracking connection: ' + err))
  }

  public registerEvents(){
    this.trackingHubConnection.on('UpdateTracking', (data) => {
      this.updateTracking.emit(data);
    });
    this.trackingHubConnection.on('DeleteTracking', (data) => {
      this.deleteTracking.emit(data);
    });
  }

  getTracking(): Observable<any> {
    return this.http.get(this.globalService.endpoint + 'tracking').pipe(
      map(this.extractData));
  }

  deleteTrackingByPic(id): any {
    return this.http.delete<any>(this.globalService.endpoint + 'tracking/' + id, httpOptions).pipe(
      tap(_ => console.log('deleted tracking by pic=${id}')),
      catchError(this.handleError<any>('deleteTrackingByPic'))
    );
  }
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
  
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
  
      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);
  
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  private extractData(res: Response) {
    let body = res;
    return body || { };
  }
}
