import { Component, NgModule } from '@angular/core';
import { FormulaireInscriptionComponent } from './formulaire-inscription/formulaire-inscription.component';
import { FormulaireConnexionComponent } from './formulaire-connexion/formulaire-connexion.component';

@Component({
  standalone: true,
  selector: 'app-page-inscription-connection',
  templateUrl: './page-inscription-connection.component.html',
  styleUrl: './page-inscription-connection.component.css',
  imports: [FormulaireInscriptionComponent, FormulaireConnexionComponent]  
})
export class PageInscriptionConnectionComponent {

}
