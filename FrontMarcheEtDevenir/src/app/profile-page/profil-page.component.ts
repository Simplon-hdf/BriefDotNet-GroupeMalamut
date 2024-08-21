import { Component } from '@angular/core';
// import { InformationPersonallesDisplayComponent } from './information-personalles-display/information-personalles-display.component';
import { ChangerMdpComponent } from './changer-mdp/changer-mdp.component';
import { HeaderComponent } from '../header/header.component';
import { FooterComponent } from '../footer/footer.component';

@Component({
  selector: 'app-profil-page',
  standalone: true,
<<<<<<< HEAD
  // imports: [ InformationPersonallesDisplayComponent, ChangerMdpComponent],
=======
  imports: [InformationPersonallesDisplayComponent, ChangerMdpComponent, HeaderComponent, FooterComponent],
>>>>>>> 8ed4c5dcafaeedbb8b21ed740a50795cfcba1d95
  templateUrl: './profil-page.component.html',
  styleUrl: './profil-page.component.css'
})
export class ProfilPageComponent {

}
