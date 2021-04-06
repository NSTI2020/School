import { Component, Inject, Input, OnInit } from '@angular/core';
import { __core_private_testing_placeholder__ } from '@angular/core/testing';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { Teacher } from 'src/app/organization/interfaces/Teacher';
import { TeacherServices } from '../../../../services/admin/teacher/teacherServices'

@Component({
  selector: 'app-edit-teacher',
  templateUrl: './edit-teacher.component.html',
  styleUrls: ['./edit-teacher.component.css']
})
export class EditTeacherComponent implements OnInit {
  title: string;
  closeBtnName: string;
  list: any[] = [];
  _teacher: Teacher = null;
  public registerForm: FormGroup = new FormGroup({});
  _teacherObs: Teacher = null;


  constructor(
    private _TeacherService: TeacherServices
    , public _DialogRef: MatDialogRef<EditTeacherComponent>
    , @Inject(MAT_DIALOG_DATA) public data: Teacher) { }




  getTeacherByIdObservable(Id: number) {
    this._TeacherService.ApiGetByIdObservable(Id).subscribe(
      (_teacher: Teacher) => {
      }, error => {
        console.log(error)
      }
    )
  }

  getTeacherByIdPromise(Id: number) {


    this._TeacherService.ApiGetByIdPromisse(Id).then(
      (_ReturnTeacher: Teacher) => {
        this._teacherObs = _ReturnTeacher;
        console.log(_ReturnTeacher);
        this._teacher = _ReturnTeacher;
      })
  }

  save() {
    //console.log(this.registerForm);
    console.log(this.data.fullName);
  }


  ngOnInit(): void {

   //this.getTeacherByIdPromise(this._Route.snapshot.params['id']);
  }

}
