import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RandomAmountComponent } from './random-amount.component';

describe('RandomAmountComponent', () => {
  let component: RandomAmountComponent;
  let fixture: ComponentFixture<RandomAmountComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RandomAmountComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RandomAmountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
