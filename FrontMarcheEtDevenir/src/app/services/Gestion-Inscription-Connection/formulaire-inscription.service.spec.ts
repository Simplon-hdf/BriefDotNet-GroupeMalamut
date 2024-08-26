import { TestBed } from '@angular/core/testing';

import { FormulaireInscriptionService } from './formulaire-inscription.service';

describe('FormulaireInscriptionService', () => {
  let service: FormulaireInscriptionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FormulaireInscriptionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
