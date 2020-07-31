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
  getActionsByNode(nodeId): Observable<any> {
    return this.http.get(this.globalService.endpoint + 'actions/ByNode/'+nodeId).pipe(
      map(this.extractData));
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
