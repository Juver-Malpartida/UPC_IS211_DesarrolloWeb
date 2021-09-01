import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AsignacionHerramComponent } from './asignacion-herram.component';

describe('AsignacionHerramComponent', () => {
  let component: AsignacionHerramComponent;
  let fixture: ComponentFixture<AsignacionHerramComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AsignacionHerramComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AsignacionHerramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
