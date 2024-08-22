import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

/*pour ajouter un service à un composant standalone, on necessite un passage par module.
le module recupère les mdules ng, forms et common pour pouvoir les utiliser sur notre composant*/ 

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FormsModule,
  ],
  exports: [
    FormsModule
  ]
})
export class CreationOffreModule {

}
