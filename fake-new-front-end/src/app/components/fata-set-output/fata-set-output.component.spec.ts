import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FataSetOutputComponent } from './fata-set-output.component';

describe('FataSetOutputComponent', () => {
  let component: FataSetOutputComponent;
  let fixture: ComponentFixture<FataSetOutputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FataSetOutputComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FataSetOutputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
