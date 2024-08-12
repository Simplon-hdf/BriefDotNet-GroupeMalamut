import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactPageComponent } from './contact-page/contact-page.component';
import { CreationOffreComponent } from './creation-offre-page/creation-offre.component';

const routes: Routes = [
  { path: '/admin/ajoutrandonnee', component: CreationOffreComponent },
  { path: '/contact', component: ContactPageComponent },

  { path: '**', redirectTo: '/contact' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
