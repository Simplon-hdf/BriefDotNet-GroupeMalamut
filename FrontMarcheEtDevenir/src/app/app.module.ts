import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PageInscriptionConnectionComponent } from './page-inscription-connection/page-inscription-connection.component';
import { provideHttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    PageInscriptionConnectionComponent,
    CommonModule,
    FormsModule
  ],
  exports: [
  ],
  providers: [provideHttpClient()],
  bootstrap: [AppComponent]
})
export class AppModule { }
