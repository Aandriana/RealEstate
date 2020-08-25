import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GetOfferCardForAgentComponent } from './get-offer-card-for-agent.component';

describe('GetOfferCardForAgentComponent', () => {
  let component: GetOfferCardForAgentComponent;
  let fixture: ComponentFixture<GetOfferCardForAgentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GetOfferCardForAgentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GetOfferCardForAgentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
