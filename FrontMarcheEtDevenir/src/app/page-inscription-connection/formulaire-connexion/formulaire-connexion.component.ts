import { Component, Injectable } from '@angular/core';
import { ConnectionService } from '../../services/connection.service';
import { ModuleFormulairesModule } from '../module-formulaires/module-formulaires.module';
import { NgForm } from '@angular/forms';

@Component({
  standalone : true,
  selector: 'app-formulaire-connexion',
  templateUrl: './formulaire-connexion.component.html',
  styleUrl: './formulaire-connexion.component.css',
  imports:[ModuleFormulairesModule]
})
export class FormulaireConnexionComponent {
  
  constructor(public service: ConnectionService){}

  onSubmit(form: NgForm) {
    this.service.postEnregistrer()
    .subscribe({
      next:res=>{
        console.log(res)
      },
      error:err =>{console.log(err)}
    })
  }

}
