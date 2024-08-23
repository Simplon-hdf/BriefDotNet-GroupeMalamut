import { Component, Injectable, OnInit } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { FooterComponent } from '../footer/footer.component';
import { OffresModule } from './offres/offres.module';
import { ListeOffresService } from '../services/liste-offres.service';
import { Randonnee } from '../services/randonnee';
import { CommonModule } from '@angular/common';


@Component({
  standalone:true,
  selector: 'app-offre-randonnees',
  templateUrl: './offre-randonnees.component.html',
  styleUrl: './offre-randonnees.component.css',
  imports: [
    HeaderComponent,
    FooterComponent,
    OffresModule,
    CommonModule
  ]
})
@Injectable({ providedIn: 'root' })

export class OffreRandonneesComponent implements OnInit {

  randonnees!: Randonnee[];
  today: number;

  constructor(private service: ListeOffresService) {
    this.today = Date.now()
}

  ngOnInit() {
    this.service.getRandonnees().subscribe((res) => {
      this.randonnees = res;
      console.log(this.randonnees);
      this.randonnees.sort((a, b) => (a.date < b.date ? -1 : 1));
      console.log(this.randonnees);
    });

      return this.randonnees;
  }
}
