import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderDialogEditBoxComponent } from './order-dialog-edit-box.component';

describe('OrderDialogEditBoxComponent', () => {
  let component: OrderDialogEditBoxComponent;
  let fixture: ComponentFixture<OrderDialogEditBoxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderDialogEditBoxComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderDialogEditBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
