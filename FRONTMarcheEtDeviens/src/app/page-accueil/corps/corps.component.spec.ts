import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CorpsComponent } from './corps.component';

describe('CorpsComponent', () => {
  let component: CorpsComponent;
  let fixture: ComponentFixture<CorpsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CorpsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CorpsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
