import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConceptComponent } from './concept/concept.component';
import { OffreRandonneesComponent } from './offre-randonnees/offre-randonnees.component';
import { ContactPageComponent } from './contact-page/contact-page.component';
import { CreationOffreComponent } from './creation-offre-page/creation-offre.component';
import { ProfilPageComponent } from './profile-page/profil-page.component';
import { PageAccueilComponent } from './page-accueil/page-accueil.component';
import { PageInscriptionConnectionComponent } from './page-inscription-connection/page-inscription-connection.component';
import { PageAProposComponent } from './page-a-propos/page-a-propos.component';


// Définition des routes de l'application (chemin d'accès)
const routes: Routes = [
  { path: 'admin/ajoutrandonnee', component: CreationOffreComponent },
   { path: 'user/profil', component: ProfilPageComponent },
   { path: 'concept', component: ConceptComponent },
   { path: 'offreRandonnees', component: OffreRandonneesComponent},
  { path: 'contact', component: ContactPageComponent },
  { path: '', pathMatch: 'full', component: PageAccueilComponent },
  { path: 'login', component: PageInscriptionConnectionComponent },
  { path: 'about', component: PageAProposComponent },

  { path: '**', redirectTo: '' }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
  
}
