using System;
using System.Collections.Generic;

namespace School.Domain.Entities.Dtos
{
    public class ClassDto
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public TeacherDto Teacher { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int DisciplineDtoId { get; set; }
        public DisciplineDto DisciplineDto { get; set; }
        public List<StudentDto> StudentsDto { get; set; }
        public int UnitDtoId { get; set; }
        public UnitDto UnitDto { get; set; }
        public int roomDtoId { get; set; }
        public RoomDto RoomDto { get; set; }
    }
}
