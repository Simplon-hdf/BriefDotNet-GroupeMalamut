import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormulaireConnexionComponent } from './formulaire-connexion.component';

describe('FormulaireConnexionComponent', () => {
  let component: FormulaireConnexionComponent;
  let fixture: ComponentFixture<FormulaireConnexionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FormulaireConnexionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormulaireConnexionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
