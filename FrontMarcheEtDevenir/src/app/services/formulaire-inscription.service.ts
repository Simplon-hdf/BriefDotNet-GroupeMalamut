import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Randonneur } from './randonneur.model';


@Injectable({
  providedIn: 'root',
})

export class FormulaireInscriptionService {

  private Url = environment.apiBaseurl + "/Authentification/enregistrer";
  FormData: Randonneur = new Randonneur();
  constructor(public http: HttpClient) { }



  postEnregistrer() {
    return this.http.post(this.Url, this.FormData)
  }
    formReset() {
      this.FormData = new Randonneur();
    }
  }

