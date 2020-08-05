import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogPropertyFilterComponent } from './dialog-property-filter.component';

describe('DialogPropertyFilterComponent', () => {
  let component: DialogPropertyFilterComponent;
  let fixture: ComponentFixture<DialogPropertyFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogPropertyFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogPropertyFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
