import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoubledownComponent } from './doubledown.component';

describe('DoubledownComponent', () => {
  let component: DoubledownComponent;
  let fixture: ComponentFixture<DoubledownComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DoubledownComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DoubledownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
