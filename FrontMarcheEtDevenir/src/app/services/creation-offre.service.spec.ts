import { TestBed } from '@angular/core/testing';
import { CreationOffreService } from './creation-offre.service';

/**
 * Suite de tests pour le service CreationOffreService.
 * 
 * Cette suite de tests utilise le framework de test Angular pour vérifier
 * le bon fonctionnement du service CreationOffreService.
 */
describe('CreationOffreService', () => {
  let service: CreationOffreService;

  /**
   * Configuration du module de test avant chaque test.
   * 
   * Cette fonction est exécutée avant chaque test individuel. Elle configure
   * le module de test Angular et injecte une instance du service CreationOffreService
   * dans la variable `service`.
   */
  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CreationOffreService);
  });

  /**
   * Test pour vérifier si le service est créé avec succès.
   * 
   * Ce test vérifie que l'instance du service CreationOffreService est correctement
   * créée et définie. La méthode `toBeTruthy` de Jasmine est utilisée pour
   * s'assurer que `service` n'est ni `null` ni `undefined`.
   */
  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});