import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IncorrectInputComponent } from './incorrect-input.component';

describe('IncorrectInputComponent', () => {
  let component: IncorrectInputComponent;
  let fixture: ComponentFixture<IncorrectInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IncorrectInputComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IncorrectInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
