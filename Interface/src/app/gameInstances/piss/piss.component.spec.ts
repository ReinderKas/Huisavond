import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PissComponent } from './piss.component';

describe('PissComponent', () => {
  let component: PissComponent;
  let fixture: ComponentFixture<PissComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PissComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PissComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
