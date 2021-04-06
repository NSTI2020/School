//Testes
//import { BrowserModule } from '@angular/platform-browser';
//import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DateTimeFormatPipePipe } from '../app/organization/helpers/DateTimeFormatPipe.pipe';
import { TabsModule } from 'ngx-bootstrap/tabs';
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
import { ControlPanelComponent } from './organization/components/control-panel/control-panel/control-panel.component';
import { StudentCreateComponent } from './organization/components/control-panel/students/student-create/student-create.component';


//SERVICES
import { ClassesService } from './organization/services/admin/classes/classes.service';
import { StudentsServices } from './organization/services/admin/students/students.services';
import { TeacherServices } from './organization/services/admin/teacher/teacherServices';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

//material
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';
import { MatTabsModule } from '@angular/material/tabs';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDividerModule } from '@angular/material/divider';
import { MatMenuModule } from '@angular/material/menu';
import { MatSnackBar } from '@angular/material/snack-bar'

//animations
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { DisciplineServices } from './organization/services/admin/disciplines/disciplines.services';
import { DeleteTeacherComponent } from './organization/components/control-panel/teacher/delete-teacher/delete-teacher.component';
import { DetailsTeacherComponent } from './organization/components/control-panel/teacher/details-teacher/details-teacher.component';
import { IMPLICIT_REFERENCE } from '@angular/compiler/src/render3/view/util';




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
    ControlPanelComponent,
    StudentCreateComponent,
    DeleteTeacherComponent,
    DetailsTeacherComponent,
    

  ],

  imports: [
    MaterialModule,
    HelpersModule,
    DefaultRoutingModule,
    AnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,

    MatButtonModule,
    MatIconModule,
    MatSidenavModule,
    MatToolbarModule,
    MatListModule,
    MatTabsModule,
    MatInputModule,
    MatFormFieldModule,
    MatDialogModule,
    MatSelectModule,
    MatCheckboxModule,
    MatCardModule,
    MatTableModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatDividerModule,
    MatMenuModule,
    BrowserModule,
BrowserAnimationsModule,

    TabsModule.forRoot()
    


  ],
  providers: [
    ClassesService,
    StudentsServices,
    TeacherServices,
    DisciplineServices,
    MatSnackBar

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
