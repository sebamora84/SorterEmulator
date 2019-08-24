import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GlobalService {
  endpoint=window.location.origin + '/api/';
  constructor() { }
}
