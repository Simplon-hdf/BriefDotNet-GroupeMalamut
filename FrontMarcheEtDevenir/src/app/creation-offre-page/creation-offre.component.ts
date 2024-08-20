import { Component } from '@angular/core';
import { CreationOffreFormComponent } from './creation-offre-form/creation-offre-form.component'
import { HeaderComponent } from '../header/header.component';
import { FooterComponent } from '../footer/footer.component';

@Component({
  selector: 'app-creation-offre-page',
  templateUrl: './creation-offre.component.html',
  styleUrl: './creation-offre.component.css',
  standalone: true,
  imports: [
    CreationOffreFormComponent,
    HeaderComponent,
    FooterComponent
  ]
})
export class CreationOffreComponent {

}
