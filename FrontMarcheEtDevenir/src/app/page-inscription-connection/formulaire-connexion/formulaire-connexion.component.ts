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

  isValidEmail(email: string, form: NgForm): boolean {
    const valideurUtilisateur: RegExp = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g;
    return valideurUtilisateur.test(form.value.email!);
  }

  isValidPassword(motDePasse: string, form: NgForm): boolean {
    const valideurMotDePasse: RegExp = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/g;
    return valideurMotDePasse.test(form.value.motDePasse!);
  }

  onSubmit(form: NgForm) {
    this.connectionService.postLogin(form.value.email, form.value.motDePasse)
      .subscribe({
        next: res => {
          console.log(res);
        },
        error: err => {
          console.log(err);
        }
      });
  }

  onClick(form: NgForm) {
    if (this.isValidEmail(form.value.email, form) && this.isValidPassword(form.value.motDePasse, form)) {
      this.connectionService.postLogin(form.value.email, form.value.motDePasse)
        .subscribe({
          next: res => {
            console.log('Connexion réussie', res);
            // Logique supplémentaire après une connexion réussie
          },
          error: err => {
            console.log('Erreur de connexion', err);
          }
        });
    }
  }
}