import { Component, Injectable, OnInit } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { FooterComponent } from '../footer/footer.component';
import { OffresModule } from './offres/offres.module';
import { ListeOffresService } from '../services/liste-offres.service';
import { ParticipantsService } from '../services/participants.service';
import { Randonnee } from '../services/randonnee';
import { CommonModule } from '@angular/common';
import { Participants } from '../services/participants';


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
  listPart!: Participants[];
  today: number;
  dateFormat: any = { weekday: 'long',  year: 'numeric',month: 'long', day: 'numeric' };

  constructor(private offreService: ListeOffresService, private participantService: ParticipantsService) {
    this.today = Date.now()
    this.participantService.get().subscribe(res => {
      this.listPart = res;
      console.log(this.listPart[20]);
    });
}

  ngOnInit() {
    this.offreService.getRandonnees().subscribe((res) => {
      this.randonnees = res;
      this.randonnees.sort((a, b) => ((a.date) < b.date ? -1 : 1));
    });
      console.log('init');
      return this.randonnees;
  }

  fetchParticipantFor(id: string) {
    return this.listPart.filter((part) => {
      return part.randonneeId == id;
    }).length;
  }

  prettyDate(date: any) {

    return date.toLocaleDateString("fr-FR", this.dateFormat);
  }

  dateParse(date: any) {
    return Date.parse(date);
  }
}
