import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GlobalService {
  //endpoint="http://localhost:49494/api/"
  endpoint=window.location.origin + '/api/';
  constructor() { }
}
