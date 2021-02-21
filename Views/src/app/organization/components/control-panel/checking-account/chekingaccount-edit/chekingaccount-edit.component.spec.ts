import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChekingaccountEditComponent } from './chekingaccount-edit.component';

describe('ChekingaccountEditComponent', () => {
  let component: ChekingaccountEditComponent;
  let fixture: ComponentFixture<ChekingaccountEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChekingaccountEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChekingaccountEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
