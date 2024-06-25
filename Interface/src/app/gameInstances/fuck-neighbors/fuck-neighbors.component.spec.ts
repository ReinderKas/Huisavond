import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FuckNeighborsComponent } from './fuck-neighbors.component';

describe('FuckNeighborsComponent', () => {
  let component: FuckNeighborsComponent;
  let fixture: ComponentFixture<FuckNeighborsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FuckNeighborsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FuckNeighborsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
