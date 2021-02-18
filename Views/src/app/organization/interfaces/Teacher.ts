import { Discipline } from './Discipline';
import { Address } from './Address';
import { Contact } from './Contact';

export class Teacher {
    id: number;
    name: string;
    lastname: string;
    contactid: number;
    contact: Contact;
    disciplineid: number;
    discipline: Discipline[];
    addressid: number;
    address: Address;
}
