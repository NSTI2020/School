import { Injectable } from "@angular/core";
import { FormControl } from "@angular/forms";
import { FormArrayName, FormBuilder, FormGroup, FormGroupName, Validators } from "@angular/forms";
import { WebcamImage } from "ngx-webcam/src/app/modules/webcam/domain/webcam-image";
import { Room } from "src/app/organization/Entities/Room";
import { Teacher } from "src/app/organization/Entities/Teacher";
import { TeacherServices } from "src/app/organization/services/admin/teacher/teacherServices";


@Injectable({
    providedIn: 'root'
})

export class ValidatorsGlobal {
    constructor(
        private _Fb: FormBuilder,
        private _Ts: TeacherServices,
    ) { }

    //#region Properties and Fields

    //#region Global
    //
    public _FormAddress: FormGroup;
    public _FormContact: FormGroup;
    //  public _FormArrayRoom: FormArrayName;
    //   public _FormRoom: FormGroup;
    //#endregion
    //#region Room
    _rooms: Array<Room> = new Array<Room>();

    //#endregion
    //#region Contact
    public _checkZap: boolean;
    //#endregion

   

    //#region Methods
    address(): FormGroup {
        return this._FormAddress = this._Fb.group({
            cep: ['', [Validators.minLength(5), Validators.maxLength(15)]],
            logradouro: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(150)]],
            numero: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(7)]],
            bairro: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
            cidade: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
            estado: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(3)]],
            complemento: ['', [Validators.maxLength(500)]],
        });
    }
    contact(): FormGroup {
        return this._FormContact = this._Fb.group({
            email: ['', [Validators.required, Validators.email, Validators.maxLength(150)]],
            business: ['', [Validators.minLength(9), Validators.maxLength(20)]],
            cel: ['', [Validators.minLength(9), Validators.maxLength(20)]],
            zap: ['', [Validators.minLength(9), Validators.maxLength(20)]],
            isZap: ['', []],
            landline: ['', [Validators.minLength(5), Validators.maxLength(150)]],
            linkedin: ['', [Validators.minLength(5), Validators.maxLength(150)]],
            facebook: ['', [Validators.minLength(5), Validators.maxLength(150)]],
            instagram: ['', [Validators.minLength(5), Validators.maxLength(150)]],
            twitter: ['', [Validators.minLength(5), Validators.maxLength(150)]],
        });
    }


    //#region WebCam
     //these below is called inside triggerSnapshot <-Method
  
    //#endregion


    //#endregion

    //#region Checkers
    public touchedErrors(ctrl: string, formGroup: FormGroup) {
        return formGroup.get(ctrl).errors
            && formGroup.get(ctrl).touched
            ? true : false;
    }
    emailValidation(ctrl: string, error: string, msg: string, formGroup: FormGroup) {
        return formGroup.get(ctrl).hasError(error)
            ? msg : formGroup.get(ctrl).hasError(error)
                ? msg : formGroup.get(ctrl).hasError(error) ? '' : '';
    }
    public commonValidations(ctrl: string, error: string, msg: string, formGroup: FormGroup) {
        return formGroup.get(ctrl).hasError(error)
            ? msg : formGroup.get(ctrl).hasError(error)
                ? msg : formGroup.get(ctrl).hasError(error) ? '' : '';
    }
    //#endregion





}
