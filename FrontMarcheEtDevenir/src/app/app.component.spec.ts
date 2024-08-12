import { TestBed } from '@angular/core/testing';
<<<<<<< HEAD:FRONTMarcheEtDeviens/src/app/app.component.spec.ts
=======
import { RouterModule } from '@angular/router';
>>>>>>> 22243d4468b9e305ae8d0d807af67e99ce4bc335:FrontMarcheEtDevenir/src/app/app.component.spec.ts
import { AppComponent } from './app.component';

describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
<<<<<<< HEAD:FRONTMarcheEtDeviens/src/app/app.component.spec.ts
      imports: [AppComponent],
=======
      imports: [
        RouterModule.forRoot([])
      ],
      declarations: [
        AppComponent
      ],
>>>>>>> 22243d4468b9e305ae8d0d807af67e99ce4bc335:FrontMarcheEtDevenir/src/app/app.component.spec.ts
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

<<<<<<< HEAD:FRONTMarcheEtDeviens/src/app/app.component.spec.ts
  it(`should have the 'FRONTMarcheEtDeviens' title`, () => {
=======
  it(`should have as title 'FrontMarcheEtDevenir'`, () => {
>>>>>>> 22243d4468b9e305ae8d0d807af67e99ce4bc335:FrontMarcheEtDevenir/src/app/app.component.spec.ts
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('FrontMarcheEtDevenir');
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('h1')?.textContent).toContain('Hello, FrontMarcheEtDevenir');
  });
});
