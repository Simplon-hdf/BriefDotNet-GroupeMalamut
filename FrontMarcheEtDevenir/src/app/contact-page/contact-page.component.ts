import { Component } from '@angular/core';
import { ContactFormComponent } from './contact-form/contact-form.component';

@Component({
  selector: 'app-contact-page',
  templateUrl: './contact-page.component.html',
  styleUrl: './contact-page.component.css',
  standalone: true,
  imports: [
    ContactFormComponent,
  ]
})
export class ContactPageComponent {

}
