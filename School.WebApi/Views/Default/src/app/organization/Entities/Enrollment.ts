import { Address } from "./Address";
import { Contact } from "./Contact";
import { Discipline } from "./Discipline";
import { Unit } from "./Unit";

export class Enrollment {

     id:number;
     dateOfEnrollment:Date;
     unitid:number;
     unit:Unit;
     contactid:number;
     contact:Contact;
     addressid:number;
     address:Address;
     disciplines: Discipline[];
}