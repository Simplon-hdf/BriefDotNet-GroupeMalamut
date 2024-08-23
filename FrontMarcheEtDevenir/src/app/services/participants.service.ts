import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Participants } from './participants';

@Injectable({
  providedIn: 'root'
})
export class ParticipantsService {
  private Url = environment.apiBaseurl + "/Participant";
  constructor(public http: HttpClient) { }

  get(): Observable<Participants[]> {
    return this.http.get<Participants[]>(`${this.Url}`);
  }
}
