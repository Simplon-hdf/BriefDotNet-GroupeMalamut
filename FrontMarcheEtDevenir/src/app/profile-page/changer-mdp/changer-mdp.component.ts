import { Component } from '@angular/core';

@Component({
  selector: 'app-changer-mdp',
  standalone: true,
  imports: [],
  templateUrl: './changer-mdp.component.html',
  styleUrl: './changer-mdp.component.css'
})
export class ChangerMdpComponent {
  submitted = false;
  onSubmit() { this.submitted = true; }
}
