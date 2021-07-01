import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Room } from 'src/app/organization/Entities/Room';
import { Unit } from 'src/app/organization/Entities/Unit';
//import { UnitValidatorsService } from 'src/app/organization/services/admin/unit/unit-validators.service';
import { UnitServices } from 'src/app/organization/services/admin/unit/unit.services';

import { AddressComponent } from '../../shared/address/address.component';
import { ValidatorsGlobal } from '../../shared/validators-global';



@Component({
  selector: 'app-unit-create',
  templateUrl: './unit-create.component.html',
  styleUrls: ['./unit-create.component.css'],
  providers: [UnitServices]
})
export class UnitCreateComponent implements OnInit {
  //#region Properties
  public _FormUnit: FormGroup;
  _unit: Unit = new Unit();
  _rooms: Array<Room> = new Array<Room>();
  _room: Room = new Room();
  public _numberOfRooms: number = 0;
  //#endregion



  constructor(
    public _ValGlobal: ValidatorsGlobal
    , private _Us: UnitServices
    , private _Toast: ToastrService
    , public _Mr: BsModalRef
    , public _Fb: FormBuilder

  ) { }


  //#region Methods
  roomsAddToArray() {
    if (this._FormUnit.value.rooms != null) {
      this._room = Object.assign({}, this._FormUnit.value.rooms[0]);
      this._rooms.push(this._room);
      this._numberOfRooms += 1;
      this._FormUnit.controls['rooms'].reset();
    }
  }



  save() {
    this._FormUnit.value.rooms = this._rooms;
    this._FormUnit.value.students = [];
    this._FormUnit.value.teachers = [];
    this._FormUnit.value.checkingaccounts = [];
    this._unit = Object.assign({}, this._FormUnit.value);
    this._Us.post(this._unit).subscribe((unit: Unit) => {
      this._Toast.success('Unidade cadastrada com êxito!', unit.name);
      this._FormUnit.reset();
    })
    //console.log(this._unit)
    this._Mr.hide();

  }

  enableBtnSave(): boolean {
    return this._numberOfRooms > 0 ? true : false;
  }


  //#endregion


  validatorsUnit(): FormGroup {
    return this._FormUnit = this._Fb.group({
        name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
        address: this._ValGlobal.address(),
        contact: this._ValGlobal.contact(),
        rooms: this._Fb.array([this.validatorsRooms()]),
        checkingaccounts: this._Fb.array([], []),
        students: this._Fb.array([], []),
        teachers: this._Fb.array([], []),
    });

}
validatorsRooms():FormGroup {
  return this._Fb.group({
       identifier: ['', [Validators.required, Validators.maxLength(50)]],
       capacity: ['', [Validators.maxLength(3)]],
       description: ['', [Validators.maxLength(150)]]
   });
}



  ngOnInit(): void {
    this.validatorsUnit();
  }

}

