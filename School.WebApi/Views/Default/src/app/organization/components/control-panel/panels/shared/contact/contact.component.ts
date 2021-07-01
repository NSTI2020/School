import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ValidatorsGlobal } from '../validators-global';


@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css'],
  //providers:[ValidatorsGlobal]
})
export class ContactComponent implements OnInit {

  public _checkZap: boolean;
  constructor(
      public _ValGlobal: ValidatorsGlobal
    , public _Fb: FormBuilder
  ) { }

  ngOnInit(): void {
    
    //this._ValGlobal._FormUnit.value.contact = this._ValGlobal._FormContact;
    }

}
