import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPropertiesPhotosComponent } from './edit-properties-photos.component';

describe('EditPropertiesPhotosComponent', () => {
  let component: EditPropertiesPhotosComponent;
  let fixture: ComponentFixture<EditPropertiesPhotosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditPropertiesPhotosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditPropertiesPhotosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
