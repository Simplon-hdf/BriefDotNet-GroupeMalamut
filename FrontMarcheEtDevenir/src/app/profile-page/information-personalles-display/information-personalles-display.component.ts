import { Component, OnInit } from '@angular/core';
import { IdentiteUtilisateurService } from '../../services/identite-utilisateur.service';
//import { Randonneur} from '../../services/randonneur.model';

@Component({
  selector: 'app-information-personalles-display',
  standalone: true,
  imports: [],
  templateUrl: './information-personalles-display.component.html',
  styleUrl: './information-personalles-display.component.css'
})
export class InformationPersonallesDisplayComponent implements OnInit {
  constructor(public service: IdentiteUtilisateurService) { }
  ngOnInit(): void {this.service.getInformationUtilisateur() }
}
