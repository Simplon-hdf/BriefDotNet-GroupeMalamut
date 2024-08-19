import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Randonnee } from './randonnee';

@Injectable({
  providedIn: 'root'
})
export class CreationOffreService {
  
  private Url = environment.apiBaseurl + "/Randonee/";
  FormData: Randonnee = new Randonnee();
  constructor(public http: HttpClient) { }



  postEnregistrer() {
    return this.http.post(this.Url, this.FormData)
  }

  formReset() {
    this.FormData = new Randonnee();
  }
}
