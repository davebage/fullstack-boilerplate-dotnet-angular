import { TestBed } from '@angular/core/testing';

import { RESTAPIService } from './restapi.service';
import { HttpClient, HttpHandler } from '@angular/common/http';

describe('RESTAPIService', () => {
  let service: RESTAPIService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ HttpClient, HttpHandler ]
    });
    service = TestBed.inject(RESTAPIService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
