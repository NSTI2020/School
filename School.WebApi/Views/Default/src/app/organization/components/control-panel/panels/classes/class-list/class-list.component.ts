import { state, style, trigger } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { ClassesService } from 'src/app/organization/services/admin/classes/classes.service';
import { Class } from '../../../../Entities/Class';


@Component({
  selector: 'app-class-list',
  templateUrl: './class-list.component.html',
  styleUrls: ['./class-list.component.css'],
  providers: [ClassesService]

})

export class ClassListComponent implements OnInit {


  //#region Variables
  GetAllClassesReturn: Class[];

  //Filter field search.
  filteredArray: Class[];
  _stringOfFilter: string;

  getAllClasses(): void {

    this.ClassesService.ApiAll().subscribe(
      (_returnSub: Class[]) => {
        this.GetAllClassesReturn = _returnSub;
        this.filteredArray = _returnSub;
      },
      error => {
        console.log(error);
      }
    )

  }

  get filteringString() {
    return this._stringOfFilter;
  }

  set filteringString(value: string) {
    this._stringOfFilter = value;
    this.filteredArray
      = this._stringOfFilter
        ? this.actionFilter(this.filteringString)
        : this.GetAllClassesReturn;
  }

  actionFilter(filteredBy: string): Class[] {
    filteredBy = filteredBy.toLocaleLowerCase();
    return this.GetAllClassesReturn.filter(N => N.discipline.discipline.language.toLocaleLowerCase().indexOf(filteredBy) !== -1)
  }

  //#endregion


  constructor(private ClassesService: ClassesService) { }


  ngOnInit(): void {
    this.getAllClasses();
  }



}
