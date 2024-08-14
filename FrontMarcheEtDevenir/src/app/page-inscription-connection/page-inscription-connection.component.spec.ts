import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageInscriptionConnectionComponent } from './page-inscription-connection.component';

describe('PageInscriptionConnectionComponent', () => {
  let component: PageInscriptionConnectionComponent;
  let fixture: ComponentFixture<PageInscriptionConnectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PageInscriptionConnectionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PageInscriptionConnectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
