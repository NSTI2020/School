import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Teacher } from 'src/app/organization/Entities/Teacher';
import { TeacherServices } from 'src/app/organization/services/admin/teacher/teacherServices';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-teacher-delete',
  templateUrl: './teacher-delete.component.html',
  styleUrls: ['./teacher-delete.component.css'],
  providers: [BsModalService, TeacherServices, ToastrService]
})
export class TeacherDeleteComponent implements OnInit {

  closeBtnName: string = 'close';

  public _teachers: Array<Teacher> = new Array<Teacher>();
  public _teacher: Teacher = new Teacher();

  constructor(
    public _Ts: TeacherServices
    , public _Ms: BsModalService
    , public _Mr: BsModalRef
    , public _Toasts: ToastrService
  ) { }

  getAllTeachers() {
    this._Ts.ApiGetAll().subscribe((teachers: Teacher[]) => {
      this._teachers = teachers

      let id: number = parseInt(localStorage.getItem('id'));
      this._teacher = this._teachers.find(_id => _id.id == id);

      //console.log(this._teacher);

    }, error => {
      //console.log(error)
    })
  }

  deletar(id: number) {
    this._Ts.ApiDelete(id).subscribe(() => {
      //console.log(teacher)


    }, error => {
      console.log(error);
      ///this._Toasts.error('Registro não excluido. Erro: ' , this._teacher.fullName);
    })
    //I need to fix it.
    this._Toasts.error('Registro deletado. ', this._teacher.fullName);
    this._Mr.hide();

  }





  ngOnInit(): void {
    this.getAllTeachers();
  }

}
