import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class StudentValidatorsService {
//#region Variables
public Form: FormGroup; //Form 
private _Fb: FormBuilder;
//#endregion


//#region Validators

SmallValidators(){

}
//#endregion


constructor() { }

}
