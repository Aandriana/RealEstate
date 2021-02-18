import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OfferResponseComponent } from './offer-response.component';

describe('OfferResponseComponent', () => {
  let component: OfferResponseComponent;
  let fixture: ComponentFixture<OfferResponseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OfferResponseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OfferResponseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
