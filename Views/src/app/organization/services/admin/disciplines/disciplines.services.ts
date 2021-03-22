import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { DisciplineTeacher } from "src/app/organization/interfaces/DisciplineTeacher";
import { DisciplineList } from "src/app/organization/interfaces/DisciplineList";

@Injectable()
export class DisciplineServices {
    ApiUrl: string = 'http://localhost:5000/api/disciplines/';
    ApiUrlDispList: string = 'http://localhost:5000/api/disciplines/getdis/list';

    constructor(private _httpClient: HttpClient) { }

    getAllDisciplines(): Observable<DisciplineTeacher[]> {
        return this._httpClient.get<DisciplineTeacher[]>(this.ApiUrl);
    }

    post(langs: DisciplineTeacher): Observable<DisciplineTeacher> {
      return this._httpClient.get<DisciplineTeacher>(this.ApiUrl);
    }






}
