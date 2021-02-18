import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PropertyPageComponent } from './property.component';

describe('PropertyPageComponent', () => {
  let component: PropertyPageComponent;
  let fixture: ComponentFixture<PropertyPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PropertyPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PropertyPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
