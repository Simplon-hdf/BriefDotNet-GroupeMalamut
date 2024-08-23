import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Randonnee } from './randonnee';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ListeOffresService {

  private Url = environment.apiBaseurl + "/Randonee";
  constructor(public http: HttpClient) { }

  getRandonnees(): Observable<Randonnee[]> {
    return this.http.get<Randonnee[]>(`${this.Url}`);
  }
}
