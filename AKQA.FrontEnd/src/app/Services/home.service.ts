import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { environment } from '../../environments/environment'

import { Person } from '../Models/Person'
import { CoreEnvironment } from '@angular/core/src/render3/jit/compiler_facade_interface';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

 baseUrl = environment.baseUrl;

  constructor(
    private http : HttpClient
) { }

  ConvertNumberToWords(person: Person): Observable<Person>{
    
    return this.http.post<Person>(this.baseUrl + '/home/processrequest', person);
  }
}
