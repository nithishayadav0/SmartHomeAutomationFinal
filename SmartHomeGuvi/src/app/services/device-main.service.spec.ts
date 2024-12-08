import { TestBed } from '@angular/core/testing';

import { DeviceMainService } from './device-main.service';

describe('DeviceMainService', () => {
  let service: DeviceMainService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DeviceMainService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
