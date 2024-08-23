import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from './ls-authentification.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) {}

  /**
   * Intercepte les requêtes HTTP sortantes pour ajouter le token d'authentification.
   * @param {HttpRequest<any>} request - La requête HTTP sortante.
   * @param {HttpHandler} next - Le gestionnaire de la requête HTTP.
   * @returns {Observable<HttpEvent<any>>} - Un Observable de l'événement HTTP.
   */
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // Récupère le token d'authentification depuis le service AuthService
    const token = this.authService.getToken();
    
    // Si un token est présent, clone la requête et ajoute le header Authorization
    if (token) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
    }
    
    // Passe la requête au prochain gestionnaire
    return next.handle(request);
  }
}