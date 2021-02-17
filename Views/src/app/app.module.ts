//native modules
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';

//Organization
import { MaterialModule } from './organization/modules/material.module';
import { AnimationsModule } from './organization/modules/animations.module';

//Components
import { NavComponent } from './organization/components/nav/nav.component';

import { HelpersModule } from './organization/helpers/helpers.module';
import { HeaderComponent } from './organization/components/navigation/header/header.component';
import { SidenavListComponent } from './organization/components/navigation/sidenav-list/sidenav-list.component';
import { CreateTeacherComponent } from './organization/components/teacher/create-teacher/create-teacher.component';
import { ListTeacherComponent } from './organization/components/teacher/list-teacher/list-teacher.component';
import { TabsTeacherComponent } from './organization/components/teacher/tabs-teacher/tabs-teacher.component';
import { TabsStudentComponent } from './organization/components/student/tabs-student/tabs-student.component';
import { CreateStudentComponent } from './organization/components/student/create-student/create-student.component';
import { DefaultRoutingModule } from './organization/routes/default-routing.module';
import { EditTeacherComponent } from './organization/components/teacher/edit-teacher/edit-teacher.component';
import { ScheduleclassComponent } from './organization/components/scheduleclass/scheduleclass.component';
import { UnitCreateComponent } from './organization/components/unit/unit-create/unit-create.component';
import { UnitEditComponent } from './organization/components/unit/unit-edit/unit-edit.component';
import { ChekingaccountCreateComponent } from './organization/components/checking-account/chekingaccount-create/chekingaccount-create.component';
import { AdminComponent } from './organization/components/control-panel/admin/admin.component';
import { ClassesListComponent } from './organization/scheduleclass/classes-list/classes-list.component'


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HeaderComponent,
    SidenavListComponent,
    CreateTeacherComponent,
    ListTeacherComponent,
    TabsTeacherComponent,
    TabsStudentComponent,
    CreateStudentComponent,
    EditTeacherComponent,
    ScheduleclassComponent,
    UnitCreateComponent,
    UnitEditComponent,
    ChekingaccountCreateComponent,
    AdminComponent,
    ClassesListComponent


  ],

  imports: [
    MaterialModule,
    HelpersModule,
    DefaultRoutingModule,
    AnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
