import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from 'src/app/organization/interfaces/Student';
import { HttpClient } from '@angular/common/http';


@Injectable()





export class StudentsServices {

    constructor(private _httpClient: HttpClient) { }
    //Variables
    apiUrl = 'http://localhost:5000/api/students';





    //functions

    ApiAll(): Observable<Student[]> {
        return this._httpClient.get<Student[]>(this.apiUrl);
    }



}
