import { Room } from './Room';
import { CheckingAccount } from './CheckingAccount';
import { Address } from './Address';

export class Unit {
    id: number;
    name: string;
    roomsid: number;
    rooms: Room[];
    checkingaccountsid: number;
    checkingaccounts: CheckingAccount[];
    addressid: number;
    address: Address;
}
