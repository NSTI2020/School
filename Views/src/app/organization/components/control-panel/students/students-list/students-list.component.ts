import { Component, OnInit } from '@angular/core';
import { StudentsServices } from '../../../../services/admin/students/students.services';
import { Student } from 'src/app/organization/interfaces/Student';
import { Discipline } from 'src/app/organization/interfaces/Discipline';

@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styleUrls: ['./students-list.component.css'],
  providers: [StudentsServices]
})
export class StudentsListComponent implements OnInit {
  constructor(private studentsServices: StudentsServices) { }


  getAllStudentsreturn: Student[];
  langs: any[];


  public getDisciplines(): Promise<any[]> {
    return new Promise((resolve, reject) => {
      resolve(this.langs = this.getAllStudentsreturn.filter(_disciplines => _disciplines.discipline))
    })
  }


  getAllStudens() {
    this.studentsServices.ApiAll().subscribe(
      (_returnStudens: Student[]) => {
        this.getAllStudentsreturn = _returnStudens
        console.log(_returnStudens);
      }, error => {
        console.log(error);
      }
    )
  }

  ngOnInit(): void {
    this.getAllStudens();
    this.getDisciplines();

  }

}
