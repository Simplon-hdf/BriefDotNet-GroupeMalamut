import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CorpsComponent } from './page-accueil/corps/corps.component';
import { HeaderComponent } from './page-accueil/header/header.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CorpsComponent, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
}