import { Component } from '@angular/core';
import { InformationPersonallesDisplayComponent } from './information-personalles-display/information-personalles-display.component';
import { ChangerMdpComponent } from './changer-mdp/changer-mdp.component';
import { HeaderComponent } from '../header/header.component';
import { FooterComponent } from '../footer/footer.component';

@Component({
  selector: 'app-profil-page',
  standalone: true,
  imports: [InformationPersonallesDisplayComponent, ChangerMdpComponent, HeaderComponent, FooterComponent],
  templateUrl: './profil-page.component.html',
  styleUrl: './profil-page.component.css'
})
export class ProfilPageComponent {

}
