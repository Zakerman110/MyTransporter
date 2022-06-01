import { Component, OnInit } from '@angular/core';
import { OrderDto } from 'src/app/core/interfaces/order.interface';
import { orderStatus } from 'src/app/core/models/orderStatus';
import { OrderService } from 'src/app/core/services/order.service';

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

  constructor(public orderService: OrderService) { }

  ngOnInit(): void {  
    this.loading = true;
    this.orderService.getOrders().subscribe(data => {
      this.dataSource = data;
      console.log(data);
      this.loading = false;
    })
  }

  editOrder(row: any) {
    console.log("Clicked row data:", row);
  }

}
