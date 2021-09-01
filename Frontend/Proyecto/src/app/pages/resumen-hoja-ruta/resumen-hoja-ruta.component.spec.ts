import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResumenHojaRutaComponent } from './resumen-hoja-ruta.component';

describe('ResumenHojaRutaComponent', () => {
  let component: ResumenHojaRutaComponent;
  let fixture: ComponentFixture<ResumenHojaRutaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResumenHojaRutaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResumenHojaRutaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
