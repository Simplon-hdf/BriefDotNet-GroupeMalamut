import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InformationPersonallesDisplayComponent } from './information-personalles-display.component';

describe('InformationPersonallesDisplayComponent', () => {
  let component: InformationPersonallesDisplayComponent;
  let fixture: ComponentFixture<InformationPersonallesDisplayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InformationPersonallesDisplayComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InformationPersonallesDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
