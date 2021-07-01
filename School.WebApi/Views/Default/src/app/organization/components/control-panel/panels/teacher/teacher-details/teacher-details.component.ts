import { Component, OnInit } from "@angular/core";
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Teacher } from "src/app/organization/Entities/Teacher";
import { TeacherServices } from "src/app/organization/services/admin/teacher/teacherServices";



@Component({
    selector: 'app-teacher-details',
    templateUrl: './teacher-details.component.html',
    styleUrls: ['./teacher-details.component.css']
})

export class TeacherDetailsComponent implements OnInit {

    title: string = "Detalhes...";
    closeBtnName: string;

    constructor(
        public bsModalRef: BsModalRef
        , private _Ts: TeacherServices
    ) { }

    //#region Fields Supports Entities
    _teachers: Array<Teacher> = new Array<Teacher>();
    _teacher: Teacher = new Teacher();
    public _urlApi: string = 'http://localhost:5000/resources/images/'+this._teacher.photo;
    //#endregion

    //#region Methods
    getById() {
        this._Ts.ApiGetByIdObservable(+localStorage.getItem('id')).subscribe((teacher: Teacher) => {
            this._teacher = teacher;
            //console.log(teacher);
        }, error => {
            //console.log(error);
        })
    }
    //#endregion

    ngOnInit(): void {
        this.getById();
    }

}