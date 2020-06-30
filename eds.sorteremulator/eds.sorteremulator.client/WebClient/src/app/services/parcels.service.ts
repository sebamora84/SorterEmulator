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

@Injectable({  providedIn: 'root'})
export class ParcelsService {

  constructor(private http: HttpClient, private globalService:GlobalService) { }


  getParcels(): Observable<any> {
    return this.http.get(this.globalService.endpoint + 'parcels').pipe(
      map(this.extractData));
  }
  
  getParcel(id): Observable<any> {
    return this.http.get(this.globalService.endpoint + 'parcels/' + id).pipe(
      map(this.extractData));
  }
  
  addParcel (parcel): Observable<any> {
    console.log(parcel);
     return this.http.post<any>(this.globalService.endpoint + 'parcels',JSON.stringify(parcel) , httpOptions)
    .pipe(      
      tap(() => console.log('Parcel added')),
      catchError(this.handleError<any>('addParcel'))
    );
  }
  
  updateParcel (id, parcel): Observable<any> {
    return this.http.put(this.globalService.endpoint + 'parcels/' + id, JSON.stringify(parcel), httpOptions).pipe(
      tap((parcel) => console.log('Parcel updated')),
      catchError(this.handleError<any>('updateParcel'))
    );
  }
  
  
  deleteParcel (id): Observable<any> {
    return this.http.delete<any>(this.globalService.endpoint + 'parcels/' + id).pipe(
      tap(_ => console.log('deleted parcel')),
      catchError(this.handleError<any>('deleteParcel'))
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
