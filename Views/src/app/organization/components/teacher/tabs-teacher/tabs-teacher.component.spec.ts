import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TabsTeacherComponent } from './tabs-teacher.component';

describe('TabsTeacherComponent', () => {
  let component: TabsTeacherComponent;
  let fixture: ComponentFixture<TabsTeacherComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TabsTeacherComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TabsTeacherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
