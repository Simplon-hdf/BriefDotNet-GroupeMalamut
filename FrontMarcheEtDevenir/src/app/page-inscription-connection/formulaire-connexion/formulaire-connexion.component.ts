import { Component, Injectable, OnInit } from '@angular/core';
import { ConnectionService } from '../../services/connection.service';
import { ModuleFormulairesModule } from '../module-formulaires/module-formulaires.module';
import { NgForm } from '@angular/forms';
import { AuthService } from '../../services/ls-authentification.service';
import { Router } from '@angular/router';

@Component({
  standalone: true,
  selector: 'app-formulaire-connexion',
  templateUrl: './formulaire-connexion.component.html',
  styleUrl: './formulaire-connexion.component.css',
  imports: [ModuleFormulairesModule]
})
export class FormulaireConnexionComponent {
  constructor(public connectionService: ConnectionService, private authService: AuthService, private router: Router) { }


  onSubmit(form: NgForm) {
    if (form.valid) {
      this.connectionService.postLogin()
        .subscribe({
          next: (response) => {
            console.log('Réponse complète du serveur:', response);
            //Si la réponse contient un token (donc si l'identifiant est valide), on le stocke dans le localStorage et on redirige l'utilisateur vers la page d'accueil
            if (response.body && response.body.token) {
              localStorage.setItem('token', response.body.token);
              this.authService.setAuthenticated(true);
              alert('Connexion réussie, vous allez être redirigé vers la page d\'accueil.');
              setInterval(() => {
                //Redirection vers la page d'accueil une fois connecté
                this.router.navigate(['/']);
              }, 500);

            } else {
              //Sinon, on affiche un message d'erreur comprenant le contenu de l'erreur
              console.error('Réponse sans token:', response.body);
              alert('Erreur de connexion');
            }
          },
          error: (err) => {
            console.error('Erreur de connexion:', err);
            if (err.status === 400) {
              alert('Adresse email ou mot de passe incorrect');
            } else {
              alert('Erreur de connexion');
            }
          }
        });
    } else {
      //Si le formulaire n'est pas valide, on affiche un message d'erreur
      alert('Formulaire invalide. Veuillez remplir tous les champs correctement.');
    }
  }
}