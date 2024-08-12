import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CorpsComponent } from './page-accueil/corps/corps.component';
import { HeaderComponent } from './page-accueil/header/header.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CorpsComponent, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
<<<<<<< HEAD:FRONTMarcheEtDeviens/src/app/app.component.ts
  
}
=======
  title = 'FrontMarcheEtDevenir';
}
>>>>>>> 22243d4468b9e305ae8d0d807af67e99ce4bc335:FrontMarcheEtDevenir/src/app/app.component.ts
