import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SolicitudDesvinculacionComponent } from './solicitud-desvinculacion.component';

describe('SolicitudDesvinculacionComponent', () => {
  let component: SolicitudDesvinculacionComponent;
  let fixture: ComponentFixture<SolicitudDesvinculacionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SolicitudDesvinculacionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SolicitudDesvinculacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
