import { Component } from '@angular/core';
import { FooterComponent } from '../footer/footer.component';
import { HeaderComponent } from '../header/header.component';
 
@Component({
  selector: 'app-page-a-propos',
  standalone: true,
  imports: [
    HeaderComponent,
    FooterComponent
  ],
  templateUrl: './page-a-propos.component.html',
  styleUrl: './page-a-propos.component.css'
})
export class PageAProposComponent {

}
