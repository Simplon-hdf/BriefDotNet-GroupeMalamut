import { Component } from '@angular/core';
import { ContactFormComponent } from './contact-form/contact-form.component';
import { FooterComponent } from '../footer/footer.component';
import { HeaderComponent } from '../header/header.component';

@Component({
  selector: 'app-contact-page',
  templateUrl: './contact-page.component.html',
  styleUrl: './contact-page.component.css',
  standalone: true,
  imports: [
    ContactFormComponent,
    HeaderComponent,
    FooterComponent
  ]
})
export class ContactPageComponent {

}
