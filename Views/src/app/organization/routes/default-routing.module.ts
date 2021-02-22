import { NgModule } from "@angular/core";
import { Routes, RouterModule } from '@angular/router';

import { HelpersModule } from '../helpers/helpers.module';
import { HeaderComponent } from '../components/navigation/header/header.component';
import { SidenavListComponent } from '../components/navigation/sidenav-list/sidenav-list.component';
import { CreateTeacherComponent } from '../components/control-panel/teacher/create-teacher/create-teacher.component';
import { ListTeacherComponent } from '../components/control-panel/teacher/list-teacher/list-teacher.component';
import { EditTeacherComponent } from '../components/control-panel/teacher/edit-teacher/edit-teacher.component';
import { UnitCreateComponent } from '../components/control-panel/unit/unit-create/unit-create.component';
import { UnitEditComponent } from '../components/control-panel/unit/unit-edit/unit-edit.component';
import { ChekingaccountCreateComponent } from '../components/control-panel/checking-account/chekingaccount-create/chekingaccount-create.component';
import { AdminComponent } from '../components/control-panel/admin/admin.component'
import { ClassListComponent } from '../components/control-panel/classes/class-list/class-list.component';
import { StudentsListComponent } from '../components/control-panel/students/students-list/students-list.component';
import { ControlPanelComponent } from '../components/control-panel/control-panel/control-panel.component';

const routes: Routes = [
    { path: 'students', component: StudentsListComponent },
    { path: '', component: ControlPanelComponent }


];
const routes2: Routes = [];


@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [RouterModule]
})


export class DefaultRoutingModule { }
