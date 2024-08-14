import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConceptComponent } from './concept/concept.component';
import { OffreRandonneesComponent } from './offre-randonnees/offre-randonnees.component';

const routes: Routes = [
  { path: 'concept', component: ConceptComponent },
  { path: 'offreRandonnees', component: OffreRandonneesComponent, }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
