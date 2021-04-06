import { Component, Inject, Input, OnInit } from '@angular/core';
import { BsModalRef, BsModalService, ModalModule } from 'ngx-bootstrap';
import { CreateTeacherComponent } from '../create-teacher/create-teacher.component';
import { EditTeacherComponent } from '../edit-teacher/edit-teacher.component';
import { TeacherServices } from '../../../../services/admin/teacher/teacherServices'
import { Teacher } from 'src/app/organization/interfaces/Teacher';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router'
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DeleteTeacherComponent } from '../delete-teacher/delete-teacher.component';
import { DetailsTeacherComponent } from '../details-teacher/details-teacher.component';




@Component({
  selector: 'app-list-teacher',
  templateUrl: './list-teacher.component.html',
  styleUrls: ['./list-teacher.component.css'],
  providers: [TeacherServices]
})
export class ListTeacherComponent implements OnInit {

  idTecherEdit: number[] = [];

  registerForm: FormGroup;


  _teachers: Teacher[];

  _teacherEdit: Teacher;

  _teacherDelete: Teacher = new Teacher();

  _teacherProm: Teacher;

  FilteredArray: Teacher[];
  _GetAllTeachersReturn: Teacher[];
  _stringFilter: string;


  constructor(
    private _TeacherService: TeacherServices
    , private _Dialog: MatDialog
  ) { }


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
    return this._GetAllTeachersReturn.filter(_teacher => _teacher.fullName.toLocaleLowerCase().indexOf(_filteredBy) !== -1);
  }


  openDialog() {
    this._Dialog.open(CreateTeacherComponent)
    //.afterClosed().subscribe(result => {
    //console.log(`Dialog result: ${result}`);
  };
  //(click)="openDialog()"
  edit(id: number) {
    this._teacherEdit = this._teachers.find(_teacher => _teacher.id == id);
    const _DialogRef = this._Dialog.open(EditTeacherComponent, {
      width: '800px',
      height: '800px',
      data: this._teacherEdit
    });

    _DialogRef.disableClose = true;
  }
  details(id: number) {
    const _DialogRef = this._Dialog.open(DetailsTeacherComponent, {
      width: '300px',
      height: '500px',
      data: this._teachers.find(_teacher => _teacher.id == id)
    });
    _DialogRef.disableClose = true;
  }


  delete(id: number) {

    const _DialogRef = this._Dialog.open(DeleteTeacherComponent, {
      width: '650px',
      height: '260px',
      data: this._teachers.find(_teacher => _teacher.id == id)
    });
    _DialogRef.disableClose = true;

  }


  getAllTeachers(): void {
    this._TeacherService.ApiGetAll().subscribe(
      (_returnTeachers: Teacher[]) => {
        this._GetAllTeachersReturn = _returnTeachers;
        this.FilteredArray = _returnTeachers;
        this._teachers = _returnTeachers;

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
