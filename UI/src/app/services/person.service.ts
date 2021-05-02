import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import {Person} from '../models/person.model';
import {Environment} from '@angular/compiler-cli/src/ngtsc/typecheck/src/environment';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  constructor(private http: HttpClient) {
    this.moduleUrl = `${environment.apiUrl}/person`;
  }

  private readonly moduleUrl: string;

  list(): Observable<Person[]> {
    return this.http.get<Person[]>(this.moduleUrl);
  }

  get(id: number): Observable<Person> {
    return this.http.get<Person>(`${this.moduleUrl}/${id}`);
  }

  create(data: Person): Observable<Person> {
    return this.http.post<Person>(this.moduleUrl, data);
  }

  update(id: number, data: Person): Observable<Person> {
    return this.http.put<Person>(`${this.moduleUrl}/${id}`, data);
  }

  delete(id: number): Observable<Person> {
    return this.http.delete<Person>(`${this.moduleUrl}/${id}`);
  }

}
