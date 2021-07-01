import { DisciplineTeacher } from './DisciplineTeacher';
import { Address } from './Address';
import { Contact } from './Contact';
import { Unit } from './Unit';
import { Discipline } from './Discipline';
import { UnitTeacher } from './UnitTeacher';

export class Teacher {
    id: number;
    fullName: string;
    maritalStatus: string;
    photo: string;
    birthday: Date;
    contactid: number;
    contact: Contact;
    addressid: number;
    address: Address;
    disciplines: Discipline[];
    unitteachers: UnitTeacher[];
}
