import { Component, Inject, OnInit } from '@angular/core';
import { FormArray, FormArrayName, FormBuilder, FormControl, FormControlName, FormGroup, FormGroupName, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TabsModule } from 'ngx-bootstrap';
import { BsModalRef, BsModalService, ModalModule } from 'ngx-bootstrap';
import { DisciplineTeacher } from 'src/app/organization/interfaces/DisciplineTeacher';
import { DisciplineList } from 'src/app/organization/interfaces/DisciplineList';
import { Teacher } from 'src/app/organization/interfaces/Teacher';
import { DisciplineServices } from 'src/app/organization/services/admin/disciplines/disciplines.services';
import { TeacherServices } from '../../../../services/admin/teacher/teacherServices'
import { stringify } from '@angular/compiler/src/util';
import { element } from 'protractor';



@Component({
    selector: 'app-create-teacher',
    //template: ``,
    templateUrl: './create-teacher.component.html',
    styleUrls: ['./create-teacher.component.css'],
    providers: [TeacherServices, DisciplineServices]
})
export class CreateTeacherComponent implements OnInit {

    public RegisterFormDataPer: FormGroup;

    _teacher: Teacher = new Teacher();
    _arraysDisp: DisciplineTeacher[];


    _disciplineList: string[] = ['Alemão', 'Árabe', 'Espanhol', 'Italiano',
        'Japonês', 'Mandarim', 'Francês', 'Inglês', 'Português']


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
            ,
            disciplinas: this.fBuilder.array([this.makeObj()])
        });
    }

    makeObj(): FormGroup {
        return this.fBuilder.group({
            disciplines: ['', []]
        })
    }

    Testing(value: string): string {
      //  console.log(value)
        return value;
    }
    public _language: Array<string> = new Array<string>();
    public _Lang: DisciplineTeacher;
    public _DisciplineTeacherArray: Array<DisciplineTeacher> = new Array<DisciplineTeacher>();

    save() {

        this._teacher = Object.assign({}, this.RegisterFormDataPer.value)
        this._language.forEach(element => {
            //console.log(element)
                this._Lang = new DisciplineTeacher();
              //this._Lang.id = 85;
              this._Lang.language = element;
               //this._Lang.teacher = teacher;
               this._DisciplineTeacherArray.push(this._Lang);
          });

          this._teacher.disciplines = this._DisciplineTeacherArray;

        //        this.RegisterFormDataPer.get('disciplinas').patchValue(this._languageArray.);
        this._TeacherServices.ApiPost(this._teacher).subscribe(
            (teacher: Teacher) => {
              
                console.log(teacher)
                
            }, error => {
                //console.log(error);

                /*
                
                 this._DisciplineServices.post(this._Lang).subscribe(
                        (returnDiscipline :DisciplineTeacher) => {
                         console.log(returnDiscipline)   
                        })
                
                */
            })
    }

    ngOnInit(): void {
        this.Validation();

    }



}
