import { ReactiveFormsModule } from '@angular/forms';
import { Component, Injectable } from '@angular/core';
import { FormulaireInscriptionServiceService } from '../../services/formulaire-inscription-service'


@Component({
  standalone : true,
  selector: 'app-formulaire-inscription',
  templateUrl: './formulaire-inscription.component.html',
  styleUrl: './formulaire-inscription.component.css',
  imports: [ReactiveFormsModule],
})
@Injectable({ providedIn: 'root' })
export class FormulaireInscriptionComponent {




  AjoutRandonneur() {
    
  }

 
 

}
