import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DrinkingBuddyComponent } from './drinking-buddy.component';

describe('DrinkingBuddyComponent', () => {
  let component: DrinkingBuddyComponent;
  let fixture: ComponentFixture<DrinkingBuddyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DrinkingBuddyComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DrinkingBuddyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
