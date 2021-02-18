import { Component, OnInit } from '@angular/core';
import { ClassesService } from 'src/app/organization/services/admin/classes/classes.service';
import { Class } from '../../../../interfaces/Class';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-class-list',
  templateUrl: './class-list.component.html',
  styleUrls: ['./class-list.component.css'],
  providers: [ClassesService]
})
export class ClassListComponent implements OnInit {
  //#region Variables
  GetAllClassesReturn: Class[];

  //#endregion

  constructor(private ClassesService: ClassesService) { }



  getAllClasses(): void {

    this.ClassesService.ApiAll().subscribe(
      (_returnSub: Class[]) => {
        this.GetAllClassesReturn = _returnSub;
        console.log(_returnSub);
      },
      error => {
        console.log(error);
      }
    )

  }


  ngOnInit(): void {
    this.getAllClasses();
  }



}
