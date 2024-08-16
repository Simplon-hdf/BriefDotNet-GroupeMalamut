import { Component, Injectable } from '@angular/core';
// import { FormulaireInscriptionService } from '../../services/formulaire-inscription.service';
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


  onSubmit(form: NgForm) {
    this.service.postEnregistrer()
    .subscribe({
      next:res=>{
        console.log(res)
      },
      error:err =>{console.log(err)}
    })
  }

 CreerCompte() {
  // Code
 }
 

}
