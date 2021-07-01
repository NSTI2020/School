import { NgModule } from "@angular/core";


//NGX
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { AccordionModule } from 'ngx-bootstrap/accordion';
//import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
//import { BsDropdownModule } from "ngx-bootstrap";


@NgModule({
    imports: [
        TabsModule.forRoot(),
        ModalModule.forRoot(),
        TooltipModule.forRoot(),
        AccordionModule.forRoot(),
      //  BsDatepickerModule.forRoot(),
        //BsDropdownModule.forRoot(),

    ],
    exports: [
        TabsModule,
        ModalModule,
        TooltipModule,
        AccordionModule,
       // BsDatepickerModule,
       //BsDropdownModule
        
    ],
    
})

export class NgxBootstrapModule { }
