import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreationOffreFormComponent } from './creation-offre-form.component';

describe('CreationOffreFormComponent', () => {
  let component: CreationOffreFormComponent;
  let fixture: ComponentFixture<CreationOffreFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CreationOffreFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreationOffreFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
