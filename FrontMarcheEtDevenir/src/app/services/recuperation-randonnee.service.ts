import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Randonnee } from './randonnee';

@Injectable({
  providedIn: 'root'
})
export class RecuperationRandonneeService {
  // Déclaration de l'url de l'api
  private url = environment.apiBaseurl + '/randonnees';

  constructor(public http: HttpClient) { }

  List: Randonnee[] = [];
  GetInformationRandonnee() {
    // Récupérer les informations de la randonnée
    return this.http.get(this.url)
      .subscribe({
        next: res => {
          this.List = res as Randonnee[]
        },
        error: err => {
          console.log(err);
        }
      })
  }
}
