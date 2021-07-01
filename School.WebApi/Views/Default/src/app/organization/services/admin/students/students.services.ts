import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from 'src/app/organization/Entities/Student';
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

    put(model: Student) {
        this._httpClient.put<Student>(`${this.apiUrl}/${model.id}`, model);
    }


    ApiGetById(Id: string): Observable<Student> {
        return this._httpClient.get<Student>(`${this.apiUrl}/${Id}`);
    }


}
