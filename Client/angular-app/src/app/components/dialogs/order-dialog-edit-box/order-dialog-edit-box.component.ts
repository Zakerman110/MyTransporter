import { Component, Inject, OnInit, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CityService } from 'src/app/core/services/city.service';
import { OrderService } from 'src/app/core/services/order.service';
import { UsersData } from '../order-dialog-box/order-dialog-box.component';

@Component({
  selector: 'app-order-dialog-edit-box',
  templateUrl: './order-dialog-edit-box.component.html',
  styleUrls: ['./order-dialog-edit-box.component.css']
})
export class OrderDialogEditBoxComponent implements OnInit {
  
  action:string;
  local_data:any;
  // @ts-ignore
  vehicles: VehicleOrderDto[] = [];
  // @ts-ignore
  cities: CityDto[] = [];

  constructor(
    public dialogRef: MatDialogRef<OrderDialogEditBoxComponent>,    
    @Optional() @Inject(MAT_DIALOG_DATA) public data: UsersData,
    public orderService: OrderService,
    public cityService: CityService) {
    console.log("Data in edit dialog:", data);
    this.local_data = {...data};
    this.action = this.local_data.action;
    console.log("local_date of edit dialog:", this.local_data)
    this.cityService.getCities().subscribe(data => { this.cities = data })
    this.orderService.getFreeVehicles(this.local_data.journey.startDate).subscribe(data => { this.vehicles = data })
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
    this.orderService.getFreeVehicles(this.local_data.startDate).subscribe(data => { this.vehicles = data })
  }

  compareObjects(o1: any, o2: any): boolean {
    return o1.name === o2.name && o1.externalId === o2.externalId;
  }

}
