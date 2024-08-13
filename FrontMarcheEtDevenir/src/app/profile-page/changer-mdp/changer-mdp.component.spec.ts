import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangerMdpComponent } from './changer-mdp.component';

describe('ChangerMdpComponent', () => {
  let component: ChangerMdpComponent;
  let fixture: ComponentFixture<ChangerMdpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChangerMdpComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChangerMdpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
