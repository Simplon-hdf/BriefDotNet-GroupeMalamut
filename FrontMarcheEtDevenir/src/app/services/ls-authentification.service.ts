import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  // BehaviorSubject pour suivre l'état d'authentification de l'utilisateur
  private isAuthenticatedSubject = new BehaviorSubject<boolean>(this.hasToken());

  constructor() { }

  /**
   * Vérifie si un token est présent dans le localStorage.
   * @returns {boolean} - Retourne true si un token est présent, sinon false.
   */
  private hasToken(): boolean {
    return !!localStorage.getItem('token');
  }

  /**
   * Retourne un Observable pour suivre l'état d'authentification.
   * @returns {Observable<boolean>} - Observable de l'état d'authentification.
   */
  isAuthenticated() {
    return this.isAuthenticatedSubject.asObservable();
  }

  /**
   * Met à jour l'état d'authentification.
   * @param {boolean} isAuthenticated - Nouvel état d'authentification.
   */
  setAuthenticated(isAuthenticated: boolean) {
    this.isAuthenticatedSubject.next(isAuthenticated);
  }

  /**
   * Récupère le token d'authentification depuis le localStorage.
   * @returns {string | null} - Le token d'authentification ou null s'il n'existe pas.
   */
  getToken(): string | null {
    return localStorage.getItem('token');
  }

  /**
   * Déconnecte l'utilisateur en supprimant les informations d'authentification du localStorage
   * et en mettant à jour l'état d'authentification.
   */
  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('userId');
    localStorage.removeItem('userEmail');
    this.setAuthenticated(false);
  }
}