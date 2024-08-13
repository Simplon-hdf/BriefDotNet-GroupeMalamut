import { Component } from '@angular/core';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrl: './contact-form.component.css',
  standalone: true,
  imports: [
  ]
})
export class ContactFormComponent {

  submitted = false;
  onSubmit() { this.submitted = true; }
}
