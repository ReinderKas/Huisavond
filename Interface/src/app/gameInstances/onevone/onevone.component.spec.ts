import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OnevoneComponent } from './onevone.component';

describe('OnevoneComponent', () => {
  let component: OnevoneComponent;
  let fixture: ComponentFixture<OnevoneComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OnevoneComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OnevoneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
