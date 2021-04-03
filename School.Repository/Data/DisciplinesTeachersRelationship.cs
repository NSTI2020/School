using System.Collections.Generic;
using School.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace School.Repository.Data
{
    public class DisciplinesTeachersRelationship:IEntityTypeConfiguration<DisciplineTeacher>
    {
       public void Configure(EntityTypeBuilder<DisciplineTeacher> builder)
        {
           builder.HasKey(_dt => new {_dt.DisciplineId, _dt.TeacherId});
         
        }
    }
}