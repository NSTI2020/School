import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EditTeacherComponent } from '../edit-teacher/edit-teacher.component';
import { TeacherServices } from '../../../../services/admin/teacher/teacherServices'
import { Teacher } from 'src/app/organization/interfaces/Teacher';

@Component({
  selector: 'app-list-teacher',
  templateUrl: './list-teacher.component.html',
  styleUrls: ['./list-teacher.component.css'],
  providers: [TeacherServices]
})
export class ListTeacherComponent implements OnInit {

  Teachers: Teacher[];

  FilteredArray: Teacher[];


  _GetAllTeachersReturn: Teacher[];
  _stringFilter: string;

  get FilteringString() {
    return this._stringFilter;
  }


  set FilteringString(value: string) {
    this._stringFilter = value;

    this.FilteredArray
      = this._stringFilter
        ? this.actionFilter(this.FilteringString)
        : this._GetAllTeachersReturn;
  }

  actionFilter(_filteredBy: string): Teacher[] {
    _filteredBy = _filteredBy.toLocaleLowerCase();
    return this._GetAllTeachersReturn.filter(_teacher => _teacher.name.toLocaleLowerCase().indexOf(_filteredBy) !== -1);
  }




  constructor(
    private teacherServices: TeacherServices
    , private dialog: MatDialog
  ) { }


  openDialog() {
    const dialogRef = this.dialog.open(EditTeacherComponent);

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  getAllTeachers(): void {
    this.teacherServices.ApiGetAll().subscribe(
      (_returnTeachers: Teacher[]) => {
        console.log(_returnTeachers);
        this._GetAllTeachersReturn = _returnTeachers;
        this.FilteredArray = _returnTeachers;
      }, error => {
        console.log(error);
      }
    )
  }


  ngOnInit(): void {
    this.getAllTeachers();
  }

}
