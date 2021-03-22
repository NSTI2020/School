import { Teacher } from './Teacher';
import { DisciplineTeacher } from './DisciplineTeacher';
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
    discipline: DisciplineTeacher;
    studentid: number;
    students: Student[];
    unitid: number;
    unit: Unit;
    roomid: number;
    room: Room;

}

