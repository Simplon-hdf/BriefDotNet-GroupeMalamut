import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Randonneur } from '../services/randonneur.model';
import { Observable } from 'rxjs';

export interface LoginResponse {
  randonneur: Randonneur;
  token: string;
}

@Injectable({
  providedIn: 'root'
})
export class ConnectionService {
  private Url = environment.apiBaseurl + "/Authentification/login";

  FormData: Randonneur = new Randonneur();

  constructor(public http: HttpClient) { }

  postLogin(): Observable<HttpResponse<LoginResponse>> {
    return this.http.post<LoginResponse>(this.Url, this.FormData, { observe: 'response' });
  }

  formReset() {
    this.FormData = new Randonneur();
  }
}