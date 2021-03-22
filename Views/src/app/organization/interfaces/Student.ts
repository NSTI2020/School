
//import { Discipline } from './DisciplineTeacher';
import { Contact } from './Contact';
import { Address } from './Address';



export class Student {
    id: number;
    name: string;
    lastname: string;
    contactid: number;
    contact: Contact;
    disciplineid: number;
  //  discipline: Discipline[];
    addressid: number;
    address: Address;
}
