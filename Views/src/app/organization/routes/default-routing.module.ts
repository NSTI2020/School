import { NgModule } from "@angular/core";
import { Routes, RouterModule } from '@angular/router';

import { HelpersModule } from '../helpers/helpers.module';
import { HeaderComponent } from '../components/navigation/header/header.component';
import { SidenavListComponent } from '../components/navigation/sidenav-list/sidenav-list.component';
import { CreateTeacherComponent } from '../components/teacher/create-teacher/create-teacher.component';
import { ListTeacherComponent } from '../components/teacher/list-teacher/list-teacher.component';
import { TabsTeacherComponent } from '../components/teacher/tabs-teacher/tabs-teacher.component';
import { TabsStudentComponent } from '../components/student/tabs-student/tabs-student.component';
import { CreateStudentComponent } from '../components/student/create-student/create-student.component';
import { EditTeacherComponent } from '../components/teacher/edit-teacher/edit-teacher.component';
import { ScheduleclassComponent } from '../components/scheduleclass/scheduleclass.component';
import { UnitCreateComponent } from '../components/unit/unit-create/unit-create.component';
import { UnitEditComponent } from '../components/unit/unit-edit/unit-edit.component';
import { ChekingaccountCreateComponent } from '../components/checking-account/chekingaccount-create/chekingaccount-create.component';
import { AdminComponent } from '../components/control-panel/admin/admin.component'

const routes: Routes = [
    { path: 'sch', component: ScheduleclassComponent },
    { path: '', component: AdminComponent }

];


@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [RouterModule]
})


export class DefaultRoutingModule { }
