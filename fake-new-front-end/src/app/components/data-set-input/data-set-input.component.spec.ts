import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DataSetInputComponent } from './data-set-input.component';

describe('DataSetInputComponent', () => {
  let component: DataSetInputComponent;
  let fixture: ComponentFixture<DataSetInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DataSetInputComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DataSetInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
