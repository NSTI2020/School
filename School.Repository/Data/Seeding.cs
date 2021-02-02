using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using School.Domain.Entities;

namespace School.Repository.Data
{
    public class Seeding
    {
        private List<Room> _listRoom { get; set; }
        private Room _room { get; set; }
        private List<Unit> _listunit { get; set; }
        private Unit _unit { get; set; }
        private Discipline _discipline { get; set; }
        private InstantMessage _instantMessage { get; set; }
        private SocialNetwork _socialNetwork { get; set; }
        private Contact _contact { get; set; }
        private List<Contact> _contactList { get; set; }
        private List<CheckingAccount> _listCheckingAccount { get; set; }
        private CheckingAccount _checkingAccount { get; set; }
        private List<Discipline> _listDisciplines { get; set; }
        private List<Student> _listStudent { get; set; }
        private Student _student { get; set; }
        private List<Teacher> _ListTeachers { get; set; }
        private Teacher _teachers { get; set; }
        private Class _classes { get; set; }

        private readonly SchoolDbContext _context;

        public Seeding(SchoolDbContext context)
        {
            _context = context;
        }

        public List<Room> Room()
        {
            try
            {
                _listRoom = new List<Room>();
                for (int n = 0; n < 9; n++)
                {
                    _room = new Room();
                    _room.Identifier = rooms(n, 0);
                    _room.Description = rooms(n, 1);
                    // _context.Add(_room);
                    _listRoom.Add(_room);
                }

                //await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {

            }

            return _listRoom;
        }
        public string rooms(int p, int s)
        {
            string[,] Identifier = new string[9, 2]

             {{"Inglês", "Sala de Inglês"}, {"Francês", "Sala de Francês"} ,{"Italiano", "Sala de Italiano"}
         ,{"Árabe", "Sala de Árabe"} ,{"Alemão", "Sala de Alemão"}, {"Mandarim","Sala de Mandarim"},
          {"Espanhol", "Sala de Espanhol"} , {"Japonês", "Sala de Japonês"}, {"Portugês","Sala de Portugês" }};
            return (Identifier[p, s]);

        }

        //------------///////
        public List<Discipline> Discipline()
        {
            _listDisciplines = new List<Discipline>();

            try
            {
                string[] Disciplines
                           = new string[]
                           { "Alemão", "Árabe", "Chinês", "Espanhol",
            "Francês", "Inglês", "Italiano", "Japonês", "Portuês" };

                foreach (string Discipline in Disciplines)
                {
                    _discipline = new Discipline();
                    _discipline.Language = Discipline;
                    _listDisciplines.Add(_discipline);
                    //  await _context.AddAsync(_discipline);
                }
                //return await _context.SaveChangesAsync() > 0;

            }
            catch (System.Exception)
            {
                //return false;
            }

            return _listDisciplines;
        }

        public List<Unit> Unit()
        {
            _listunit = new List<Unit>();
            string[] unit0 = new string[] { "Cidade Nova",
            "R. Prof. Costa Chiabi",
            "95",
            "Cidade Nova",
            "Belo Horizonte",
            "MG"};

            _unit = new Unit();
            _unit.Name = unit0[0];
            _unit.Street = unit0[1];
            _unit.Number = unit0[2];
            _unit.Neighborhood = unit0[3];
            _unit.City = unit0[4];
            _unit.State = unit0[5];
            _unit.UnitRoom = Room();
            _unit.UnitCAccount = CAccount();
            _listunit.Add(_unit);
            // _context.Add(_unit);
            //await _context.SaveChangesAsync();


            string[] unt1 = new string[] {  "Lordes"
            ,"R. Espírito Santo"
            ,"1481"
            ,"Lourdes"
            ,"Belo Horizonte"
            ,"MG"};

            _unit = new Unit();
            _unit.Name = unt1[0];
            _unit.Street = unt1[1];
            _unit.Number = unt1[2];
            _unit.Neighborhood = unt1[3];
            _unit.City = unt1[4];
            _unit.State = unt1[5];
            _unit.UnitCAccount = CAccount();
            _listunit.Add(_unit);
            // _context.Add(_unit);
            //await _context.SaveChangesAsync();

            string[] unt2 = new string[] { "Santa Mônica"
            ,"R. Érico Veríssimo"
            ,"1229"
            ,"Santa Mônica"
            ,"Belo Horizonte"
            ,"MG"};

            _unit = new Unit();
            _unit.Name = unt2[0];
            _unit.Street = unt2[1];
            _unit.Number = unt2[2];
            _unit.Neighborhood = unt2[3];
            _unit.City = unt2[4];
            _unit.State = unt2[5];
            _listunit.Add(_unit);
            _unit.UnitCAccount = CAccount();
            // _context.Add(_unit);
            //await _context.SaveChangesAsync();
            return _listunit;
        }

