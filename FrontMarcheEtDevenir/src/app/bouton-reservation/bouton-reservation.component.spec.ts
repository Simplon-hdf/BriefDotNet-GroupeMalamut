import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BoutonReservationComponent } from './bouton-reservation.component';

describe('BoutonReservationComponent', () => {
  let component: BoutonReservationComponent;
  let fixture: ComponentFixture<BoutonReservationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BoutonReservationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BoutonReservationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
