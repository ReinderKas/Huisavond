import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Phase10Component } from './phase10.component';

describe('Phase10Component', () => {
  let component: Phase10Component;
  let fixture: ComponentFixture<Phase10Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Phase10Component]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Phase10Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
