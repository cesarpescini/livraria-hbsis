import { TestBed, inject } from '@angular/core/testing';

import { LivrariaService } from './livraria.service';

describe('LivrariaService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LivrariaService]
    });
  });

  it('should be created', inject([LivrariaService], (service: LivrariaService) => {
    expect(service).toBeTruthy();
  }));
});
