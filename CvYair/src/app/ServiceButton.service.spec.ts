/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ServiceButtonService } from './ServiceButton.service';

describe('Service: ServiceButton', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ServiceButtonService]
    });
  });

  it('should ...', inject([ServiceButtonService], (service: ServiceButtonService) => {
    expect(service).toBeTruthy();
  }));
});
