import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { Teacher } from "../../../interfaces/Teacher";
import { promise } from "selenium-webdriver";

@Injectable()



export class TeacherServices {
    ApiUrl: string = 'http://localhost:5000/api/teachers';

    constructor(private _httpClient: HttpClient) { }

    ApiGetAll(): Observable<Teacher[]> {
        return this._httpClient.get<Teacher[]>(this.ApiUrl);
    }

    ApiGetByIdObservable(Id: number): Observable<Teacher> {
        return this._httpClient.get<Teacher>(`${this.ApiUrl}/GetById/${Id}`);
    }

    ApiGetByIdPromisse(Id: number): Promise<Teacher> {
        return this._httpClient.get<Teacher>(`${this.ApiUrl}/GetById/${Id}`).toPromise()
            .then((_teacherPromisse: Teacher) => _teacherPromisse);
    }

    ApiPost(_teacher: Teacher): Observable<Teacher> {
        return this._httpClient.post<Teacher>(this.ApiUrl, _teacher);
    }





}
