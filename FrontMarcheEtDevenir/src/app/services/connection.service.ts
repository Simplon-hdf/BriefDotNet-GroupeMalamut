import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Randonneur } from '../services/randonneur.model';

@Injectable({
  providedIn: 'root'
})
export class ConnectionService {

  private Url = environment.apiBaseurl + "/Authentification/login";
  FormData: Randonneur = new Randonneur();
  constructor(public http: HttpClient) { }



  postEnregistrer() {
    return this.http.post(this.Url, this.FormData)
  }

  formReset() {
    this.FormData = new Randonneur();
  }
}
