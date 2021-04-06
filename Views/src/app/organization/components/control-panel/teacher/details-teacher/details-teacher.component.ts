import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Teacher } from 'src/app/organization/interfaces/Teacher';
import { TeacherServices } from 'src/app/organization/services/admin/teacher/teacherServices';

@Component({
  selector: 'app-details-teacher',
  templateUrl: './details-teacher.component.html',
  styleUrls: ['./details-teacher.component.css'],
  providers:[TeacherServices]
})
export class DetailsTeacherComponent implements OnInit {
  

  constructor(
    //private _TeacherService: TeacherServices
    @Inject(MAT_DIALOG_DATA) public data: Teacher
    ) { }



  ngOnInit(): void {
  }

}
