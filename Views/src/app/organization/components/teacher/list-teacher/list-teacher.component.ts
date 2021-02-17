import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EditTeacherComponent } from '../edit-teacher/edit-teacher.component';



@Component({
  selector: 'app-list-teacher',
  templateUrl: './list-teacher.component.html',
  styleUrls: ['./list-teacher.component.css']
})
export class ListTeacherComponent implements OnInit {

  template: any;
  constructor(private dialog: MatDialog) { }


  openDialog() {
    const dialogRef = this.dialog.open(EditTeacherComponent);
  }


  ngOnInit(): void {
  }

}
