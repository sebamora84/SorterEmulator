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

@Injectable({  providedIn: 'root'})
export class NodesService {
  updateNodes = new EventEmitter<any>();
  deleteNodes = new EventEmitter<any>();
  private nodesHubConnection: signalR.HubConnection;
  constructor(private http: HttpClient, private globalService:GlobalService) {  
    this.buildConnection();
    this.registerEvents();
    this.startConnection();
  }
  public buildConnection = () => {
    this.nodesHubConnection = new signalR.HubConnectionBuilder()
                            .withUrl(this.globalService.endpoint+'NodesHub')
                            .build();
 
   
  }

  public startConnection =()=> {
    this.nodesHubConnection
    .start()
    .then(() => console.log('Nodes Connection started'))
    .catch(err => console.log('Error while starting Nodes connection: ' + err))
  }

  public registerEvents(){
    this.nodesHubConnection.on('UpdateNode', (data) => {
      this.updateNodes.emit(data);
    });
    this.nodesHubConnection.on('DeleteNode', (data) => {
      this.deleteNodes.emit(data);
    });
  }



  getNodes(): Observable<any> {
    return this.http.get(this.globalService.endpoint + 'nodes').pipe(
      map(this.extractData));
  }
  
  getNode(id): Observable<any> {
    return this.http.get(this.globalService.endpoint + 'nodes/' + id).pipe(
      map(this.extractData));
  }
  
  addNode (node): Observable<any> {
    return this.http.post<any>(this.globalService.endpoint + 'nodes', JSON.stringify(node), httpOptions).pipe(
      tap((node) =>{ console.log('added node w/ id='+node.id)}),
      catchError(this.handleError<any>('addNode'))
    );
  }
  
  updateNode (id, node): Observable<any> {
    console.log('updating node id='+id)
    return this.http.put(this.globalService.endpoint + 'nodes/' + id, JSON.stringify(node), httpOptions).pipe(
      tap(_ => console.log('updated node id='+id)),
      catchError(this.handleError<any>('updateNode'))
    );
  }
  
  deleteNode (id): Observable<any> {
    return this.http.delete<any>(this.globalService.endpoint + 'nodes/' + id, httpOptions).pipe(
      tap(_ => console.log('deleted node id='+id)),
      catchError(this.handleError<any>('deleteNode'))
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
