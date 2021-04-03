import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { DisciplineTeacher } from "src/app/organization/interfaces/DisciplineTeacher";


@Injectable()
export class DisciplineServices {
    ApiUrl: string = 'http://localhost:5000/api/disciplines/';
    ApiUrlDispList: string = 'http://localhost:5000/api/disciplines/getdis/list';
    ApiDisciplineTeacherUrl: string = 'http://localhost:5000/api/disciplines/dt';

    constructor(private _httpClient: HttpClient) { }

    getAllDisciplines(): Observable<DisciplineTeacher[]> {
        return this._httpClient.get<DisciplineTeacher[]>(this.ApiUrl);
    }

    postDisciplineTeacher(model: DisciplineTeacher){
      return this._httpClient.post(this.ApiDisciplineTeacherUrl, model)
    }
    
}
