import { Component, ViewChild, OnInit } from '@angular/core';
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
  // @ts-ignore
  @ViewChild(MatTable,{static:true}) table: MatTable<any>;
  statusEnum: typeof orderStatus = orderStatus;

  constructor(public orderService: OrderService,
    public oidcSecurityService: OidcSecurityService) { }

  ngOnInit(): void {
    this.oidcSecurityService.userData$.subscribe(user => { 
      this.userData = user.userData 
    });
    this.orderService.getOrdersByUserId(this.userData.sub).subscribe(data => {
      this.dataSource = data;
      console.log(data);
    })
  }

}
