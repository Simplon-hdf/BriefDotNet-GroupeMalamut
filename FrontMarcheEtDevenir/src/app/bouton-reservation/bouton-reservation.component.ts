import { Component } from '@angular/core';

@Component({
  selector: 'app-bouton-reservation',
  templateUrl: './bouton-reservation.component.html',
  styleUrl: './bouton-reservation.component.css'
})
export class BoutonReservationComponent {
  changeColor() {
    // a chaque clic -> background.color => random
  }
}
