//Testes
//import { BrowserModule } from '@angular/platform-browser';
//import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DateTimeFormatPipePipe } from '../app/organization/helpers/DateTimeFormatPipe.pipe';

//native modules
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';


//Organization
import { MaterialModule } from './organization/modules/material.module';
import { AnimationsModule } from './organization/modules/animations.module';

//Components

import { HelpersModule } from './organization/helpers/helpers.module';
import { HeaderComponent } from './organization/components/navigation/header/header.component';
import { SidenavListComponent } from './organization/components/navigation/sidenav-list/sidenav-list.component';
import { CreateTeacherComponent } from './organization/components/control-panel/teacher/create-teacher/create-teacher.component';
import { ListTeacherComponent } from './organization/components/control-panel/teacher/list-teacher/list-teacher.component';
import { DefaultRoutingModule } from './organization/routes/default-routing.module';
import { EditTeacherComponent } from './organization/components/control-panel/teacher/edit-teacher/edit-teacher.component';
import { UnitCreateComponent } from './organization/components/control-panel/unit/unit-create/unit-create.component';
import { UnitEditComponent } from './organization/components/control-panel/unit/unit-edit/unit-edit.component';
import { ChekingaccountCreateComponent } from './organization/components/control-panel/checking-account/chekingaccount-create/chekingaccount-create.component';
import { AdminComponent } from './organization/components/control-panel/admin/admin.component';
import { ClassListComponent } from './organization/components/control-panel/classes/class-list/class-list.component'
import { StudentsListComponent } from './organization/components/control-panel/students/students-list/students-list.component';

//SERVICES
import { ClassesService } from './organization/services/admin/classes/classes.service';
import { StudentsServices } from './organization/services/admin/students/students.services';
import { TeacherServices } from './organization/services/admin/teacher/teacherServices';

import { HttpClientModule } from '@angular/common/http';
import { ControlPanelComponent } from './organization/components/control-panel/control-panel/control-panel.component';




@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    SidenavListComponent,
    CreateTeacherComponent,
    ListTeacherComponent,
    EditTeacherComponent,
    UnitCreateComponent,
    UnitEditComponent,
    ChekingaccountCreateComponent,
    AdminComponent,
    ClassListComponent,
    DateTimeFormatPipePipe,
    StudentsListComponent,
    ControlPanelComponent

  ],

  imports: [
    MaterialModule,
    HelpersModule,
    DefaultRoutingModule,
    AnimationsModule,
    HttpClientModule


  ],
  providers: [
    ClassesService,
    StudentsServices,
    TeacherServices

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
