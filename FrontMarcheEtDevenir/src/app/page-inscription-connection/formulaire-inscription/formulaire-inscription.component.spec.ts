import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormulaireInscriptionComponent } from './formulaire-inscription.component';

describe('FormulaireInscriptionComponent', () => {
  let component: FormulaireInscriptionComponent;
  let fixture: ComponentFixture<FormulaireInscriptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FormulaireInscriptionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormulaireInscriptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