        public List<CheckingAccount> CAccount()
        {

            _listCheckingAccount = new List<CheckingAccount>();

            string[] ccString0 = new string[] { "Itau", "Poupança", "Positivo" };

            int[] ccInt0 = new int[] { 0058, 567985 };

            _checkingAccount = new CheckingAccount();

            _checkingAccount.Bank = ccString0[0];
            _checkingAccount.Agency = ccInt0[0];
            _checkingAccount.Account = ccInt0[1];
            _checkingAccount.Type = ccString0[1];
            _checkingAccount.Status = ccString0[2];
            _listCheckingAccount.Add(_checkingAccount);
            //_context.Add(_checkingAccount);
            // await _context.SaveChangesAsync();

            //-----------------------------------//

            string[] ccString1 = new string[] { "CEF", "Poupança", "Positivo" };

            int[] ccInt1 = new int[] { 5547, 214236 };

            _checkingAccount = new CheckingAccount();

            _checkingAccount.Bank = ccString1[0];
            _checkingAccount.Agency = ccInt1[0];
            _checkingAccount.Account = ccInt1[1];
            _checkingAccount.Type = ccString1[1];
            _checkingAccount.Status = ccString1[2];

            _listCheckingAccount.Add(_checkingAccount);
            //_context.Add(_checkingAccount);
            // await _context.SaveChangesAsync();

            //-----------------------------------//

            string[] ccString2 = new string[] { "B.B", "Poupança", "Positivo" };

            int[] ccInt2 = new int[] { 1458, 325981 };

            _checkingAccount = new CheckingAccount();

            _checkingAccount.Bank = ccString2[0];
            _checkingAccount.Agency = ccInt2[0];
            _checkingAccount.Account = ccInt2[1];
            _checkingAccount.Type = ccString2[1];
            _checkingAccount.Status = ccString2[2];
            _listCheckingAccount.Add(_checkingAccount);

            //    _context.Add(_checkingAccount);
            //    return await _context.SaveChangesAsync() > 0;
            return _listCheckingAccount;
        }

        public List<InstantMessage> InstantM()
        {
            List<InstantMessage> Lims = new List<InstantMessage>();

            string[] ims = new string[] { "WhatsApp", "Skype", "Telegram" };
            foreach (string im in ims)
            {
                _instantMessage = new InstantMessage();
                _instantMessage.Name = im;
                // _context.Add(_instantMessage);
                Lims.Add(_instantMessage);
            }

            return Lims;
        }

        public List<SocialNetwork> SNetwork()
        {
            List<SocialNetwork> Lsc = new List<SocialNetwork>();

            string[,] sNet = new string[3, 2] { { "Facebook", "wwww.facebook.com.br" },
                                                { "Twitter", "www.twitter.com" },
                                                { "Instagram", "www.instagram.com.br" } };
            for (int n = 0; n < 3; n++)
            {
                _socialNetwork = new SocialNetwork();
                _socialNetwork.Name = sNet[n, 0];
                _socialNetwork.URL = sNet[n, 1];
                Lsc.Add(_socialNetwork);
            }

            return Lsc;

        }

