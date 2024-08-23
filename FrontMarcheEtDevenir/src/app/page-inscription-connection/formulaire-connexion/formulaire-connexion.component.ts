import { Component, Injectable, OnInit } from '@angular/core';
import { ConnectionService } from '../../services/connection.service';
import { ModuleFormulairesModule } from '../module-formulaires/module-formulaires.module';
import { NgForm } from '@angular/forms';

@Component({
  standalone: true,
  selector: 'app-formulaire-connexion',
  templateUrl: './formulaire-connexion.component.html',
  styleUrl: './formulaire-connexion.component.css',
  imports: [ModuleFormulairesModule]
})
export class FormulaireConnexionComponent {
  constructor(public connectionService: ConnectionService) { }


  onSubmit(form: NgForm) {
    if (form.valid) {
      const email = form.value.email;
      const motDePasse = form.value.motDePasse;

      this.connectionService.postLogin(email, motDePasse)
        .subscribe({
          next: res => {
            alert('Connexion réussie');
            console.log(res);
          },
          error: err => {
            console.error('Erreur de connexion:', err);
            console.log(FormData);
            
          }
        });
    } else {
      alert('Formulaire invalide. Veuillez remplir tous les champs correctement.');
    }
  }
}
