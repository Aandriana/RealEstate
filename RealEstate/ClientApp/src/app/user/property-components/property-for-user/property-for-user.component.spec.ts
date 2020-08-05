import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PropertyForUserComponent } from './property-for-user.component';

describe('PropertyForUserComponent', () => {
  let component: PropertyForUserComponent;
  let fixture: ComponentFixture<PropertyForUserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PropertyForUserComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PropertyForUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
