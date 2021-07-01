import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';


@Component({
  selector: 'app-form-debug',
  templateUrl: './form-debug.component.html',
  styleUrls: ['./form-debug.component.css'],

})
export class FormDebugComponent implements OnInit {
  //#region Properties and Fields
  @Input() _Form: FormGroup;
  //#endregion
 
  constructor() { }

  ngOnInit(): void {
  }

}
