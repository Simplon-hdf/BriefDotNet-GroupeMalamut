import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable } from "rxjs";
import { FormulaireInscriptionComponent } from "../page-inscription-connection/formulaire-inscription/formulaire-inscription.component";


@Injectable({
  providedIn: 'root'
})
export class FormulaireInscriptionServiceService {

  private apiUrl = "https://localhost:7157/api/";

  constructor(private http: HttpClient) { }

  Inscription(randonneur: FormulaireInscriptionComponent): Observable<FormulaireInscriptionComponent> {
  /*  return this.http.post<Randonneur>(this.apiUrl, randonneur)
      .pipe(
        catchError(this.handleError('ajoutUser', randonneur))
    );*/

      this.http.post<FormulaireInscriptionComponent>(this.apiUrl, randonneur.subscribe(config => {
        console.log('Updated config:', config));
  }


};
