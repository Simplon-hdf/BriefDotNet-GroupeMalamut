import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ConceptComponent } from './concept/concept.component';
import { OffreRandonneesComponent } from './offre-randonnees/offre-randonnees.component';

@NgModule({
  declarations: [
    AppComponent,
    ConceptComponent,
    OffreRandonneesComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
