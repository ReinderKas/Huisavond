import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChugComponent } from './chug.component';

describe('ChugComponent', () => {
  let component: ChugComponent;
  let fixture: ComponentFixture<ChugComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChugComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChugComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
