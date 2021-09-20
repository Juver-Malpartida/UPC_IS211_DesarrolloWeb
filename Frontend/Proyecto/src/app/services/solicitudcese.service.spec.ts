import { TestBed } from '@angular/core/testing';

import { SolicitudceseService } from './solicitudcese.service';

describe('SolicitudceseService', () => {
  let service: SolicitudceseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SolicitudceseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
