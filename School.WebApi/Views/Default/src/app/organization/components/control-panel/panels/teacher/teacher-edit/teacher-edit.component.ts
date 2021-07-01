import { Component, OnInit, ViewChild } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Teacher } from 'src/app/organization/Entities/Teacher';
import { TeacherServices } from '../../../../../services/admin/teacher/teacherServices';
//import { TeacherValidatorsService } from '../../../../../services/admin/teacher/teacher-validators.service';
import { WebcamImage } from 'ngx-webcam/src/app/modules/webcam/domain/webcam-image';
import { WebcamInitError } from 'ngx-webcam/src/app/modules/webcam/domain/webcam-init-error';
import { Observable } from 'rxjs/internal/Observable';
import { Subject } from 'rxjs/internal/Subject';
import { Discipline } from 'src/app/organization/Entities/Discipline';
import { ToastrService } from 'ngx-toastr';
//datePiker to Br
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ValidatorsGlobal } from '../../shared/validators-global';
import { ThisReceiver } from '@angular/compiler';
import { Helpers } from 'src/app/organization/helpers/globalHelpers';

defineLocale('pt-br', ptBrLocale);

@Component({
  selector: 'app-teacher-edit',
  templateUrl: './teacher-edit.component.html',
  styleUrls: ['./teacher-edit.component.css']
})



export class TeacherEditComponent implements OnInit {
  //#region Properties end Fields
  public _formTeacher: FormGroup;
  public _options: string[];
  public discipline: Discipline = new Discipline();
  public _disciplineArray: Array<Discipline> = new Array<Discipline>();
  public _languages: Array<string> = [
    'Árabe', 'Alemão', 'Italiano', 'Francês',
    'Espanhol', 'Inglês', 'Japonês', 'Português', 'Mandarim'
  ];

  //Teacher
  public _teachers: Teacher[] = new Array<Teacher>();
  public _teavals: Teacher[] = new Array<Teacher>();
  public _teacher: Teacher;// = new Teacher();

  _imgDynamic: any;
  public _arrayLangs: Array<string> = new Array<string>();

  //File name, to delete after to change teacher photo.
  private toDelete: string;

  public _mStringStatus: string = 'Estado Civil';
  //Upload File
  private _file: File;
  //Img show in time that changed
  // public _fileName: string;
  public apiPhoto: boolean = false;
  public apiPhotoFile: boolean = false;
  //used upload()
  public _teacherPhotoFile: string;
  //Used in template
  public _teacherPhotoFileHtml: string;
  public _urlApi: string = 'http://localhost:5000/resources/images/';
  //public apiPhotoEnd: string = 'http://localhost:5000/resources/images/';
  //public allUrlPhoto;
  //#endregion
  //public tea$: Teacher = new Teacher();


  public _ctrls: FormControl[];// = new Array<FormControl>();



  constructor(
    public _Fb: FormBuilder,
    private _DatePtBr: BsLocaleService,
    private _Ts: TeacherServices,
    public _Mr: BsModalRef,
    public _valGlobal: ValidatorsGlobal,
    public _Helper: Helpers,
    private _Toast: ToastrService,
  ) {
    this._DatePtBr.use('pt-br');
    ///I love programming.
    //  this._teacherPhotoFileHtml = this._urlApi + '/' + this._teacher.photoFile
    //console.log(this._teacherPhotoFileHtml);
  }

  //#region Methods

  save() {

    //   this.onChangeDisciplines();

    this._formTeacher.value.disciplines = this._disciplineArray;
    //   if (this._fileName != null) {
    //     this._formTeacher.value.photo = this._fileName.toLowerCase();
    //   }
    console.log();

    this._teacher = Object.assign({ id: this._teacher.id }, this._formTeacher.value);
    this.seacherDisciplines();
// if (this._formTeacher.valid) {
//   this._Ts
//     .Put(this._teacher)
//     .subscribe((teacher: Teacher) => {
//       this._Toast.success('Registro do professor ' + teacher.fullName + ' Foi atualizado com êxito.')
//       //deleteing teacher photo file.
//       this._Ts.PostDeletePhoto(this.toDelete).subscribe();
//       this._Mr.hide();
//     }, error => {
//       // console.log(error);
//     })
// }

  }

