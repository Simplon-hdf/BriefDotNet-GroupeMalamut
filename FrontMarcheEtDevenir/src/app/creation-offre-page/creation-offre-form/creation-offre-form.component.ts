import { Component, Injectable } from '@angular/core';
import { CreationOffreModule } from '../creation-offre/creation-offre.module';
import { NgForm } from '@angular/forms';
import { CreationOffreService } from '../../services/creation-offre.service';

@Component({
  selector: 'app-creation-offre-form',
  templateUrl: './creation-offre-form.component.html',
  styleUrl: './creation-offre-form.component.css',
  standalone: true,
  imports: [
    CreationOffreModule,
  ]
})
@Injectable({ providedIn: 'root' })

export class CreationOffreFormComponent {
  constructor(public service: CreationOffreService) { }

  onSubmit(form: NgForm) {
    this.service.postEnregistrer()
      .subscribe({
        next: res => {
          console.log(res)
        },
        error: err => { console.log(err) }
      })
  }
}
