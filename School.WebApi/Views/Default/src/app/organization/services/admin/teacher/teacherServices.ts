import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { Teacher } from "../../../Entities/Teacher";
import { promise } from "selenium-webdriver";
import { DisciplineTeacher } from "src/app/organization/Entities/DisciplineTeacher";
import { Discipline } from "src/app/organization/Entities/Discipline";
import { UnitTeacher } from "src/app/organization/Entities/UnitTeacher";

@Injectable()



export class TeacherServices {



    public ApiUrl: string = 'http://localhost:5000/api/teachers';
    public ApiUrlUnit: string = 'http://localhost:5000/api/teachers/PostUnitTeacher';


    constructor(private _httpClient: HttpClient) { }

    ApiGetAll(): Observable<Teacher[]> {
        return this._httpClient.get<Teacher[]>(this.ApiUrl);
    }

    ApiGetByIdObservable(Id: number): Observable<Teacher> {
        return this._httpClient.get<Teacher>(`${this.ApiUrl}/${Id}`);
    }

    ApiGetB(Id: number): Teacher[] {
        let tes = new Array<Teacher>();


        this._httpClient.get(`${this.ApiUrl}/${Id}`).subscribe((teacher: Teacher) => {
           tes.push(teacher);
        });
        return tes;
    }

    ApiGetByIdPromisse(Id: number): Promise<Teacher> {
        return new Promise((resolve) => {

            resolve(this._httpClient.get<Teacher>(`${this.ApiUrl}/${Id}`)
                .toPromise()
                .then((_teacher: Teacher) => _teacher));
        })

    }

    ApiPost(model: Teacher) {

    

        return this._httpClient.post(this.ApiUrl, model);
    }


    ApiDis(model: UnitTeacher[]) {

        console.log(model);

        return this._httpClient.post(this.ApiUrlUnit, model);
    }

    Put(model: Teacher) {
        return this._httpClient.put(`${this.ApiUrl}/${model.id}`, model);
    }


    PostDeletePhoto(fileName: string) {
        var urlPart = '/deletefile';
        return this._httpClient.get(`${this.ApiUrl + urlPart}/${fileName}`)
    }


    /*
        ApiPostDisciplinesTeacher(_DisTeacher: DisciplineTeacher){
            return this._httpClient.post(_)
        }
    */





    ApiDelete(id: number) {
        return this._httpClient.delete(`${this.ApiUrl}/delete/${id}`)
    }

    uploadFile(file: File, name: string) {
        //array files to receive 
        const fileToUpload = <File>file;
        //format to send for controller.
        const formData = new FormData();
        //building data to send
        formData.append('File', fileToUpload, name);

        return this._httpClient.post(`${this.ApiUrl}/upload`, formData);
    }



















}
