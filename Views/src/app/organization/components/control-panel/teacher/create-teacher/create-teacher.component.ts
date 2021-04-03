import { Component, Inject, OnInit } from '@angular/core';
import { FormArray, FormArrayName, FormBuilder, FormControl, FormControlName, FormGroup, FormGroupName, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TabsModule } from 'ngx-bootstrap';
import { BsModalRef, BsModalService, ModalModule } from 'ngx-bootstrap';
import { DisciplineTeacher } from 'src/app/organization/interfaces/DisciplineTeacher';
import { Discipline } from 'src/app/organization/interfaces/Discipline';
import { Teacher } from 'src/app/organization/interfaces/Teacher';
import { DisciplineServices } from 'src/app/organization/services/admin/disciplines/disciplines.services';
import { TeacherServices } from '../../../../services/admin/teacher/teacherServices'
import { leadingComment } from '@angular/compiler';



@Component({
    selector: 'app-create-teacher',
    //template: ``,
    templateUrl: './create-teacher.component.html',
    styleUrls: ['./create-teacher.component.css'],
    providers: [TeacherServices, DisciplineServices]
})
export class CreateTeacherComponent implements OnInit {

    public RegisterFormDataPer: FormGroup;
    public FormDisciplineTeacher: FormGroup;

    _teacher: Teacher = new Teacher();
    _arraysDisp: DisciplineTeacher[];

    Selected = new FormControl();

    public _disciplineList: string[] = ['Alemão', 'Árabe', 'Espanhol', 'Italiano',
        'Japonês', 'Mandarim', 'Francês', 'Inglês', 'Português']

    public _language: Array<string> = new Array<string>();
    public _discipline: Discipline = new Discipline();
    public _disciplineArrays: Array<Discipline> = new Array<Discipline>();
    public _disciplineTeacher: DisciplineTeacher;
    public _disciplineTeacherArray: Array<DisciplineTeacher> = new Array<DisciplineTeacher>();


    constructor
        (
            private fBuilder: FormBuilder
            , private _TeacherServices: TeacherServices
            , private _DisciplineServices: DisciplineServices
            , public tabsModule: TabsModule
        ) { }

    Validation() {

        this.RegisterFormDataPer = this.fBuilder.group({
            fullname: ['', []],
            contact: this.fBuilder.group({
                email: ['', []],
                cel: ['', []],
            }),
            address: this.fBuilder.group({
                complent: ['', []]
            })

        });
    }

    ValidationArray() {
        this.FormDisciplineTeacher = this.fBuilder.group({
            DisciplineTeacher: this.fBuilder.group({
                discipline: ['', []],
                teacherId: ['', []]
            })

        })

    }

    makeObj(): void {
        console.log(this.Selected.value);
    };
    save() {
        // this.makeObj();
        this._teacher = Object.assign({}, this.RegisterFormDataPer.value)
        //  this._teacher.disciplines = this._disciplineTeacherArray;
        this._TeacherServices.ApiPost(this._teacher).subscribe(
            (teacher: Teacher) => {

                this.Selected.value.forEach(_language => {
                    this._discipline = new Discipline();
                    this._discipline.language = _language;
                    this._disciplineArrays.push(this._discipline);
                });
                this._disciplineArrays.forEach(item => {
                    this._disciplineTeacher = new DisciplineTeacher();
                    this._disciplineTeacher.discipline = item;
                    this._disciplineTeacher.teacherId = teacher.id;
                    this._disciplineTeacherArray.push(this._disciplineTeacher);
                    //  console.log(this._disciplineTeacher)
                })
                  this._disciplineTeacherArray.forEach(item => {
  
                     // this._disciplineTeacher = Object.assign({} , item)
                     console.log(item);
                     this._disciplineTeacher = Object.assign({}, item)

                     this._DisciplineServices.postDisciplineTeacher(this._disciplineTeacher).subscribe(
                         (DisciplineTeacher: DisciplineTeacher) => {
                             console.log(DisciplineTeacher)
                         });
                      
                  })
  /*
               
*/

                //console.log(this._disciplineTeacherArray)


                //console.log(this._teacher);
            }, error => {

            })

    }

    ngOnInit(): void {
        this.Validation();
        this.ValidationArray();

    }



}
