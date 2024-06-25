import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SwitchDirectionComponent } from './switch-direction.component';

describe('SwitchDirectionComponent', () => {
  let component: SwitchDirectionComponent;
  let fixture: ComponentFixture<SwitchDirectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SwitchDirectionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SwitchDirectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
