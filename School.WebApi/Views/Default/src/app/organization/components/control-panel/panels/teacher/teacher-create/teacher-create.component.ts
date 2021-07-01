import { Component, Input, OnInit, Output, ViewChild } from "@angular/core";
import { BsModalRef } from 'ngx-bootstrap/modal';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { ToastrService } from "ngx-toastr";
import { FormBuilder, FormGroup, Validator, Validators } from "@angular/forms";

//datePiker to Br
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';
defineLocale('pt-br', ptBrLocale);
////

//teacher
import { Teacher } from "src/app/organization/Entities/Teacher";
import { TeacherServices } from 'src/app/organization/services/admin/teacher/teacherServices';
import { Discipline } from "src/app/organization/Entities/Discipline";
import { Helpers } from 'src/app/organization/helpers/globalHelpers';


//Unit
import { UnitServices } from 'src/app/organization/services/admin/unit/unit.services';
import { Unit } from "src/app/organization/Entities/Unit";
import { UnitTeacher } from "src/app/organization/Entities/UnitTeacher";

//General
import { ValidatorsGlobal } from "../../shared/validators-global";
import { LocalHelpersCam } from 'src/app/organization/components/control-panel/panels/shared/cam/LocalHelpersCam';
import { CamComponent } from "../../shared/cam/cam.component";
import { LocalHelpersTeacher} from "../localHelpersTeacher";




@Component({
  selector: 'app-teacher-create',
  templateUrl: './teacher-create.short.component.html',
  styleUrls: ['./teacher-create.component.css'],
  providers: [TeacherServices, ToastrService, LocalHelpersCam]
})

export class TeacherCreateComponent implements OnInit {

  //#region Properties and Fields

  //Disciplines
  public _disciplineArray: Array<Discipline> = new Array<Discipline>();
  public _arrayLangs: Array<string> = new Array<string>();
  public _discipline: Discipline = new Discipline;
  public _disciplinesStringsArray: Array<string> = new Array<string>();
  //public discipline: Discipline;

  //Form
  public _FormTeacher: FormGroup;

  //#region Teacher
  public _teacher: Teacher = new Teacher();
  //#endregion

  //#region Unit
  public _units: Array<Unit> = new Array<Unit>();
  public _unit: Unit = new Unit;
  public _unitId: Array<number> = new Array<number>();
  public _unitTeacher: UnitTeacher;
  public _unitTeachers: Array<UnitTeacher> = new Array<UnitTeacher>();
  //#endregion


  //#endregion
  //#endregion

  constructor(
    private _Ts: TeacherServices,
    private _Fb: FormBuilder,
    private _Us: UnitServices,
    private _Ls: BsLocaleService,
    private _Toast: ToastrService,
    //private _LocalHelpers: ,
    
    //helpers
    private _Helpers: Helpers,
    public _LocalHelpersCam: LocalHelpersCam,
    public _LocalHelpersTeacher: LocalHelpersTeacher,




    //validators
    public _Mr: BsModalRef,
    public _valGlobal: ValidatorsGlobal,
  ) {
    this._Ls.use('pt-br');
  }



  //#region Methods

  save() {

    this._FormTeacher.value.disciplines = this.CreateArrayDisciplines();
    this._FormTeacher.value.unitteachers = this.CreateArrayUnitsTeacher();
    this._FormTeacher.value.photo = this._LocalHelpersTeacher.uploadImgFile();

    console.log('METHOD SAVE', this._teacher.photo)
    //  if (this._imgDynamic != null) {
    //    this._FormTeacher.value.photo = this._valGlobal.fileName.toLocaleLowerCase();
    //  }

    this._teacher = Object.assign({}, this._FormTeacher.value);
    //  this._teacher.unitteachers = this._unitTeachers
    console.log(this._teacher);
    this._Ts.ApiPost(this._teacher).subscribe((teacher: Teacher) => {

      this._Toast.success(teacher.fullName + " adicionado com êxito.");

      this._Mr.hide();
    }, error => {
      console.log(error);
    })
  }
  //tmp
  // hasPhoto(): boolean {
  //   return this._LocalHelpersCam.camActNow != true ? true : false;
  // }
  //#endregion

  //#region Validators
  CreateArrayUnitsTeacher(): UnitTeacher[] {
    this._unitId.forEach(item => {
      this._unitTeacher = new UnitTeacher();
      this._unitTeacher.unitid = item;
      //this._unitTeacher.teacher = this._teacher;
      this._unitTeacher.teacherid = this._teacher.id;
      this._unitTeachers.push(this._unitTeacher);
    })
    return this._unitTeachers
  }
  CreateArrayDisciplines(): Discipline[] {
    this._arrayLangs.forEach(item => {
      this._discipline = new Discipline()
      this._discipline.language = item;
      this._disciplineArray.push(this._discipline);
    })
    return this._disciplineArray
  }
  //Enable btn Cadastrar if form is valid and arrays have any.
  buttonOnOff() {
    if (this._arrayLangs.length > 0 && this._FormTeacher.valid) {
      return false;
    }
    else {
      return true;
    }
  }
  smallValidation() {
    this._FormTeacher = this._Fb.group({
      fullName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(150)]],
      photo: ['', []],
      contact: this._Fb.group({
        email: ['', [Validators.required, Validators.email, Validators.maxLength(150)]]
      }),
      address: this._Fb.group({
        street: ['Concluir', []]
      }),
      disciplines: ['', []],
      unitteachers: ['', []],

    });
  }
  //#endregion

  ngOnInit(): void {
    this._disciplinesStringsArray = ['Árabe', 'Alemão', 'Italiano', 'Francês', 'Mandarim', 'Espanhol', 'Inglês', 'Japonês', 'Português'];
    this._Us.getAll().subscribe((units: Unit[]) => { this._units = units; })
    this.smallValidation();

  }
}


