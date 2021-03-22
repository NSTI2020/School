import { DisciplineTeacher } from './DisciplineTeacher';
import { Address } from './Address';
import { Contact } from './Contact';

export class Teacher {
    constructor() {

    }

    id: number;
    fullname: string;
    birthday: Date;
    maritalstatus: string;
    contactid: number;
    contact: Contact;
    disciplines: DisciplineTeacher[];
    addressid: number;
    address: Address;
}
