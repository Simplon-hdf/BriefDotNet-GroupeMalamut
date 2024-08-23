import { TestBed } from '@angular/core/testing';
import { ConnectionService } from './connection.service';

/**
 * Suite de tests pour le service ConnectionService.
 * 
 * Cette suite de tests utilise le framework de test Angular pour vérifier
 * le bon fonctionnement du service ConnectionService.
 */
describe('ConnectionService', () => {
  let service: ConnectionService;

  /**
   * Configuration du module de test avant chaque test.
   * 
   * Cette fonction est exécutée avant chaque test individuel. Elle configure
   * le module de test Angular et injecte une instance du service ConnectionService
   * dans la variable `service`.
   */
  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConnectionService);
  });

  /**
   * Test pour vérifier si le service est créé avec succès.
   * 
   * Ce test vérifie que l'instance du service ConnectionService est correctement
   * créée et définie. La méthode `toBeTruthy` est utilisée pour
   * s'assurer que `service` n'est ni `null` ni `undefined`.
   */
  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});