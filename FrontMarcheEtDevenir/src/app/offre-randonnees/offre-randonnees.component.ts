import { Component } from '@angular/core';
import { HeaderComponent } from "../header/header.component";
import { FooterComponent } from '../footer/footer.component'; 

@Component({
  standalone:true,
  selector: 'app-offre-randonnees',
  templateUrl: './offre-randonnees.component.html',
  styleUrl: './offre-randonnees.component.css',
  imports: [HeaderComponent, FooterComponent]
})
export class OffreRandonneesComponent {

}
