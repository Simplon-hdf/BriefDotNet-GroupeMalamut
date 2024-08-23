import { Component, Injectable} from '@angular/core';
import { FormulaireInscriptionService } from '../../services/formulaire-inscription.service';
import { ModuleFormulairesModule } from '../module-formulaires/module-formulaires.module';
import {   
  AbstractControl,
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  NgForm,
  ReactiveFormsModule,
  ValidationErrors,
  Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';


@Component({
  standalone: true,
  selector: 'app-formulaire-inscription',
  templateUrl: './formulaire-inscription.component.html',
  styleUrl: './formulaire-inscription.component.css',
  imports: [
    ModuleFormulairesModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ],
})
@Injectable({ providedIn: 'root' })
export class FormulaireInscriptionComponent {

  formulaire!: FormGroup;

  constructor(public service: FormulaireInscriptionService, private formBuilder: FormBuilder) {}

  ngOnInit() {
    this.formulaire = new FormGroup({
      Nom:                    new FormControl('', Validators.required),
      Prenom:                 new FormControl('', Validators.required),
      Mail:                   new FormControl('', [Validators.required, Validators.email]),
      Telephone:              new FormControl('', [Validators.pattern(/^[0-9]{10}$/)]),
      MotDePasse:             new FormControl('', [Validators.required, Validators.minLength(6)]),
      ConfirmationMotDePasse: new FormControl('', Validators.required)
    }, { validators: FormulaireInscriptionComponent.checkPasswords });
  }



  static checkPasswords(group: AbstractControl): ValidationErrors | null {
    const pass = group.get('MotDePasse')?.value;
    const confirmPass = group.get('ConfirmationMotDePasse')?.value;
    return pass === confirmPass ? null : { notSame: true };
  }



  champIsInvalid(nomChamp: string): boolean | undefined{
    const champ = this.formulaire.get(nomChamp);
    return !!champ?.invalid && (!!champ?.touched || !!champ?.dirty);
  }

  getMessageErreur(nomChamp: string): string{
    const champ = this.formulaire.get(nomChamp);
    if (champ?.errors?.['required']) {
      return `Le champ ${nomChamp} est requis`;
    } else if (champ?.errors?.['email']) {
      return "Veuillez entrer un email valide";
    } else if (champ?.errors?.['pattern']) {
      return "Le numéro de téléphone doit contenir 10 chiffres";
    } else if (champ?.errors?.['minlength']) {
      return "Le mot de passe doit contenir au moins 6 caractères";
    } else if (this.formulaire.errors?.['notSame'] && nomChamp === 'ConfirmationMotDePasse') {
      return "Les mots de passe ne correspondent pas";
    }else if (champ?.errors?.['maxlength']) {
      return "Le mot de passe doit contenir maximum 16 caractères";
    }
    return "";
  }


  onSubmit() {
    if (this.formulaire.valid) {
      this.service.postEnregistrer(this.formulaire.value).subscribe({
        next: (formulaire) => {
          return console.log(formulaire);
        },
        error: (err) => {
          return console.log(err);
        },
      });
    }else{
      Object.keys(this.formulaire.controls).forEach(key => {
        const control = this.formulaire.get(key);
        control?.markAsTouched();
      });
  }
  }
}