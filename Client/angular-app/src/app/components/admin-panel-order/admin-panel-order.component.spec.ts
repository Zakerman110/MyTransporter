import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminPanelOrderComponent } from './admin-panel-order.component';

describe('AdminPanelOrderComponent', () => {
  let component: AdminPanelOrderComponent;
  let fixture: ComponentFixture<AdminPanelOrderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminPanelOrderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminPanelOrderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
