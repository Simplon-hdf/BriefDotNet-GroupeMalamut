import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Randonneur } from '../Models/randonneur.model';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root',
})

export class FormulaireInscriptionService {

  // creation du lien avec la methode de l'API
  private Url = environment.apiBaseurl + "/Randonneur/enregistrer";
  // Cration d'un Objet de type Randonneur (Model) correspondant à la table Randonneur dans la bdd
  FormData: Randonneur = new Randonneur();

  // appel du "constructor" avec comme parametre une librairie angular (HttpClient)
  constructor(public http: HttpClient) { }



  postEnregistrer(FormData: any): Observable<any>{
    const headers = new HttpHeaders({'Content-Type': 'application/json'});
    return this.http.post(this.Url, FormData, {headers})
  }
    formReset() {
      this.FormData = new Randonneur();
    }
  }

