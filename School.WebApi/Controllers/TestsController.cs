using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities;
using School.Repository.Data;

namespace School.WebApi.Controllers
{

    [ApiController]
    [Route("api/{controller}")]
    public class TestsController : ControllerBase
    {

        private readonly ISchoolRepository _repo;
        public TestsController(ISchoolRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{seed}")]
        public async Task<string> seed()
        {
            #region carlos
            List<DisciplineTeacher> ListDisciplinesTeachers = new List<DisciplineTeacher>();
            //CARLOS
            Teacher T0 = new Teacher()
            {
                FullName = "Carlos Silva Duarte",
                MaritalStatus = "Casado",
                Birthday = DateTime.Now,
                Contact = new Contact()
                {
                    Email = "email@email.com",
                    CellPhone = "999999999999"
                },
                Address = new Address()
                {
                    Neighborhood = "Lordes",
                    Street = "R. Espírito Santo",
                    Number = "1481",
                    City = "Belo Horizonte",
                    State = "MG",
                },
            };
            ListDisciplinesTeachers.Add(new DisciplineTeacher()
            {
                Discipline = new Discipline() { Language = "Espanhol" },
                Teacher = T0,
            });
            ListDisciplinesTeachers.Add(new DisciplineTeacher()
            {
                Discipline = new Discipline() { Language = "Inglês" },
                Teacher = T0,
            });

            _repo.Add(T0);

            ListDisciplinesTeachers.ForEach(item =>
            {
                _repo.Add(item);
            });

            #endregion

            #region Nivia
            List<DisciplineTeacher> ListDisciplinesTeachers1 = new List<DisciplineTeacher>();

            Teacher T1 = new Teacher()
            {
                FullName = "Nivia Lourdes Ricardo",
                MaritalStatus = "Casada",
                Birthday = DateTime.Now,
                Contact = new Contact()
                {
                    Email = "email@email.com",
                    CellPhone = "999999999999"
                },
                Address = new Address()
                {
                    Neighborhood = "Lordes",
                    Street = "R. teste Santo",
                    Number = "2154",
                    City = "Belo Horizonte",
                    State = "MG",
                },
            };
            ListDisciplinesTeachers1.Add(new DisciplineTeacher()
            {
                Discipline = new Discipline() { Language = "Espanhol" },
                Teacher = T1,
            });

            _repo.Add(T1);

            ListDisciplinesTeachers1.ForEach(item =>
            {
                _repo.Add(item);
            });

            #endregion

            if (await _repo.SaveChangesAsync())
            {
                return "FOI CRIADO...";
            }
            return "Não foi criado... sniff";
        }

        public void tmp()
        {

        }




    }
}