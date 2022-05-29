import { Component, ViewChild, OnInit } from '@angular/core';
import { MatTable } from '@angular/material/table';

@Component({
  selector: 'app-myaccount',
  templateUrl: './myaccount.component.html',
  styleUrls: ['./myaccount.component.css']
})
export class MyaccountComponent implements OnInit {

  displayedColumns: string[] = ['name', 'age', 'designation', 'mobileNumber'];
  dataSource: any;
  // @ts-ignore
  @ViewChild(MatTable,{static:true}) table: MatTable<any>;

  constructor() { }

  ngOnInit(): void {
  }

}
