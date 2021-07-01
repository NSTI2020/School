import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ControlPanelComponent } from './organization/components/control-panel/panels/control-panel.component';
import { TeacherCreateComponent } from './organization/components/control-panel/panels/teacher/teacher-create/teacher-create.component'
import { TeacherDetailsComponent } from './organization/components/control-panel/panels/teacher/teacher-details/teacher-details.component'
import { CommonModule } from '@angular/common';



import { ToastrModule } from 'ngx-toastr';
//NGX
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ModalModule, BsModalService } from 'ngx-bootstrap/modal';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { BsDatepickerModule, BsLocaleService, } from 'ngx-bootstrap/datepicker';
import { BsDropdownModule } from "ngx-bootstrap/dropdown";
import { WebcamModule } from 'ngx-webcam';

//Angular
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { TeacherServices } from './organization/services/admin/teacher/teacherServices';
import { HttpClientModule } from '@angular/common/http';

//import { TeacherValidatorsService } from './organization/services/admin/teacher/teacher-validators.service';
import { TeacherEditComponent } from './organization/components/control-panel/panels/teacher/teacher-edit/teacher-edit.component';
import { TeacherDeleteComponent } from './organization/components/control-panel/panels/teacher/teacher-delete/teacher-delete.component'
//import { MultiSelectDropdownComponent } from './multi-select-dropdown/multi-select-dropdow


//Unit
import { UnitServices } from './organization/services/admin/unit/unit.services';
//import { UnitValidatorsService } from './organization/services/admin/unit/unit-validators.service';
import { UnitCreateComponent } from './organization/components/control-panel/panels/unit/unit-create/unit-create.component';
import { FormDebugComponent } from './organization/components/control-panel/panels/form-debug/form-debug.component';
import { AddressComponent } from './organization/components/control-panel/panels/shared/address/address.component';
import { ContactComponent } from './organization/components/control-panel/panels/shared/contact/contact.component';
import { CamComponent } from './organization/components/control-panel/panels/shared/cam/cam.component'
//import { ValidatorsGlobal } from './organization/components/control-panel/panels/shared/validators-global'



@NgModule({
  declarations: [
    AppComponent,
    ControlPanelComponent,
    TeacherCreateComponent,
    TeacherDetailsComponent,
    TeacherEditComponent,
    TeacherDeleteComponent,
    UnitCreateComponent,
    FormDebugComponent,
    AddressComponent,
    ContactComponent,
    CamComponent
  ],
  imports: [
    TabsModule.forRoot(),
    ModalModule.forRoot(),
    TooltipModule.forRoot(),
    AccordionModule.forRoot(),
    BsDatepickerModule.forRoot(),
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot(),
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    WebcamModule



  ],
  providers: [BsModalService,
    TeacherServices,
    HttpClientModule,
    //ValidatorsGlobal,
    UnitServices,
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
