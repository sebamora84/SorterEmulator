import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';

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
  
  constructor(private http: HttpClient, private globalService:GlobalService) { }

  getTracking(): Observable<any> {
    return this.http.get(this.globalService.endpoint + 'tracking').pipe(
      map(this.extractData));
  }
  deleteTrackingByPic(id): any {
    return this.http.delete<any>(this.globalService.endpoint + 'tracking/' + id, httpOptions).pipe(
      tap(_ => console.log(`deleted tracking by pic=${id}`)),
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
