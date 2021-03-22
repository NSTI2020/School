import { Component, Input, OnInit } from '@angular/core';
import { BsModalRef, BsModalService, ModalModule } from 'ngx-bootstrap';
import { CreateTeacherComponent } from '../create-teacher/create-teacher.component';
import { TeacherServices } from '../../../../services/admin/teacher/teacherServices'
import { Teacher } from 'src/app/organization/interfaces/Teacher';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router'
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';




@Component({
  selector: 'app-list-teacher',
  templateUrl: './list-teacher.component.html',
  styleUrls: ['./list-teacher.component.css'],
  providers: [TeacherServices]
})
export class ListTeacherComponent implements OnInit {

  idTecherEdit: number[] = [];

  registerForm: FormGroup;

  dialogRef: MatDialog;

  Teachers: Teacher[];

  _teacherProm: Teacher;

  FilteredArray: Teacher[];

  constructor(
    private _TeacherService: TeacherServices
    , private dialog: MatDialog
  ) { }

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
    return this._GetAllTeachersReturn.filter(_teacher => _teacher.fullname.toLocaleLowerCase().indexOf(_filteredBy) !== -1);
  }


  openDialog() {
  this.dialog.open(CreateTeacherComponent)
  //.afterClosed().subscribe(result => {
  //console.log(`Dialog result: ${result}`);
};
    
 


  getAllTeachers(): void {
    this._TeacherService.ApiGetAll().subscribe(
      (_returnTeachers: Teacher[]) => {
        //   console.log(_returnTeachers);
        this._GetAllTeachersReturn = _returnTeachers;
        this.FilteredArray = _returnTeachers;
      }, error => {
        // console.log(error);
      }
    )
  }
  getTeacherByIdPromise(Id: number) {
    this._TeacherService.ApiGetByIdPromisse(Id).then(
      (_ReturnTeacher: Teacher) => {
        this._teacherProm = _ReturnTeacher;
      })
  }

  getTeacherByIdObservable(Id: number) {
    this._TeacherService.ApiGetByIdObservable(Id).subscribe(
      (_teatcher: Teacher) => {
        this._teacherProm = _teatcher;
      }, error => {
        //    console.log(error)
      }
    )
  }

  ngOnInit(): void {
   this.getAllTeachers();



  }

}
