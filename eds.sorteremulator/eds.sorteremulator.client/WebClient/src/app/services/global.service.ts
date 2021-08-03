import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GlobalService {
  endpoint="http://localhost:4949/api/"
  
  //endpoint=window.location.origin + '/api/';
  constructor() { }
}
