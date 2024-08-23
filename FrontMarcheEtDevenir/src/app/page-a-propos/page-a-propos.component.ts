import { Component, Injectable, OnInit } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { FooterComponent } from '../footer/footer.component';
import { OffresModule } from '../offre-randonnees/offres/offres.module';
import { ListeOffresService } from '../services/liste-offres.service';
import { Randonnee } from '../services/randonnee';
import { CommonModule } from '@angular/common';
 
@Component({
  selector: 'app-page-a-propos',
  standalone: true,
  imports: [
    HeaderComponent,
    FooterComponent,
    OffresModule,
    CommonModule
  ],
  templateUrl: './page-a-propos.component.html',
  styleUrl: './page-a-propos.component.css'
})
  @Injectable({ providedIn: 'root' })
export class PageAProposComponent implements OnInit {

  randonnees!: Randonnee[];
  today: number;
  dateFormat: any = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };

  constructor(private service: ListeOffresService) {
    this.today = Date.now()
  }

  ngOnInit() {
    this.service.getRandonnees().subscribe((res) => {
      this.randonnees = res;
      this.randonnees.sort((a, b) => ((a.date) < b.date ? -1 : 1));
    });

    return this.randonnees;
  }

  prettyDate(date: any) {

    return date.toLocaleDateString("fr-FR", this.dateFormat);
  }

  dateParse(date: any) {
    return Date.parse(date);
  }
}
