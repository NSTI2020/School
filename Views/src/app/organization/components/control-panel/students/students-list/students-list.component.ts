import { Component, OnInit } from '@angular/core';
import { StudentsServices } from '../../../../services/admin/students/students.services';
import { Student } from 'src/app/organization/interfaces/Student';
import { DisciplineTeacher } from 'src/app/organization/interfaces/DisciplineTeacher';

@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styleUrls: ['./students-list.component.css'],
  providers: [StudentsServices]
})
export class StudentsListComponent implements OnInit {
  constructor(private studentsServices: StudentsServices) { }

  getAllStudentsreturn: Student[];

  _stringOfFilter: string;
  _filteredArray: Student[];

  getAllStudens() {
    this.studentsServices.ApiAll().subscribe(
      (_returnStudens: Student[]) => {
        this.getAllStudentsreturn = _returnStudens
        this._filteredArray = _returnStudens
      }, error => {
        console.log(error);
      }
    )
  }


  get filteringString() {
    return this._stringOfFilter;
  }

  set filteringString(value: string) {
    this._stringOfFilter = value;
    this._filteredArray
      = this._stringOfFilter
        ? this.actionFilter(this.filteringString)
        : this.getAllStudentsreturn;
  }

  actionFilter(filteredBy: string): Student[] {
    filteredBy = filteredBy.toLocaleLowerCase();
    return this.getAllStudentsreturn.filter(_studentName => _studentName.name.toLocaleLowerCase().indexOf(filteredBy) !== -1)

  }


  ngOnInit(): void {
    this.getAllStudens();


  }

}
