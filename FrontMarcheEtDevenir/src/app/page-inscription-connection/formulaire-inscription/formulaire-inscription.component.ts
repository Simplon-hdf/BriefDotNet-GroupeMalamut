import { Component, Injectable} from '@angular/core';
import { FormulaireInscriptionService } from '../../services/Gestion-Inscription-Connection/formulaire-inscription.service';
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

  // creation du formulaire pour envoie
  formulaire!: FormGroup;

  // creation d'une variable pour vérification du mot de passe
  showPasswordRequirements: boolean = false;

  // appel du constructeur : utilisation d'un service pour appeler la méthode de l'API et creation 
  // d'un FormBuilder pour gérer les données du formulaire
  constructor(public service: FormulaireInscriptionService, private formBuilder: FormBuilder) {}

  // creation d'un FormGroup pour le formulaire avec les validateurs (prérequis pour envoyer le formulaire)
  ngOnInit() {
    this.formulaire = new FormGroup({
      // chaque champ à un FormControl qui vérifie si les validators sont validé
      Nom:                    new FormControl('', Validators.required),
      Prenom:                 new FormControl('', Validators.required),
      // vérifie si le champs mail est valide (avec un "@" dasn le champs)
      Mail:                   new FormControl('', [Validators.required, Validators.email]),
      // vérifie si le champs tel comporte bien 10 chiffres
      Telephone:              new FormControl('', [Validators.pattern(/^[0-9]{10}$/)]),
      // vérification du champs MotDepasse et ConfirmationMotDePasse
      MotDePasse:             new FormControl('', Validators.required),
      ConfirmationMotDePasse: new FormControl('', [Validators.required, this.passwordValidator])
      //ajout d'un validateur personalisée
    }, { validators: FormulaireInscriptionComponent.checkPasswords });
  }


  // vérification des prérequis sur le mot de passe
  passwordValidator(control: AbstractControl): { [key: string]: boolean } | null {
    // récupère la valeur du mot de passe
    const password = control.value;
    // recupere le boolean des méthodes de test des regex
    const hasNumber = /[0-9]/.test(password);
    const hasUpper = /[A-Z]/.test(password);
    const hasLower = /[a-z]/.test(password);
    const hasSpecial = /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]+/.test(password);
    // constante qui récupère l'ensemble des boolean stocker ci-dessus
    const valid = hasNumber && hasUpper && hasLower && hasSpecial;
    // si non valide, renvoie true
    if (!valid) {
      return { 'passwordRequirements': true };
    }
    // sinon retour null
    return null;
  }

  // methode qui vérifie si le mot de passe contient le regex
  hasNumber(value: string | undefined): boolean {
    return value ? /[0-9]/.test(value) : false;
  }

  hasUpperCase(value: string | undefined): boolean {
    return value ? /[A-Z]/.test(value) : false;
  }

  hasLowerCase(value: string | undefined): boolean {
    return value ? /[a-z]/.test(value) : false;
  }

  hasSpecialChar(value: string | undefined): boolean {
    return value ? /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]+/.test(value) : false;
  }

  hasMinLength(value: string | undefined): boolean {
    return value ? value.length >= 6 : false;
  }

    // permet d'afficher ou non les prérequis du mot de passe
    togglePasswordRequirements() {
      this.showPasswordRequirements = !this.showPasswordRequirements;
    }

    // vérification si les deux mot de passe concorde
  static checkPasswords(group: AbstractControl): ValidationErrors | null {
    const pass = group.get('MotDePasse')?.value;
    const confirmPass = group.get('ConfirmationMotDePasse')?.value;
    return pass === confirmPass ? null : { notSame: true };
  }




  // vérification si les champs on été toucher et modifier
  champIsInvalid(nomChamp: string): boolean | undefined{
    const champ = this.formulaire.get(nomChamp);
    return !!champ?.invalid && (!!champ?.touched || !!champ?.dirty);
  }


  // renvoie un message d'erreur en fonction de l'erreur et du champs
getMessageErreur(nomChamp: string): string {
  const champ = this.formulaire.get(nomChamp);
  if (champ?.errors?.['required']) {
    return `Le champ ${nomChamp} est requis`;
  } else if (champ?.errors?.['email']) {
    return "Veuillez entrer un email valide";
  } else if (champ?.errors?.['pattern']) {
    return "Le numéro de téléphone doit contenir 10 chiffres";
  } else if (champ?.errors?.['minlength']) {
    return "Le mot de passe doit contenir au moins 6 caractères";
  } else if (champ?.errors?.['maxlength']) {
    return "Le mot de passe doit contenir maximum 16 caractères";
  } else if (champ?.errors?.['passwordRequirements']) {
    return "Le mot de passe ne respecte pas les exigences de sécurité";
  } else if (this.formulaire.errors?.['notSame'] && nomChamp === 'ConfirmationMotDePasse') {
    return "Les mots de passe ne correspondent pas";
  }
  return "";
}


  //envoie du formulaire s'il est valid, sinon renvoie d'une erreur. Si formulaire incomplet
  // affiche les message d'erreur lors du click sur le bouton
  onSubmit() {
    if (this.formulaire.valid) {
      this.service.postEnregistrer(this.formulaire.value).subscribe({
        next: (formulaire) => {
          this.service.formReset();
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