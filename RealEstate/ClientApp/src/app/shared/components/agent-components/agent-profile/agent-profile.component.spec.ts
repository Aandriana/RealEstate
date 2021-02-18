import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AgentProfilePageComponent } from './agent-profile.component';

describe('AgentProfilePageComponent', () => {
  let component: AgentProfilePageComponent;
  let fixture: ComponentFixture<AgentProfilePageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AgentProfilePageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AgentProfilePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
