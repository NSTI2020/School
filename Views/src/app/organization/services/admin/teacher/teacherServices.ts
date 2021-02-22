import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { Teacher } from "../../../interfaces/Teacher";

@Injectable()



export class TeacherServices {
    ApiUrl: string = 'http://localhost:5000/api/teachers';

    constructor(private httpClient: HttpClient) { }

    ApiGetAll(): Observable<Teacher[]> {
        return this.httpClient.get<Teacher[]>(this.ApiUrl);
    }



}
