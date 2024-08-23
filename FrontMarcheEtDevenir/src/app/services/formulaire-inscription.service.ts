import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Randonneur } from './randonneur.model';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root',
})

export class FormulaireInscriptionService {

  private Url = environment.apiBaseurl + "/Authentification/enregistrer";
  FormData: Randonneur = new Randonneur();
  constructor(public http: HttpClient) { }



  postEnregistrer(FormData: any): Observable<any>{
    const headers = new HttpHeaders({'Content-Type': 'application/json'});
    return this.http.post(this.Url, FormData, {headers})
  }
    formReset() {
      this.FormData = new Randonneur();
    }
  }

