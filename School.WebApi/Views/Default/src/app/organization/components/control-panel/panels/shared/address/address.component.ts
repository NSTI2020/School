import { HttpClient } from '@angular/common/http';
import { Component, Injectable, Input, OnInit, Output } from '@angular/core';
import { FormBuilder } from '@angular/forms';

//import { UnitValidatorsService } from 'src/app/organization/services/admin/unit/unit-validators.service';
import { ValidatorsGlobal } from '../validators-global';
@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css']

})
@Injectable({
  providedIn: 'root'
})

export class AddressComponent implements OnInit {

  //#region Properties and Fields
  private _cep: any;
  // public _Form: FormGroup;


  //#endregion
  constructor(
    private _Fb: FormBuilder
    , public _ValGlobal: ValidatorsGlobal
    , public _Http: HttpClient
  ) { }
  //#region Methods
  query(cep: string) {
    var Url = (`//viacep.com.br/ws/${cep}/json`);
    //remove all characters that no be a number.
    cep = cep.replace(/\D/g, '');
    //check if the field are empty
    if (cep != "") {
      //check if number is valid
      var validationCep = /^[0-9]{8}$/;
    }
    if (validationCep.test(cep)) {
      this._Http.get(Url).subscribe((cep: any) => this.seedForm(cep));
    }
  }
  seedForm(cep: any) {
    this._ValGlobal._FormAddress.controls['numero'].setValue(cep.numero);
    this._ValGlobal._FormAddress.controls['cep'].setValue(cep.cep);
    this._ValGlobal._FormAddress.controls['complemento'].setValue(cep.complemento);
    this._ValGlobal._FormAddress.controls['logradouro'].setValue(cep.logradouro);
    this._ValGlobal._FormAddress.controls['bairro'].setValue(cep.bairro);
    this._ValGlobal._FormAddress.controls['cidade'].setValue(cep.localidade);
    this._ValGlobal._FormAddress.controls['estado'].setValue(cep.uf);
  }
  //#endregion
  ngOnInit(): void { }

}