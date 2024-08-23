import { Component, Injectable } from '@angular/core';
import { CreationOffreModule } from '../creation-offre/creation-offre.module';
import { NgForm } from '@angular/forms';
import { CreationOffreService } from '../../services/creation-offre.service';
import { Routes, Router } from '@angular/router';

@Component({
  selector: 'app-creation-offre-form',
  templateUrl: './creation-offre-form.component.html',
  styleUrl: './creation-offre-form.component.css',
  standalone: true,
  imports: [
    CreationOffreModule,
  ],
})
@Injectable({ providedIn: 'root' })

export class CreationOffreFormComponent {

  constructor(public service: CreationOffreService, public router: Router) { }

  onSubmit(form: NgForm) {
    this.service.postEnregistrer()
      .subscribe({
        next: res => {
          console.log(res)
          alert("La randonnée à bien été ajoutée");
          this.router.navigate(['/offreRandonnees']);
        },
        error: err => {
          console.log(err)
          alert("Une erreur est survenue. Merci de réesayer plus tard");
        }
      })
    this.service.formReset();
  }
}
