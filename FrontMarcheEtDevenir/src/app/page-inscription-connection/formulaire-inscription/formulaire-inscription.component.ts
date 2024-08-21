import { Component, Injectable, input} from '@angular/core';
import { FormulaireInscriptionService } from '../../services/formulaire-inscription.service';
import { ModuleFormulairesModule } from '../module-formulaires/module-formulaires.module';
import { AbstractControl, FormBuilder, FormGroup, NgForm, ValidationErrors, Validators } from '@angular/forms';


@Component({
  standalone : true,
  selector: 'app-formulaire-inscription',
  templateUrl: './formulaire-inscription.component.html',
  styleUrl: './formulaire-inscription.component.css',
  imports: [ModuleFormulairesModule]
})

@Injectable({ providedIn: 'root' })
export class FormulaireInscriptionComponent{

constructor(public service: FormulaireInscriptionService, private formBuilder: FormBuilder){}
// variable qui récupère la valeur des "input" 

formulaire!: FormGroup;

// Variables pour la vérifications

static messageErreur = "";


ngOnInit(){
  this.formulaire = this.formBuilder.group({
    nom: ['', Validators.required],
    prenom : ['', Validators.required],
    mail : ['', [Validators.required, Validators.email]],
    telephone : ['', Validators.required],
    motDePasse : ['', Validators.required],
    confirmationMotDePasse : ['', Validators.required]
  },{Validators : this.passwordMatchValidator});
}
passwordMatchValidator(control: AbstractControl): ValidationErrors | null {
  const motDePasse = control.get('motDePasse');
  const confirmationMotDePasse = control.get('confirmationMotDePasse');

  if (!motDePasse || !confirmationMotDePasse) {
    return null;
  }

  const match = motDePasse.value === confirmationMotDePasse.value;
  return match ? null : { passwordMismatch: true };
}

onSubmit(form: NgForm) {

    if(this.formulaire.valid){
    this.service.postEnregistrer()
    .subscribe({
      next:res=>{
        console.log(res);
      },
      error:err =>{console.log(err);}
    })
    this.service.formReset();
  }else if(this.formulaire.invalid){
     alert(FormulaireInscriptionComponent.messageErreur)
  }else{
     alert(FormulaireInscriptionComponent.messageErreur)
  }
  }
}
