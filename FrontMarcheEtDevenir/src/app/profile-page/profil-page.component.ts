import { Component } from '@angular/core';
import { InformationPersonallesDisplayComponent } from './information-personalles-display/information-personalles-display.component';
import { ChangerMdpComponent } from './changer-mdp/changer-mdp.component';

@Component({
  selector: 'app-profil-page',
  standalone: true,
  imports: [ InformationPersonallesDisplayComponent, ChangerMdpComponent],
  templateUrl: './profil-page.component.html',
  styleUrl: './profil-page.component.css'
})
export class ProfilPageComponent {

}
