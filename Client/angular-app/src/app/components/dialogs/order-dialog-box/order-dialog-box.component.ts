import { Component, Inject, OnInit, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NewOrder } from 'src/app/core/interfaces/order.interface';

export interface UsersData {
  name: string;
  id: number;
}

@Component({
  selector: 'app-order-dialog-box',
  templateUrl: './order-dialog-box.component.html',
  styleUrls: ['./order-dialog-box.component.css']
})
export class OrderDialogBoxComponent implements OnInit {

  action:string;
  local_data:any;
  vehicleType: string = '0';
  // @ts-ignore
  order: NewOrder = {};

  constructor(
    public dialogRef: MatDialogRef<OrderDialogBoxComponent>,    
    @Optional() @Inject(MAT_DIALOG_DATA) public data: UsersData) {
    console.log(data);
    this.local_data = {...data};
    this.action = this.local_data.action;
  }

  ngOnInit(): void {
  }
  
  doAction(){
    this.dialogRef.close({event:this.action,data:this.local_data});
  }
  closeDialog(){
    this.dialogRef.close({event:'Cancel'});
  }

  // @ts-ignore
  public onDate(event): void {
    console.log("Обрана дата :", this.local_data.startDate)

    this.order.userId = "Usd1U23jksGASfk@412125JK";
    this.order.vehicleId = 7;
    this.order.startPointId = 2;
    this.order.endPointId = 3;
    this.order.startDate = this.local_data.startDate;
    
    const body = JSON.stringify(this.order);
    console.log("Add Order");
    console.log(body);
    //this.local_data.startDate = event;
    //this.getData(this.roomsFilter.date);
  }

}
