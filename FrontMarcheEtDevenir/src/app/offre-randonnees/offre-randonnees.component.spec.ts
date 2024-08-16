import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OffreRandonneesComponent } from './offre-randonnees.component';

describe('OffreRandonneesComponent', () => {
  let component: OffreRandonneesComponent;
  let fixture: ComponentFixture<OffreRandonneesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OffreRandonneesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OffreRandonneesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
