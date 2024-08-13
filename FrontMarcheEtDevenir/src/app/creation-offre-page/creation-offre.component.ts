import { Component } from '@angular/core';
import { CreationOffreFormComponent } from './creation-offre-form/creation-offre-form.component'

@Component({
  selector: 'app-creation-offre-page',
  templateUrl: './creation-offre.component.html',
  styleUrl: './creation-offre.component.css',
  standalone: true,
  imports: [
    CreationOffreFormComponent,
  ]
})
export class CreationOffreComponent {

}
