import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Randonneur } from '../Models/randonneur.model';
import { catchError, Observable, throwError } from 'rxjs';


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

  private transformFormData(formData: any): Randonneur {
    return {
      Nom: formData.Nom,
      Prenom: formData.Prenom,
      Mail: formData.Mail,
      MotDePasse: formData.MotDePasse,
      Telephone: formData.Telephone,
      RoleId: 1 // Valeur par défaut
    };
  }
  

  postEnregistrer(FormData: any): Observable<any>{
    const randonneur = this.transformFormData(FormData);
    console.log('Données envoyées:', randonneur);
    const headers = new HttpHeaders({'Content-Type': 'application/json'});
    return this.http.post(this.Url, randonneur, {headers}).pipe(
      catchError((error: HttpErrorResponse) => {
        console.error('Détails de l\'erreur:', error);
        return throwError(() => new Error('Erreur lors de l\'enregistrement. Veuillez réessayer.'));
      })
    );
  }
    formReset() {
      this.FormData = new Randonneur();
    }
  }

