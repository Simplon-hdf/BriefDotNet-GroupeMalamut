import { Component, Injectable } from '@angular/core';
import { FormulaireInscriptionService } from '../../services/formulaire-inscription.service';
import { ModuleFormulairesModule } from '../module-formulaires/module-formulaires.module';
import { NgForm } from '@angular/forms';


@Component({
  standalone : true,
  selector: 'app-formulaire-inscription',
  templateUrl: './formulaire-inscription.component.html',
  styleUrl: './formulaire-inscription.component.css',
  imports:[ModuleFormulairesModule]
})

@Injectable({ providedIn: 'root' })
export class FormulaireInscriptionComponent {

constructor(public service: FormulaireInscriptionService){}


  // vérifie si les mot de passe sont identique
 /* MotDePasseIdentique(){
   let motDePasse  = document.getElementsByName("motDePasse");
   let confirmationMotDePasse = document.getElementsByName("inscriptionConfirmationMotdePasse");
   while(motDePasse != confirmationMotDePasse){
    return false
   };
  }*/

  // vérifier le mot de passe comporte des nombres, minuscule, majuscule, caractère spécial et de la
  // taille requis
 /* MotDePasseRegex(){
    let motDePasse  = document.getElementsByName("motDePasse");
    const patternMotDePasse = /^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{8,16}$/;
    if(motDePasse.length > 8 && motDePasse.length < 16)
    {

    }
    else if(motDePasse.) 
    {

    }
    else if() 
    {

    }
    else if()
    {

    }
  }*/

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
