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
export class PhysicsService {

  
  constructor(private http: HttpClient, private globalService:GlobalService) { }

  getPhysics(): Observable<any> {
    return this.http.get(this.globalService.endpoint + 'physics').pipe(
      map(this.extractData));
  }
  
  getPhysic(id): Observable<any> {
    return this.http.get(this.globalService.endpoint + 'physics/' + id,httpOptions).pipe(
      map(this.extractData));
  }
  
  addPhysic (physic): Observable<any> {
     return this.http.post<any>(this.globalService.endpoint + 'physics',JSON.stringify(physic) , httpOptions)
    .pipe(      
      tap(() =>{}),
      catchError(this.handleError<any>('addPhysic'))
    );
  }
  
  updatePhysic (id, physic): Observable<any> {
    return this.http.put(this.globalService.endpoint + 'physics/' + id, JSON.stringify(physic), httpOptions).pipe(
      tap((physic) =>{}),
      catchError(this.handleError<any>('updatePhysic'))
    );
  }
  
  
  deletePhysic (id): Observable<any> {
    return this.http.delete<any>(this.globalService.endpoint + 'physics/' + id, httpOptions).pipe(
      tap(_ => {}),
      catchError(this.handleError<any>('deletePhysic'))
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
