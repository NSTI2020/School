import { Room } from './Room';
import { CheckingAccount } from './CheckingAccount';
import { Address } from './Address';
import { Student } from './Student';
import { Teacher } from './Teacher';
import { Contact } from './Contact';

export class Unit {
    id: number;
    name: string;
    addressid: number;
    address: Address;
    contactid: number;
    contact: Contact;
    rooms: Room[];
    checkingaccounts: CheckingAccount[];
    students: Student[];
                                                                                                                                                          
}
