import { Injectable, EventEmitter  } from '@angular/core';

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
@Injectable({providedIn: 'root'})
export class ActionsService {
  

  constructor(private http: HttpClient, private globalService:GlobalService) { }

  getActions(): Observable<any> {
    return this.http.get(this.globalService.endpoint + 'actions').pipe(
      map(this.extractData));
  }
  getAction(id): Observable<any> {
    return this.http.get(this.globalService.endpoint + 'actions/' + id).pipe(
      map(this.extractData));
  }
  getActionsByNode(nodeId): Observable<any> {
    return this.http.get(this.globalService.endpoint + 'actions/ByNode/'+nodeId).pipe(
      map(this.extractData));
  }

  addAction (action): Observable<any> {
    return this.http.post<any>(this.globalService.endpoint + 'action', JSON.stringify(action), httpOptions).pipe(
      tap((action) =>{ console.log('added action w/ id='+action.id)}),
      catchError(this.handleError<any>('addAction'))
    );
  }
  
  updateAction (id, action): Observable<any> {
    console.log('updating action id='+id)
    return this.http.put(this.globalService.endpoint + 'actions/' + id, JSON.stringify(action), httpOptions).pipe(
      tap(_ => console.log('updated action id='+id)),
      catchError(this.handleError<any>('updateAction'))
    );
  }
  
  deleteAction (id): Observable<any> {
    return this.http.delete<any>(this.globalService.endpoint + 'actions/' + id, httpOptions).pipe(
      tap(_ => console.log('deleted action id='+id)),
      catchError(this.handleError<any>('deleteAction'))
    );
  }

  executeAction (id): Observable<any> {
    return this.http.post<any>(this.globalService.endpoint + 'actions/execute/' + id, httpOptions).pipe(
      tap(_ => console.log('executed action id='+id)),
      catchError(this.handleError<any>('deleteAction'))
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
