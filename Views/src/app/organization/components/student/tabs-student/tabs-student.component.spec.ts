import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TabsStudentComponent } from './tabs-student.component';

describe('TabsStudentComponent', () => {
  let component: TabsStudentComponent;
  let fixture: ComponentFixture<TabsStudentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TabsStudentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TabsStudentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
