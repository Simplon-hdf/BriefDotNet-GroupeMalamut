import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class IdentiteUtilisateurService {
  private url = environment.apiBaseurl + "/Randonneur/{id}" // je declare un chemin d'acces à une methode
  constructor(
    public http: HttpClient) { } // creation d'une methode avec en parametre une variable de type httpClient(=librairie) (en js le type est à droite)
  getInformationUtilisateur() { // je declare une methode qui me retourne deux reponses pour recuperer via la methode get(this.url) 
    return this.http.get(this.url) //et renvoyer via la methode subscribe(2parametres tableaux)
      .subscribe({
        next: res => {
          console.log(res);
        },
        error: err => {
          console.log(err);
        }
      })
    
  }
}
