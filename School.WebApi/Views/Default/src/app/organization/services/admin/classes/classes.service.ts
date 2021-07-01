import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Class } from "src/app/organization/Entities/Class";


@Injectable()

export class ClassesService {
    apiUrl = 'http://localhost:5000/api/classes';

    constructor(private http: HttpClient) { }

    ApiAll(): Observable<Class[]> {
        return this.http.get<Class[]>(this.apiUrl);
    }






}
