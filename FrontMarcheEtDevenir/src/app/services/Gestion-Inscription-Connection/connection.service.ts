import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Randonneur } from '../Models/randonneur.model';
import { Observable } from 'rxjs';

// Interface pour la réponse de la requête de connexion
export interface LoginResponse {
  randonneur: Randonneur;
  token: string;
}

@Injectable({
  providedIn: 'root'
})
export class ConnectionService {
  // URL de l'API pour la connexion (url de base + route définie)
  private Url = environment.apiBaseurl + "/Randonneur/login";

  FormData: Randonneur = new Randonneur();

  constructor(public http: HttpClient) { }

  postLogin(): Observable<HttpResponse<LoginResponse>> {
    return this.http.post<LoginResponse>(this.Url, this.FormData, { observe: 'response' });
  }

  formReset() {
    this.FormData = new Randonneur();
  }
}