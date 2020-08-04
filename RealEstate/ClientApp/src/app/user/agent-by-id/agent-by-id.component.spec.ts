import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AgentByIdComponent } from './agent-by-id.component';

describe('AgentByIdComponent', () => {
  let component: AgentByIdComponent;
  let fixture: ComponentFixture<AgentByIdComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AgentByIdComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AgentByIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
