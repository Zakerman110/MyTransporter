import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EditOrder, OrderDto } from 'src/app/core/interfaces/order.interface';
import { orderStatus } from 'src/app/core/models/orderStatus';
import { OrderService } from 'src/app/core/services/order.service';
import { OrderDialogEditBoxComponent } from '../dialogs/order-dialog-edit-box/order-dialog-edit-box.component';

@Component({
  selector: 'app-admin-panel-order',
  templateUrl: './admin-panel-order.component.html',
  styleUrls: ['./admin-panel-order.component.css']
})
export class AdminPanelOrderComponent implements OnInit {
  
  loading: boolean = false;
  dataSource: OrderDto[] = [];
  displayedColumns: string[] = ['placeDate', 'status', 'routeStart', 'routeEnd', 'journeyStart', 'journeyEnd'];
  statusEnum: typeof orderStatus = orderStatus;
  // @ts-ignore
  editedOrder: EditOrder;

  constructor(public orderService: OrderService,
              public dialog: MatDialog) { }

  ngOnInit(): void {  
    this.loading = true;
    this.orderService.getOrders().subscribe(data => {
      this.dataSource = data;
      console.log("Received data: ", data);
      this.loading = false;
    })
  }

  editOrder(row: any) {
    console.log("Clicked row data:", row);
    this.openDialog("Edit", row)
  }

  openDialog(action: string, obj: any) {
    obj.action = action;
    const dialogRef = this.dialog.open(OrderDialogEditBoxComponent, {
      width: '255px',
      data:obj
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result.event == 'Edit'){
        this.editRowData(result.data);
      }
    });
  }

  editRowData(newRow: any){  
    this.editedOrder = {       
       orderId: parseInt(newRow.id),
       status: newRow.status,
       vehicleId: parseInt(newRow.vehicle.externalId),
       startPointId: parseInt(newRow.route.startPoint.id),
       endPointId: parseInt(newRow.route.endPoint.id),
       startDate: newRow.journey.startDate,
       endDate: newRow.journey.startDate
    };

    console.log("Edited order:", this.editedOrder);
    
    this.orderService.editOrder(this.editedOrder).subscribe();    
  }

}
