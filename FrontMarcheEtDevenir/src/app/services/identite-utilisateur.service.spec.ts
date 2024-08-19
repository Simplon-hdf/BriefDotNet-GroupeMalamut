import { TestBed } from '@angular/core/testing';

import { IdentiteUtilisateurService } from './identite-utilisateur.service';

describe('IdentiteUtilisateurService', () => {
  let service: IdentiteUtilisateurService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IdentiteUtilisateurService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
