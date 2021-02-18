import { Teacher } from './Teacher';
import { Discipline } from './Discipline';
import { Student } from './Student';
import { Unit } from './Unit';
import { Room } from './Room';

export class Class {

    id: number;
    teacherid: number;
    teacher: Teacher;
    start: Date;
    end: Date;
    disciplineid: number;
    discipline: Discipline;
    studentid: number;
    students: Student[];
    unitid: number;
    unit: Unit;
    roomid: number;
    room: Room;

}

