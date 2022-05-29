import { Component, ViewChild, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { order } from 'src/app/core/models/order';
import { orderStatus } from 'src/app/core/models/orderStatus';
import { OrderService } from 'src/app/core/services/order.service';


@Component({
  selector: 'app-myaccount',
  templateUrl: './myaccount.component.html',
  styleUrls: ['./myaccount.component.css']
})
export class MyaccountComponent implements OnInit {

  userData: any;
  displayedColumns: string[] = ['placeDate', 'status', 'routeStart', 'routeEnd'];
  dataSource: order[] = [];
  displayDataSource: order[] = [];
  // @ts-ignore
  @ViewChild(MatTable,{static:true}) table: MatTable<any>;
  statusEnum: typeof orderStatus = orderStatus;
  loading: boolean = false;

  constructor(public orderService: OrderService,
    public oidcSecurityService: OidcSecurityService,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.oidcSecurityService.userData$.subscribe(user => { 
      this.userData = user.userData 
    });    
    this.loading = true;
    this.orderService.getOrdersByUserId(this.userData.sub).subscribe(data => {
      this.dataSource = data;
      this.displayDataSource = data;
      console.log(data);
      this.loading = false;
    })
  }

  getActiveOrders(): void {
    this.displayDataSource = this.dataSource.filter(obj => {
      return obj.status < 3;
    })
  }

  getClosedOrders(): void {
    this.displayDataSource = this.dataSource.filter(obj => {
      return obj.status > 2;
    })
  }

  /*openDialog(action: string, obj: any) {
    obj.action = action;
    const dialogRef = this.dialog.open(DialogBoxComponent, {
      width: '300px',
      data:obj
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result.event == 'Add'){
        this.addRowData(result.data);
      }else if(result.event == 'Update'){
        this.updateRowData(result.data);
      }else if(result.event == 'Delete'){
        this.deleteRowData(result.data);
      }
    });
  }*/

}
