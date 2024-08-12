import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageInscriptionConnectionComponent } from './page-inscription-connection/page-inscription-connection.component'

const routes: Routes = [
  {
  path: '', component: PageInscriptionConnectionComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
