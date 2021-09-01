import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AsignacionServiciosComponent } from './asignacion-servicios.component';

describe('AsignacionServiciosComponent', () => {
  let component: AsignacionServiciosComponent;
  let fixture: ComponentFixture<AsignacionServiciosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AsignacionServiciosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AsignacionServiciosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
