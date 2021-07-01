import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import {StudentsServices} from 'src/app/organization/services/admin/students/students.services'

@Component({
  selector: 'app-student-create',
  templateUrl: './student-create.component.html',
  styleUrls: ['./student-create.component.css']
})
export class StudentCreateComponent implements OnInit {




  constructor(
    private _Ss:StudentsServices 
  ) { }






  ngOnInit(): void {
  }

}
