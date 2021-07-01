import { Component, OnInit } from '@angular/core';
import { WebcamImage, WebcamInitError } from 'ngx-webcam';
import { Observable } from 'rxjs/internal/Observable';
import { Subject } from 'rxjs/internal/Subject';

import { Teacher } from 'src/app/organization/Entities/Teacher';
import { Helpers } from 'src/app/organization/helpers/globalHelpers';
import { TeacherServices } from 'src/app/organization/services/admin/teacher/teacherServices';
import { LocalHelpersCam } from 'src/app/organization/components/control-panel/panels/shared/cam/LocalHelpersCam';
import { ValidatorsGlobal } from '../validators-global';
import { LocalHelpersTeacher } from '../../teacher/localHelpersTeacher';

@Component({
  selector: 'app-cam',
  templateUrl: './cam.component.html',
  styleUrls: ['./cam.component.css']
})
export class CamComponent implements OnInit {

  constructor(
    //private _Ts: TeacherServices,
    public _LocalHelpersCam: LocalHelpersCam,

  ) { }



  ngOnInit(): void {
    //console.log(this._LocalHelpersCam.showWebcam)
  }

}
