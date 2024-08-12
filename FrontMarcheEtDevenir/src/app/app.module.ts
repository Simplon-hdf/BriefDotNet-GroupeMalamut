import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PageInscriptionConnectionComponent } from './page-inscription-connection/page-inscription-connection.component';
import { FormulaireInscriptionComponent } from './page-inscription-connection/formulaire-inscription/formulaire-inscription.component';
import { FormulaireConnexionComponent } from './page-inscription-connection/formulaire-connexion/formulaire-connexion.component';

@NgModule({
  declarations: [AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    PageInscriptionConnectionComponent,
    FormulaireInscriptionComponent,
    FormulaireConnexionComponent
  ],
  exports: [
    PageInscriptionConnectionComponent,
    AppComponent,
    FormulaireInscriptionComponent,
    FormulaireConnexionComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
