import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoveneighborsComponent } from './loveneighbors.component';

describe('LoveneighborsComponent', () => {
  let component: LoveneighborsComponent;
  let fixture: ComponentFixture<LoveneighborsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LoveneighborsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoveneighborsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
