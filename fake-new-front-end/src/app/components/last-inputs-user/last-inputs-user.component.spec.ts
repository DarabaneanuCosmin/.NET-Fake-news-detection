import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LastInputsUserComponent } from './last-inputs-user.component';

describe('LastInputsUserComponent', () => {
  let component: LastInputsUserComponent;
  let fixture: ComponentFixture<LastInputsUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LastInputsUserComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LastInputsUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
