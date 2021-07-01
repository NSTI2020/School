import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChekingaccountCreateComponent } from './chekingaccount-create.component';

describe('ChekingaccountCreateComponent', () => {
  let component: ChekingaccountCreateComponent;
  let fixture: ComponentFixture<ChekingaccountCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChekingaccountCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChekingaccountCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
