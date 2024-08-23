import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Randonneur } from '../Models/randonneur.model';

/**
 * Service de connexion pour gérer les opérations d'authentification.
 */
@Injectable({
  providedIn: 'root'
})
export class ConnectionService {
 /**
 * URL de l'API pour l'authentification.
 */
private Url = environment.apiBaseurl + "/Randonneur/login";

  /**
   * Données du formulaire de connexion.
   */
  FormData: Randonneur = new Randonneur();

  /**
   * Constructeur du service de connexion.
   * @param http Client HTTP pour effectuer les requêtes.
   */
  constructor(public http: HttpClient) { }

  /**
   * Envoie une requête POST pour se connecter.
   * @param email L'adresse email de l'utilisateur.
   * @param motDePasse Le mot de passe de l'utilisateur.
   * @returns Un observable de la réponse HTTP.
   */
  postLogin() {
    return this.http.post(this.Url, this.FormData, { observe: 'response' });
  }

  /**
   * Réinitialise les données du formulaire de connexion.
   */
  formReset() {
    this.FormData = new Randonneur();
  }
}