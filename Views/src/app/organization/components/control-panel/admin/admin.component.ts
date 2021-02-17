import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {


  list: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 0];




  constructor() { }

  ngOnInit(): void {
  }

}
