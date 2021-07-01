import { Injectable } from "@angular/core";
import { WebcamImage } from "ngx-webcam";
import { Teacher } from "src/app/organization/Entities/Teacher";
import { Helpers } from "src/app/organization/helpers/globalHelpers";
import { TeacherServices } from "src/app/organization/services/admin/teacher/teacherServices";

@Injectable({
    providedIn: 'root'
})


export class LocalHelpersTeacher {

    constructor(
        private _GlobalHelpers: Helpers,
        private _Ts: TeacherServices,
    ) { }

    //business entity 
    private _teacher: Teacher;
    private apiPhoto = 'http://localhost:5000/resources/images/'
    //will receive a file that to be saved on a server.
    // private _file: File = null;
    //imagem that produced by webcam
    private webcamImage: WebcamImage = null;

    //  private fileName: string;
    //Full path until to the api database with file name.
    private _imgDynamic: string;
    //Url path to the api database
    //Set a new imagem file or are changing a old file
    private allUrlPhoto: string;


    uploadImgFile(): string {
        //Call method that generator name of file
        this._GlobalHelpers.generateFileName();
        this._Ts.uploadFile(this._GlobalHelpers._file, this._GlobalHelpers.fileName).subscribe(() => {
            //this._imgDynamic = this._GlobalHelpers.fileName;
        })
        return this._GlobalHelpers.fileName
    }


    //   uploadFile(mode: string) {
    //       //receive name for file to upload provided by this.generateFileName()
    //       this._GlobalHelpers.generateFileName();
    //       //entity that will to be save and receive name for file.
    //       //   this._teacher.photo = this.fileName
    //       //Bind parts of files names that to be upload.
    //       this.allUrlPhoto = this.apiPhoto + this._GlobalHelpers.fileName;
    //       //call method that to update
    //       this._Ts.uploadFile(this._GlobalHelpers._file, this._GlobalHelpers.fileName).subscribe(() => {
    //           this._imgDynamic = this._GlobalHelpers.fileName;
    //       })
    //   }
    //
    //
    onChangephoto($event) {

        if ($event.target.files && $event.target.files.length) {
            //this._file = $event.target.files;
            this._GlobalHelpers._file = $event.target.files[0];
        }
        //checking if old image exists
        if (this._teacher.photo != null) {
            // this.uploadFile('put');
        }
        else {
            //  this.uploadFile('post');
        }
        //   this.waitSeconds(300);
        //   this.apiPhotoFile = true;
        //   this.apiPhoto = false;
        //this.webcamImage = null;

    }






}