        public List<Contact> Contact()
        {
            _contact = new Contact();
            _contactList = new List<Contact>();

            string[] contact0 = new string[] { "3195475-5896",
        "3134589603",
        "nullo",
        "aluno0@aluno0.com.br"
        };
            _contact.CellPhone = contact0[0];
            _contact.HomePhone = contact0[1];
            //_contact.ComercialPhone = contact0[2];
            _contact.Email = contact0[3];
            _contact.instantMessage = InstantM();
            _contact.socialNetwork = SNetwork();
            _contactList.Add(_contact);
            // _context.Add(_contact);
            //   await _context.SaveChangesAsync();
            //---------------------------------------------------------------------------------------------//
            _contact = new Contact();
            string[] contact1 = new string[] { "5685472-5469",
        "3135692458",
        "nullo",
        "aluno1@aluno1.com.br"
        };
            _contact.CellPhone = contact1[0];
            _contact.HomePhone = contact1[1];
            //_contact.ComercialPhone = contact1[2];
            _contact.Email = contact1[3];
            _contact.instantMessage = InstantM();
            _contact.socialNetwork = SNetwork();

            _contactList.Add(_contact);
            // _context.Add(_contact);
            //await _context.SaveChangesAsync();

            //---------------------------------------------------------------------------------------------//
            _contact = new Contact();
            string[] contact2 = new string[] { "315478-2145",
        "3132145252",
        "nullo",
        "aluno2@aluno2.com.br"
        };
            _contact.CellPhone = contact2[0];
            _contact.HomePhone = contact2[1];
            //_contact.ComercialPhone = contact2[2];
            _contact.Email = contact2[3];
            _contact.instantMessage = InstantM();
            _contact.socialNetwork = SNetwork();
            _contactList.Add(_contact);
            // _context.Add(_contact);
            //await _context.SaveChangesAsync() > 0;
            ////---->>>
            //---------------------------------------------------------------------------------------------//

            _contact = new Contact();
            string[] contact3 = new string[] { "3198845-2136",
        "312145-8569",
        "nullo",
        "teacher3@teacher3.com.br"
        };
            _contact.CellPhone = contact3[0];
            _contact.HomePhone = contact3[1];
            //_contact.ComercialPhone = contact3[2];
            _contact.Email = contact3[3];
            _contact.instantMessage = InstantM();
            _contact.socialNetwork = SNetwork();
            _contactList.Add(_contact);
            // _context.Add(_contact);
            //await _context.SaveChangesAsync() > 0;

            //---------------------------------------------------------------------------------------------//

            _contact = new Contact();
            string[] contact4 = new string[] { "319785-5123",
        "317524-5478",
        "nullo",
        "teacher4@teacher4.com.br"
        };
            _contact.CellPhone = contact4[0];
            _contact.HomePhone = contact4[1];
            //_contact.ComercialPhone = contact4[2];
            _contact.Email = contact4[3];
            _contact.instantMessage = InstantM();
            _contact.socialNetwork = SNetwork();
            _contactList.Add(_contact);
            // _context.Add(_contact);
            //await _context.SaveChangesAsync() > 0;

            //---------------------------------------------------------------------------------------------//
            _contact = new Contact();
            string[] contact5 = new string[] { "319621-4785",
        "313344556622",
        "nullo",
        "teacher5@teacher5.com.br"
        };
            _contact.CellPhone = contact5[0];
            _contact.HomePhone = contact5[1];
            //_contact.ComercialPhone = contact5[2];
            _contact.Email = contact5[3];
            _contact.instantMessage = InstantM();
            _contact.socialNetwork = SNetwork();
            _contactList.Add(_contact);
            // _context.Add(_contact);
            //await _context.SaveChangesAsync() > 0;
            return _contactList;

        }

        public List<Student> Student()
        {
            _listStudent = new List<Student>();

            string[] sts0 = new string[]
            {"Aluno0", "SobreNome Aluno0", "Rua do Aluno0", "000",
            "Bairro Aluno0","Cidade Aluno0", "Estado Aluno0","ComplementoALuno0"  };

            string[] sts1 = new string[]
            {"Aluno1", "SobreNome Aluno1", "Rua do Aluno1", "111",
            "Bairro Aluno1","Cidade Aluno1", "Estado Aluno1","ComplementoALuno0"  };

            string[] sts2 = new string[]
            {"Aluno2", "SobreNome Aluno2", "Rua do Aluno2", "222",
            "Bairro Aluno2","Cidade Aluno2", "Estado Aluno2","ComplementoALuno0"  };

            Contact[] stus = Contact().ToArray();
            Discipline[] dis = Discipline().ToArray();

            List<Discipline> listDisciplinesStudent0 = new List<Discipline>();
            listDisciplinesStudent0.Add(dis[0]);
            listDisciplinesStudent0.Add(dis[1]);
            listDisciplinesStudent0.Add(dis[2]);

            _student = new Student();
            _student.Name = sts0[0];
            _student.LastName = sts0[1];
            _student.Discipline = listDisciplinesStudent0;
            _student.Contact = stus[0];
            _student.Street = sts0[2];
            _student.Number = sts0[3];
            _student.Neighborhood = sts0[4];
            _student.City = sts0[5];
            _student.State = sts0[6];
            _student.Complement = sts0[7];
            _listStudent.Add(_student);
            //_context.Add(_student);
            //await _context.SaveChangesAsync();
            //
            List<Discipline> listDisciplinesStudent1 = new List<Discipline>();
            listDisciplinesStudent1.Add(dis[3]);
            listDisciplinesStudent1.Add(dis[4]);
            listDisciplinesStudent1.Add(dis[5]);
            _student = new Student();
            _student.Name = sts1[0];
            _student.LastName = sts1[1];
            _student.Discipline = listDisciplinesStudent1;
            _student.Contact = stus[1];
            _student.Street = sts1[2];
            _student.Number = sts1[3];
            _student.Neighborhood = sts1[4];
            _student.City = sts1[5];
            _student.State = sts1[6];
            _student.Complement = sts1[7];
            _listStudent.Add(_student);
            //_context.Add(_student);
            //await _context.SaveChangesAsync();
            //
            List<Discipline> listDisciplinesStudent2 = new List<Discipline>();
            listDisciplinesStudent2.Add(dis[6]);
            listDisciplinesStudent2.Add(dis[7]);
            listDisciplinesStudent2.Add(dis[8]);
            _student = new Student();
            _student.Name = sts2[0];
            _student.LastName = sts2[1];
            _student.Discipline = listDisciplinesStudent2;
            _student.Contact = stus[2];
            _student.Street = sts2[2];
            _student.Number = sts2[3];
            _student.Neighborhood = sts2[4];
            _student.City = sts2[5];
            _student.State = sts2[6];
            _student.Complement = sts2[7];
            _listStudent.Add(_student);
            //_context.Add(_student);
            //await _context.SaveChangesAsync();
            return _listStudent;
        }

