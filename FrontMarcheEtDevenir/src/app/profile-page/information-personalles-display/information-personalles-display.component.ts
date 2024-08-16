import { Component } from '@angular/core';

@Component({
  selector: 'app-information-personalles-display',
  standalone: true,
  imports: [],
  templateUrl: './information-personalles-display.component.html',
  styleUrl: './information-personalles-display.component.css'
})
export class InformationPersonallesDisplayComponent {
  submitted = false;
  onSubmit() { this.submitted = true; }
}
