import { Component, Inject, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Teacher } from '../../../../interfaces/Teacher';
import { TeacherServices } from '../../../../services/admin/teacher/teacherServices'
import { Router } from '@angular/router';


@Component({
  selector: 'app-delete-teacher',
  templateUrl: './delete-teacher.component.html',
  styleUrls: ['./delete-teacher.component.css'],
  providers: [TeacherServices, MatSnackBar]
})
export class DeleteTeacherComponent implements OnInit {

  //  _teachers: Teacher[] = new Array<Teacher>();


  constructor(
    public _SnackBar: MatSnackBar
    , public _Router: Router
    , private _TeacherService: TeacherServices
    , @Inject(MAT_DIALOG_DATA) public data: Teacher
    //, 
  ) { }

  delete() {
    this.Snack('Deleção com sucesso!', this.data.fullName);
    this._TeacherService.ApiDelete(this.data.id).subscribe(
      (teacher: Teacher) =>
      {
      //    this._Router.navigate(['/']);
    }, error => {
    return  this.Snack(error, this.data.fullName);
    })

    
  }


  Snack(msg: string, objName: string) {

    this._SnackBar.open(msg, objName, {
      duration: 2000,
    });
  }


  ngOnInit(): void {
    console.log(this.data.fullName)
  }

}