        public List<Teacher> Teacher()
        {
            try
            {
                _ListTeachers = new List<Teacher>();
                Contact[] stus = Contact().ToArray();
                Discipline[] dis = Discipline().ToArray();

                List<Discipline> listDisciplinesTeacher0 = new List<Discipline>();
                listDisciplinesTeacher0.Add(dis[0]);
                listDisciplinesTeacher0.Add(dis[1]);
                listDisciplinesTeacher0.Add(dis[2]);

                _teachers = new Teacher();
                _teachers.Name = "Teacher0";
                _teachers.LastName = "Teacher0UltimoNome";
                _teachers.Contact = stus[3];
                _teachers.Discipline = listDisciplinesTeacher0;
                _teachers.Street = "RUA Teacher0";
                _teachers.Number = "654321";
                _teachers.Neighborhood = "Bairro Teacher0";
                _teachers.City = "Cidade Teacher0";
                _teachers.State = "Estado Teacher0";
                _teachers.Complement = "Complemento Teacher0";
                _ListTeachers.Add(_teachers);
                //_context.Add(_teachers);
                // await _context.SaveChangesAsync();


                List<Discipline> listDisciplinesTeacher1 = new List<Discipline>();
                listDisciplinesTeacher1.Add(dis[3]);
                listDisciplinesTeacher1.Add(dis[4]);
                listDisciplinesTeacher1.Add(dis[5]);
                _teachers = new Teacher();
                _teachers.Name = "Teacher1";
                _teachers.LastName = "Teacher1UltimoNome";
                _teachers.Contact = stus[4];
                _teachers.Discipline = listDisciplinesTeacher1;
                _teachers.Street = "RUA Teacher1";
                _teachers.Number = "4151";
                _teachers.Neighborhood = "Bairro Teacher1";
                _teachers.City = "Cidade Teacher1";
                _teachers.State = "Estado Teacher1";
                _teachers.Complement = "Complemento Teacher1";

                _ListTeachers.Add(_teachers);
                //_context.Add(_teachers);
                //await _context.SaveChangesAsync();

                List<Discipline> listDisciplinesTeacher2 = new List<Discipline>();
                listDisciplinesTeacher2.Add(dis[6]);
                listDisciplinesTeacher2.Add(dis[7]);
                listDisciplinesTeacher2.Add(dis[8]);
                _teachers = new Teacher();
                _teachers.Name = "Teacher2";
                _teachers.LastName = "Teacher2UltimoNome";
                _teachers.Contact = stus[5];
                _teachers.Discipline = listDisciplinesTeacher2;
                _teachers.Street = "RUA Teacher2";
                _teachers.Number = "7456";
                _teachers.Neighborhood = "Bairro Teacher2";
                _teachers.City = "Cidade Teacher2";
                _teachers.State = "Estado Teacher2";
                _teachers.Complement = "Complemento Teacher2";
                _ListTeachers.Add(_teachers);
                //  _context.Add(_teachers);
                // return await _context.SaveChangesAsync() > 0;
            }
            catch (System.Exception)
            {

            }
            return _ListTeachers;
        }

        public async Task<bool> Classes()
        {

            Teacher[] stus = Teacher().ToArray();
            Discipline[] disp = Discipline().ToArray();
            Room[] rms = Room().ToArray();
            Unit[] unt = Unit().ToArray();


            _classes = new Class();
            _classes.Teacher = stus[0];
            _classes.Start = DateTime.Now;
            _classes.End = DateTime.Now;
            _classes.Discipline = disp[0];
            _classes.Students = Student();
            _classes.Unit = unt[0];
            _classes.room = rms[0];
            _context.Add(_classes);

            return await _context.SaveChangesAsync() > 0;
        }


    }
}
