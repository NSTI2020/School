

import { Component, OnInit } from '@angular/core';
import { AccordionConfig } from 'ngx-bootstrap/accordion'
import { BsModalService, BsModalRef, ModalOptions } from 'ngx-bootstrap/modal';

import { Teacher } from 'src/app/organization/Entities/Teacher';
import { TeacherServices } from 'src/app/organization/services/admin/teacher/teacherServices';
import { TeacherCreateComponent } from './teacher/teacher-create/teacher-create.component';
import { TeacherDetailsComponent } from './teacher/teacher-details/teacher-details.component';
import { TeacherEditComponent } from './teacher/teacher-edit/teacher-edit.component';
import { TeacherDeleteComponent } from './teacher/teacher-delete/teacher-delete.component';
import { UnitServices } from 'src/app/organization/services/admin/unit/unit.services';
import { Unit } from 'src/app/organization/Entities/Unit';
import { Observable } from 'rxjs';

//Unit
import { UnitCreateComponent } from 'src/app/organization/components/control-panel/panels/unit/unit-create/unit-create.component';






export function getAccordionConfig(): AccordionConfig {
  return Object.assign(new AccordionConfig(), { closeOthers: true });
}

@Component({
  selector: 'app-control-panel',
  templateUrl: './control-panel.component.html',
  styleUrls: ['./control-panel.component.css'],
  providers: [BsModalService, BsModalRef, TeacherServices, { provide: AccordionConfig, useFactory: getAccordionConfig }]
})


export class ControlPanelComponent implements OnInit {
  //#region Property and Field
  //List Entity
  public _teachers: Array<Teacher> = new Array<Teacher>();
  public _teacher: Teacher = new Teacher();
  public _Units: Array<Unit> = new Array<Unit>();
  public _Unit: Unit = new Unit();


  //Modal
  public modalOptions: ModalOptions;
  public apiPhoto = 'http://localhost:5000/resources/images/';
  //#endregion

  constructor(
    public _modalRef: BsModalRef
    , private _Ms: BsModalService
    , private _Ts: TeacherServices
    , private _Us: UnitServices
  ) { }

  //#region Methods
  getAllTeachers() {
    this._Ts.ApiGetAll().subscribe((teachers: Teacher[]) => {
      //console.log(teachers);
      this._teachers = teachers
    }, error => {
      console.log(error);
    })

  }
  modalDetails(id: number) {
    this._modalRef = this._Ms.show(TeacherDetailsComponent)
    localStorage.setItem('id', id.toString())
  }
  modalCreate() {
    this._Ms.onHide.subscribe((reason: string | any) => {
      this.getAllTeachers();

    })
    
    this._modalRef = this._Ms.show(TeacherCreateComponent);
  }
  modalEdit(id: number) {
    localStorage.setItem('id', id.toString())
    
    const configCreate = {
      backdrop: false,
      ignoreBackdropClick: true,
      class: 'modal-lg',
      //list: [ this._Ts.ApiGetByIdObservable(+localStorage.getItem('id')).subscribe()],
      
    };
    this.modalOptions = configCreate;
    
    this._Ms.onHide.subscribe((reason: string | any) => {
      this.getAllTeachers();
    })
    
    this._modalRef = this._Ms.show(TeacherEditComponent, this.modalOptions);
    
  }
  modalDelete(id: number) {
    
    /*const initialState = {
      list: [
        'Open a modal with component',
        'Pass your data',
        'Do something else',
        '...'
      ],
      title: 'Modal with component'
    };*/
    const configCreate = {
      backdrop: false,
      ignoreBackdropClick: true,
      class: 'modal-lg',
      
    };
    // this.modalOptions = configCreate;
    this._Ms.onHide.subscribe((reason: string | any) => {
      this.getAllTeachers();
    })
    //  var teacher: Teacher = this._teachers.find(_id => _id.id == id);
    this._modalRef = this._Ms.show(TeacherDeleteComponent);
    localStorage.setItem('id', id.toString())
  }

//Methods for Unit
unitModalCreate() {
 
  const configCreate = {
    backdrop: false,
  ignoreBackdropClick: true,
  class: 'modal-lg',


};
this.modalOptions = configCreate;

  this._modalRef = this._Ms.show(UnitCreateComponent, this.modalOptions);

  this._Ms.onHide.subscribe((reason: string | any) => {
    this.getAllUnits();
  })

}
  getAllUnits() {
    return this._Us.getAll().subscribe((Units: Unit[]) => {
      //console.log(Units);
      this._Units = Units;
    })

  }
  //#endregion





  ngOnInit(): void {
    this.getAllTeachers();
    this.getAllUnits();

  }

}
