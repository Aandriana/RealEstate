import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogDeletingSureComponent } from './dialog-deleting-sure.component';

describe('DialogDeletingSureComponent', () => {
  let component: DialogDeletingSureComponent;
  let fixture: ComponentFixture<DialogDeletingSureComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogDeletingSureComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogDeletingSureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
