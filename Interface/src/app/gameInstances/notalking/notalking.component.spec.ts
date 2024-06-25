import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotalkingComponent } from './notalking.component';

describe('NotalkingComponent', () => {
  let component: NotalkingComponent;
  let fixture: ComponentFixture<NotalkingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NotalkingComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NotalkingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
