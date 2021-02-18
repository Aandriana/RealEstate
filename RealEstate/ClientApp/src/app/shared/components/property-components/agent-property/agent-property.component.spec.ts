import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AgentPropertyComponent } from './agent-property.component';

describe('AgentPropertyComponent', () => {
  let component: AgentPropertyComponent;
  let fixture: ComponentFixture<AgentPropertyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AgentPropertyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AgentPropertyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