  public seacherDisciplines() {
    //const disciplines: boolean[] = this._formTeacher.get('disciplines').value;
    for (let n = 0; n < this._languages.length; n++)
    {
    }
      this._formTeacher.get('disciplines').value.map((item) => {
        if (item) {
          console.log(item)
        }

      })
     // console.log(this._formTeacher.value.disciplines)
   //   console.log()

    // let _bools = new Array<boolean>();
    // _bools = this._languages.map(() => false);
    // for (let n = 0; n < this._languages.length; n++) {
    //   teacher.disciplines.forEach((item) => {
    //     if (item.language == this._languages[n]) {
    //       _bools[n] = true;
    //     }
    //   });
    // }
    // this._formTeacher.get('disciplines').setValue(_bools);
  }






  //#endregion


  //#region Validators
  fullvalidation() {
    return this._formTeacher = this._Fb.group({
      photo: ['', [Validators.minLength(2)]],
      fullName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(150)]],
      birthday: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(11)]],
      maritalStatus: ['', [Validators.required, Validators.minLength(9), Validators.maxLength(11)]],
      address: this._valGlobal.address(),
      contact: this._valGlobal.contact(),
      disciplines: this._Fb.array(this._languages.map(() => true)) //this._Fb.array(this._bools)
    });
  }

  select() {
    this._options = [
      'Casado(a)',
      'Solteiro(a)'
    ];
  }

  getBySpecificId() {

    this._Ts.ApiGetByIdObservable(+localStorage.getItem('id')).subscribe((teacher: Teacher) => {
      this._teacher = teacher;
      this._formTeacher.patchValue(teacher);
      // this.apiPhoto = true
      this.boolsDiscipline(teacher)
    })
  }

  public boolsDiscipline(teacher: Teacher) {
    let _bools = new Array<boolean>();
    _bools = this._languages.map(() => false);
    for (let n = 0; n < this._languages.length; n++) {
      teacher.disciplines.forEach((item) => {
        if (item.language == this._languages[n]) {
          _bools[n] = true;
        }
      });
    }
    this._formTeacher.get('disciplines').setValue(_bools);
  }
  //#endregion

  // waitSeconds(iMilliSeconds) {
  // var counter = 0
  //   , start = new Date().getTime()
  //   , end = 0;
  // while (counter < iMilliSeconds) {
  //   end = new Date().getTime();
  //   counter = end - start;
  // }
  // }
  //
  //#region UPLOAD
  onChangephoto($event) {

    if ($event.target.files && $event.target.files.length) {
      //this._file = $event.target.files;
      this._file = $event.target.files[0];
    }
    //checking if old image exists
    if (this._teacher.photo != null) {
      //   this.upload('put');
    }
    else {
      //  this.upload('post');
    }
    // this.waitSeconds(300);
    this.apiPhotoFile = true;
    this.apiPhoto = false;
    //this.webcamImage = null;

  }

  // upload(mode: string) {

  //  if (mode === 'post') {
  //    const name = this._Helper.generateFileName();
  //    console.log('AQUI PASSA',name)
  //    this._teacher.photo = name;
  //    this._teacherPhotoFile = name;
  //    this._Ts.uploadFile(this._file, name).subscribe(() => {
  //      this._imgDynamic = name;
  //    })
  //  }
  //  else {
  //    //Deleting old file and calling again upload passing 'post' parameter.
  //    // this.generate_fileName();
  //    this.toDelete = this._teacher.photo;
  //    this.upload('post');
  //    //this._teacher.photo = this._fileName.toLowerCase();  
  //  } 1

  // }

  ngOnInit(): void {
    this.fullvalidation();
    this.select();
    this.getBySpecificId();
  }
}
