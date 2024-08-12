import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { ContactPageComponent } from './contact-page/contact-page.component';
import { CreationOffreComponent } from './creation-offre-page/creation-offre.component';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    ContactPageComponent,
    CreationOffreComponent,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
