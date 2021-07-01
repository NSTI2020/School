import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Unit } from 'src/app/organization/Entities/Unit';
import { Observable } from 'rxjs';



@Injectable({
  providedIn: 'root'
})


export class UnitServices {
//#region Properties and Fields
private _apiUrl: string = 'http://localhost:5000/api/units/';
//#endregion


  constructor(private _Http: HttpClient) { }

post(model: Unit) {
 return this._Http.post<Unit>(this._apiUrl, model);
}
getAll():Observable<Unit[]>{
  return this._Http.get<Unit[]>(this._apiUrl);
}






}
