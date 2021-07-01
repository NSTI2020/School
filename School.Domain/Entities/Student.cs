using System;
using System.Collections.Generic;

namespace School.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}
