import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderDialogBoxComponent } from './order-dialog-box.component';

describe('OrderDialogBoxComponent', () => {
  let component: OrderDialogBoxComponent;
  let fixture: ComponentFixture<OrderDialogBoxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderDialogBoxComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderDialogBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
