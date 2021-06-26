import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { GlobalService } from './global.service';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};
@Injectable({
  providedIn: 'root'
})
export class CommunicationService {

  constructor(private http: HttpClient, private globalService:GlobalService) { }
  


  getCommunicationConfig(): Observable<any> {
    return this.http.get(this.globalService.endpoint + 'communication').pipe(
      map(this.extractData));
  }
  
  getCommunicationConfigById(id): Observable<any> {
    return this.http.get(this.globalService.endpoint + 'communication/' + id,httpOptions).pipe(
      map(this.extractData));
  }
  
  addCommunicationConfig (comunicationConfig): Observable<any> {
    console.log(comunicationConfig);
     return this.http.post<any>(this.globalService.endpoint + 'communication',JSON.stringify(comunicationConfig) , httpOptions)
    .pipe(      
      tap(() => console.log('CommunicationConfig added')),
      catchError(this.handleError<any>('add CommunicationConfig'))
    );
  }
  
  updateCommunicationConfig (id, comunicationConfig): Observable<any> {
    return this.http.put(this.globalService.endpoint + 'communication/' + id, JSON.stringify(comunicationConfig), httpOptions).pipe(
      tap((comunicationConfig) => console.log('CommunicationConfig updated')),
      catchError(this.handleError<any>('update CommunicationConfig'))
    );
  }
  
  
  deleteCommunicationConfig (id): Observable<any> {
    return this.http.delete<any>(this.globalService.endpoint + 'communication/' + id, httpOptions).pipe(
      tap(_ => console.log(`deleted CommunicationConfig id=${id}`)),
      catchError(this.handleError<any>('delete CommunicationConfig'))
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
