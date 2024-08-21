import { Component } from '@angular/core';
import { CorpsComponent } from './corps/corps.component';
import { HeaderComponent } from '../header/header.component';
import { FooterComponent } from '../footer/footer.component';

@Component({
  selector: 'page-accueil',
  standalone: true,
  imports: [CorpsComponent, HeaderComponent, FooterComponent],
  templateUrl: './page-accueil.component.html',
  styleUrls: ['./page-accueil.component.css']
})
export class PageAccueilComponent {}
