import { Component, Inject, OnInit, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

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

}
