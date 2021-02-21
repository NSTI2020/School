using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using School.Domain.Entities;
using System.Linq;

namespace School.Repository.Data
{
    public class Seeding
    {
        private List<Room> _listRoom { get; set; }
        private Room _room { get; set; }
        public List<Room> _allRooms = null;
        public List<Room> List0 = null;
        public List<Room> List1 = null;
        public List<Room> List2 = null;
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
        private Address _address { get; set; }
        private List<Address> _listAddress { get; set; } = new List<Address>();
        public List<Student> ListStudent0 { get; set; } = new List<Student>();
        public List<Student> ListStudent1 { get; set; } = new List<Student>();
        public List<Student> ListStudent2 { get; set; } = new List<Student>();
        private List<Teacher> _ListTeachers { get; set; }
        private Teacher _teachers { get; set; }
        private Class _classes { get; set; }

        private readonly SchoolDbContext _context;

        public Seeding(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Seed()
        {
            return await Classes();
        }


        public List<Room> Rooms(int lists)
        {

            _allRooms = new List<Room>();

            for (int n = 0; n < 27; n++)
            {
                _room = new Room();
                _room.Identifier = ListRooms(n, 0);
                //  _room.Description = ListRooms(n, 1);
                _room.Capacity = 10;
                _allRooms.Add(_room);

            }

            List0 = _allRooms.Take(9).ToList();
            List1 = _allRooms.Skip(9).Take(9).ToList();
            List2 = _allRooms.Skip(18).Take(19).ToList();

            switch (lists)
            {
                case 0:
                    return List0;

                case 1:
                    return List1;

                case 2:
                    return List2;
            }

            return _allRooms;
        }


        public string ListRooms(int e, int d)
        {

            string[,] Identifier = new string[27, 2]
           {{"Inglês", "Sala de Inglês"}, {"Francês", "Sala de Francês"} ,{"Italiano", "Sala de Italiano"}
         ,{"Árabe", "Sala de Árabe"} ,{"Alemão", "Sala de Alemão"}, {"Mandarim","Sala de Mandarim"},
          {"Espanhol", "Sala de Espanhol"} , {"Japonês", "Sala de Japonês"}, {"Portugês","Sala de Portugês"},
          {"01", "Inglês"}, {"02", "Francês"} ,{"03", "Italiano"}
         ,{"04", "Árabe"} ,{"05", "Alemão"}, {"06","Mandarim"},
          {"07", "Espanhol"} , {"08", "Japonês"}, {"09","Portugês" },
          {"Sala 10", "Inglês"}, {"Sala 20", "Francês"} ,{"Sala 30", "Italiano"}
         ,{"Sala 40", "Árabe"} ,{"Sala 50", "Alemão"}, {"Sala 60","Mandarim"},
          {"Sala 70", "Espanhol"} , {"Sala 80", "Japonês"}, {"Sala 90","Portugês" } };


            return Identifier[e, d];
        }

        public List<Discipline> Discipline()
        {
            _listDisciplines = new List<Discipline>();

            try
            {
                string[] Disciplines
                           = new string[]
                           { "Alemão", "Árabe", "Chinês", "Espanhol",
            "Francês", "Inglês", "Italiano", "Japonês", "Portuês" };
                int n = 0;
                foreach (string Discipline in Disciplines)
                {
                    if (n < 1)
                        n++;
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
            Address _address0 = new Address();
            _address.Street = unit0[1];
            _address.Number = unit0[2];
            _address.Neighborhood = unit0[3];
            _address.City = unit0[4];
            _address.State = unit0[5];

            _unit = new Unit();
            _unit.Name = unit0[0];
            _unit.Address = _address0;
            _unit.Rooms = Rooms(0);
            _unit.CheckingAccounts = CAccount();
            _listunit.Add(_unit);
            // _context.Add(_unit);
            //await _context.SaveChangesAsync();


            string[] unt1 = new string[] {  "Lordes"
            ,"R. Espírito Santo"
            ,"1481"
            ,"Lourdes"
            ,"Belo Horizonte"
            ,"MG"};
            Address _address1 = new Address();
            _address.Street = unt1[1];
            _address.Number = unt1[2];
            _address.Neighborhood = unt1[3];
            _address.City = unt1[4];
            _address.State = unt1[5];

            _unit = new Unit();
            _unit.Name = unt1[0];
            _unit.Address = _address1;
            _unit.Rooms = Rooms(1);
            _unit.CheckingAccounts = CAccount();
            _listunit.Add(_unit);
            // _context.Add(_unit);
            //await _context.SaveChangesAsync();

            string[] unt2 = new string[] { "Santa Mônica"
            ,"R. Érico Veríssimo"
            ,"1229"
            ,"Santa Mônica"
            ,"Belo Horizonte"
            ,"MG"};

            Address _address2 = new Address();
            _address.Street = unt2[1];
            _address.Number = unt2[2];
            _address.Neighborhood = unt2[3];
            _address.City = unt2[4];
            _address.State = unt2[5];

            _unit = new Unit();
            _unit.Name = unt2[0];
            _unit.Address = _address2;
            _unit.Rooms = Rooms(2);
            _unit.CheckingAccounts = CAccount();
            _listunit.Add(_unit);
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
        "professor0@professor0.com.br"
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
        "professor1@professor1.com.br"
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
        "professor2@professor2.com.br"
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
        "professor3@professor3.com.br"
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
        "professor4@professor4.com.br"
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
        "professor5@professor5.com.br"
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

            //---------------------------------------------------------------------------------------------//
            _contact = new Contact();
            string[] contact6 = new string[] { "311548-9575",
        "313569-8562",
        "nullo",
        "professor6@professor6.com.br"
        };
            _contact.CellPhone = contact6[0];
            _contact.HomePhone = contact6[1];
            //_contact.ComercialPhone = contact6[2];
            _contact.Email = contact6[3];
            _contact.instantMessage = InstantM();
            _contact.socialNetwork = SNetwork();
            _contactList.Add(_contact);
            // _context.Add(_contact);
            //await _context.SaveChangesAsync() > 0;

            //---------------------------------------------------------------------------------------------//
            _contact = new Contact();
            string[] contact7 = new string[] { "318548-4125",
        "316598-6523",
        "nullo",
        "professor7@professor7.com.br"
        };
            _contact.CellPhone = contact7[0];
            _contact.HomePhone = contact7[1];
            //_contact.ComercialPhone = contact7[2];
            _contact.Email = contact7[3];
            _contact.instantMessage = InstantM();
            _contact.socialNetwork = SNetwork();
            _contactList.Add(_contact);
            // _context.Add(_contact);
            //await _context.SaveChangesAsync() > 0;

            //---------------------------------------------------------------------------------------------//
            _contact = new Contact();
            string[] contact8 = new string[] { "315887-78-5658",
        "313344556622",
        "nullo",
        "professor8@professor8.com.br"
        };
            _contact.CellPhone = contact8[0];
            _contact.HomePhone = contact8[1];
            //_contact.ComercialPhone = contact8[2];
            _contact.Email = contact8[3];
            _contact.instantMessage = InstantM();
            _contact.socialNetwork = SNetwork();
            _contactList.Add(_contact);
            // _context.Add(_contact);
            //await _context.SaveChangesAsync() > 0;

            //---------------------------------------------------------------------------------------------//
            _contact = new Contact();
            string[] contact01 = new string[] { "315887-78-5658",
        "313344556622",
        "nullo",
        "Professor01@Aluno01.com.br"
        };
            _contact.CellPhone = contact01[0];
            _contact.HomePhone = contact01[1];
            //_contact.ComercialPhone = contact01[2];
            _contact.Email = contact01[3];
            _contact.instantMessage = InstantM();
            _contact.socialNetwork = SNetwork();
            _contactList.Add(_contact);
            // _context.Add(_contact);
            //await _context.SaveChangesAsync() > 0;

            //---------------------------------------------------------------------------------------------//
            _contact = new Contact();
            string[] contact02 = new string[] { "315887-78-5658",
        "313344556622",
        "nullo",
        "Aluno02@Aluno02.com.br"
        };
            _contact.CellPhone = contact02[0];
            _contact.HomePhone = contact02[1];
            //_contact.ComercialPhone = contact02[2];
            _contact.Email = contact02[3];
            _contact.instantMessage = InstantM();
            _contact.socialNetwork = SNetwork();
            _contactList.Add(_contact);
            // _context.Add(_contact);
            //await _context.SaveChangesAsync() > 0;

            //---------------------------------------------------------------------------------------------//
            _contact = new Contact();
            string[] contact03 = new string[] { "315887-78-5658",
        "313344556622",
        "nullo",
        "Aluno03@Aluno03.com.br"
        };
            _contact.CellPhone = contact03[0];
            _contact.HomePhone = contact03[1];
            //_contact.ComercialPhone = contact03[2];
            _contact.Email = contact03[3];
            _contact.instantMessage = InstantM();
            _contact.socialNetwork = SNetwork();
            _contactList.Add(_contact);
            // _context.Add(_contact);
            //await _context.SaveChangesAsync() > 0;

            //---------------------------------------------------------------------------------------------//
            _contact = new Contact();
            string[] contact04 = new string[] { "315887-78-5658",
        "313344556622",
        "nullo",
        "Aluno04@Aluno04.com.br"
        };
            _contact.CellPhone = contact04[0];
            _contact.HomePhone = contact04[1];
            //_contact.ComercialPhone = contact04[2];
            _contact.Email = contact04[3];
            _contact.instantMessage = InstantM();
            _contact.socialNetwork = SNetwork();
            _contactList.Add(_contact);
            // _context.Add(_contact);
            //await _context.SaveChangesAsync() > 0;

            //---------------------------------------------------------------------------------------------//
            _contact = new Contact();
            string[] contact05 = new string[] { "315887-78-5658",
        "313344556622",
        "nullo",
        "Aluno05@Aluno05.com.br"
        };
            _contact.CellPhone = contact05[0];
            _contact.HomePhone = contact05[1];
            //_contact.ComercialPhone = contact05[2];
            _contact.Email = contact05[3];
            _contact.instantMessage = InstantM();
            _contact.socialNetwork = SNetwork();
            _contactList.Add(_contact);
            // _context.Add(_contact);
            //await _context.SaveChangesAsync() > 0;

            //---------------------------------------------------------------------------------------------//
            _contact = new Contact();
            string[] contact06 = new string[] { "315887-78-5658",
        "313344556622",
        "nullo",
        "Aluno06@Aluno06.com.br"
        };
            _contact.CellPhone = contact06[0];
            _contact.HomePhone = contact06[1];
            //_contact.ComercialPhone = contact06[2];
            _contact.Email = contact06[3];
            _contact.instantMessage = InstantM();
            _contact.socialNetwork = SNetwork();
            _contactList.Add(_contact);
            // _context.Add(_contact);
            //await _context.SaveChangesAsync() > 0;

            //---------------------------------------------------------------------------------------------//
            _contact = new Contact();
            string[] contact07 = new string[] { "315887-78-5658",
        "313344556622",
        "nullo",
        "Aluno07@Aluno07.com.br"
        };
            _contact.CellPhone = contact07[0];
            _contact.HomePhone = contact07[1];
            //_contact.ComercialPhone = contact07[2];
            _contact.Email = contact07[3];
            _contact.instantMessage = InstantM();
            _contact.socialNetwork = SNetwork();
            _contactList.Add(_contact);
            // _context.Add(_contact);
            //await _context.SaveChangesAsync() > 0;

            //---------------------------------------------------------------------------------------------//
            _contact = new Contact();
            string[] contact08 = new string[] { "315887-78-5658",
        "313344556622",
        "nullo",
        "Aluno08@Aluno08.com.br"
        };
            _contact.CellPhone = contact08[0];
            _contact.HomePhone = contact08[1];
            //_contact.ComercialPhone = contact08[2];
            _contact.Email = contact08[3];
            _contact.instantMessage = InstantM();
            _contact.socialNetwork = SNetwork();
            _contactList.Add(_contact);
            // _context.Add(_contact);
            //await _context.SaveChangesAsync() > 0;

            return _contactList;



        }
        public string[] AddressBase(int addrArray, string entity)
        {
            if (entity.ToUpper().Contains("STUDENT"))
            {
                string[] sts0 = new string[]
                                          {"Rua do Aluno0", "000",
            "Bairro Aluno0","Cidade Aluno0", "Estado Aluno0","ComplementoALuno0"  };

                string[] sts1 = new string[]
                {"Rua do Aluno1", "111",
            "Bairro Aluno1","Cidade Aluno1", "Estado Aluno1","ComplementoALuno1"  };

                string[] sts2 = new string[]
                {"Rua do Aluno2", "222",
            "Bairro Aluno2","Cidade Aluno2", "Estado Aluno2","ComplementoALuno2"  };
                string[] sts3 = new string[]
               {"Rua do Aluno3", "333",
            "Bairro Aluno3","Cidade Aluno3", "Estado Aluno3","ComplementoALuno3"  };

                string[] sts4 = new string[]
                {"Rua do Aluno4", "444",
            "Bairro Aluno4","Cidade Aluno4", "Estado Aluno4","ComplementoALuno4"  };

                string[] sts5 = new string[]
                {"Rua do Aluno5", "555",
            "Bairro Aluno5","Cidade Aluno5", "Estado Aluno5","ComplementoALuno5"  };

                string[] sts6 = new string[]
                           {"Rua do Aluno6", "666",
            "Bairro Aluno6","Cidade Aluno6", "Estado Aluno6","ComplementoALuno6"  };

                string[] sts7 = new string[]
                {"Rua do Aluno7", "777",
            "Bairro Aluno7","Cidade Aluno7", "Estado Aluno7","ComplementoALuno7"  };

                string[] sts8 = new string[]
                {"Rua do Aluno8", "888",
            "Bairro Aluno8","Cidade Aluno8", "Estado Aluno8","ComplementoALuno8"  };

                switch (addrArray)
                {
                    case 0:
                        return sts0;
                    case 1:
                        return sts1;
                    case 2:
                        return sts2;
                    case 3:
                        return sts3;
                    case 4:
                        return sts4;
                    case 5:
                        return sts5;
                    case 6:
                        return sts6;
                    case 7:
                        return sts7;
                    case 8:
                        return sts8;
                }
            }
            else if (entity.ToUpper().Contains("TEACHER"))
            {
                string[] tch0 = new string[]
                {"Teacher0", "SobreNome Teacher0", "Rua do Teacher0", "000",
            "Bairro Teacher0","Cidade Teacher0", "Estado Teacher0","ComplementoTeacher0"  };

                string[] tch1 = new string[]
                {"Teacher1", "SobreNome Teacher1", "Rua do Teacher1", "111",
            "Bairro Teacher1","Cidade Teacher1", "Estado Teacher1","ComplementoTeacher1"  };

                string[] tch2 = new string[]
                {"Teacher2", "SobreNome Teacher2", "Rua do Teacher2", "222",
            "Bairro Teacher2","Cidade Teacher2", "Estado Teacher2","ComplementoTeacher2"  };
                ///////////////////////////////////////////////////////////////////////////////////////////////////
                string[] tch3 = new string[]
               {"Teacher3", "SobreNome Teacher3", "Rua do Teacher3", "333",
            "Bairro Teacher3","Cidade Teacher3", "Estado Teacher3","ComplementoTeacher3"  };

                string[] tch4 = new string[]
                {"Teacher4", "SobreNome Teacher4", "Rua do Teacher4", "444",
            "Bairro Teacher4","Cidade Teacher4", "Estado Teacher4","ComplementoTeacher4"  };

                string[] tch5 = new string[]
                {"Teacher5", "SobreNome Teacher5", "Rua do Teacher5", "555",
            "Bairro Teacher5","Cidade Teacher5", "Estado Teacher5","ComplementoTeacher5"  };

                string[] tch6 = new string[]
                           {"Teacher6", "SobreNome Teacher6", "Rua do Teacher6", "666",
            "Bairro Teacher6","Cidade Teacher6", "Estado Teacher6","ComplementoTeacher6"  };

                switch (addrArray)
                {
                    case 0:
                        return tch0;
                    case 1:
                        return tch1;
                    case 2:
                        return tch2;
                    case 3:
                        return tch3;
                    case 4:
                        return tch4;
                    case 5:
                        return tch5;
                    case 6:
                        return tch6;
                }


            }
            else if (entity.ToUpper().Contains("UNIT"))
            {
                string[] unt0 = new string[] { "Cidade Nova",
            "R. Prof. Costa Chiabi",
            "95",
            "Cidade Nova",
            "Belo Horizonte",
            "MG"};
                string[] unt1 = new string[] {  "Lordes"
            ,"R. Espírito Santo"
            ,"1481"
            ,"Lourdes"
            ,"Belo Horizonte"
            ,"MG"};
                string[] unt2 = new string[] { "Santa Mônica"
            ,"R. Érico Veríssimo"
            ,"1229"
            ,"Santa Mônica"
            ,"Belo Horizonte"
            ,"MG"};

                switch (addrArray)
                {
                    case 0:
                        return unt0;
                    case 1:
                        return unt1;
                    case 2:
                        return unt2;
                }

            }
            return null;
        }
        public List<Address> Addresses(string entity)
        {
            _listAddress = new List<Address>();

            if (entity.ToUpper().Contains("STUDENT"))
            {

                for (int n = 0; n < 9; n++)
                {
                    _address = new Address();
                    _address.Street = AddressBase(n, entity)[0];
                    _address.Number = AddressBase(n, entity)[1];
                    _address.Neighborhood = AddressBase(n, entity)[2];
                    _address.City = AddressBase(n, entity)[3];
                    _address.State = AddressBase(n, entity)[4];
                    _address.Complement = AddressBase(n, entity)[5];
                    _listAddress.Add(_address);
                }

                return _listAddress;
            }
            else if (entity.ToUpper().Contains("TEACHER"))
            {
                for (int n = 0; n < 6; n++)
                {
                    _address = new Address();
                    _address.Street = AddressBase(n, entity)[0];
                    _address.Number = AddressBase(n, entity)[1];
                    _address.Neighborhood = AddressBase(n, entity)[2];
                    _address.City = AddressBase(n, entity)[3];
                    _address.State = AddressBase(n, entity)[4];
                    _address.Complement = AddressBase(n, entity)[5];
                    _listAddress.Add(_address);
                }
                return _listAddress;
            }

            return null;
        }

        public List<Student> Student(int list)
        {
            _listStudent = new List<Student>();
            Address[] addr = Addresses("STUDENT").ToArray();


            string[] sts0 = new string[]
            {"Aluno0", "SobreNome Aluno0", "Rua do Aluno0", "000",
            "Bairro Aluno0","Cidade Aluno0", "Estado Aluno0","ComplementoALuno0"  };

            string[] sts1 = new string[]
            {"Aluno1", "SobreNome Aluno1", "Rua do Aluno1", "111",
            "Bairro Aluno1","Cidade Aluno1", "Estado Aluno1","ComplementoALuno1"  };

            string[] sts2 = new string[]
            {"Aluno2", "SobreNome Aluno2", "Rua do Aluno2", "222",
            "Bairro Aluno2","Cidade Aluno2", "Estado Aluno2","ComplementoALuno2"  };

            string[] sts3 = new string[]
           {"Aluno3", "SobreNome Aluno3", "Rua do Aluno3", "333",
            "Bairro Aluno3","Cidade Aluno3", "Estado Aluno3","ComplementoALuno3"  };

            string[] sts4 = new string[]
            {"Aluno4", "SobreNome Aluno4", "Rua do Aluno4", "444",
            "Bairro Aluno4","Cidade Aluno4", "Estado Aluno4","ComplementoALuno4"  };

            string[] sts5 = new string[]
            {"Aluno5", "SobreNome Aluno5", "Rua do Aluno5", "555",
            "Bairro Aluno5","Cidade Aluno5", "Estado Aluno5","ComplementoALuno5"  };

            string[] sts6 = new string[]
                       {"Aluno6", "SobreNome Aluno6", "Rua do Aluno6", "666",
            "Bairro Aluno6","Cidade Aluno6", "Estado Aluno6","ComplementoALuno6"  };

            string[] sts7 = new string[]
            {"Aluno7", "SobreNome Aluno7", "Rua do Aluno7", "777",
            "Bairro Aluno7","Cidade Aluno7", "Estado Aluno7","ComplementoALuno7"  };

            string[] sts8 = new string[]
            {"Aluno8", "SobreNome Aluno8", "Rua do Aluno8", "888",
            "Bairro Aluno8","Cidade Aluno8", "Estado Aluno8","ComplementoALuno8"  };


            Contact[] stus = Contact().ToArray();
            Discipline[] dis = Discipline().ToArray();

            List<Discipline> listDisciplinesStudent0 = new List<Discipline>();
            listDisciplinesStudent0.Add(dis[1]);


            _student = new Student();
            _student.Name = sts0[0];
            _student.LastName = sts0[1];
            //_student.Discipline = listDisciplinesStudent0;
            _student.Contact = stus[0];
            _student.Address = addr[0];
            _listStudent.Add(_student);
            //_context.Add(_student);
            //await _context.SaveChangesAsync();
            //
            List<Discipline> listDisciplinesStudent1 = new List<Discipline>();
            listDisciplinesStudent1.Add(dis[1]);
            _student = new Student();
            _student.Name = sts1[0];
            _student.LastName = sts1[1];
            //_student.Discipline = listDisciplinesStudent1;
            _student.Contact = stus[1];
            _student.Address = addr[1];
            _listStudent.Add(_student);
            //_context.Add(_student);
            //await _context.SaveChangesAsync();
            //
            List<Discipline> listDisciplinesStudent2 = new List<Discipline>();
            listDisciplinesStudent2.Add(dis[1]);
            _student = new Student();
            _student.Name = sts2[0];
            _student.LastName = sts2[1];
            //_student.Discipline = listDisciplinesStudent2;
            _student.Contact = stus[2];
            _student.Address = addr[2];
            _listStudent.Add(_student);
            //_context.Add(_student);
            //await _context.SaveChangesAsync();
            ///////////////////////////////////////////////////////////////
            List<Discipline> listDisciplinesStudent3 = new List<Discipline>();
            listDisciplinesStudent3.Add(dis[3]);
            _student = new Student();
            _student.Name = sts3[0];
            _student.LastName = sts3[1];
            //_student.Discipline = listDisciplinesStudent3;
            _student.Contact = stus[3];
            _student.Address = addr[3];
            _listStudent.Add(_student);
            //_context.Add(_student);
            //await _context.SaveChangesAsync();

            List<Discipline> listDisciplinesStudent4 = new List<Discipline>();
            listDisciplinesStudent4.Add(dis[3]);
            _student = new Student();
            _student.Name = sts4[0];
            _student.LastName = sts4[1];
            //_student.Discipline = listDisciplinesStudent4;
            _student.Contact = stus[4];
            _student.Address = addr[4];
            _listStudent.Add(_student);
            //_context.Add(_student);
            //await _context.SaveChangesAsync();

            List<Discipline> listDisciplinesStudent5 = new List<Discipline>();
            listDisciplinesStudent5.Add(dis[3]);
            _student = new Student();
            _student.Name = sts5[0];
            _student.LastName = sts5[1];
            //_student.Discipline = listDisciplinesStudent5;
            _student.Contact = stus[5];
            _student.Address = addr[5];
            _listStudent.Add(_student);
            //_context.Add(_student);
            //await _context.SaveChangesAsync();


            List<Discipline> listDisciplinesStudent6 = new List<Discipline>();
            listDisciplinesStudent6.Add(dis[5]);
            _student = new Student();
            _student.Name = sts6[0];
            _student.LastName = sts6[1];
            //_student.Discipline = listDisciplinesStudent6;
            _student.Contact = stus[6];
            _student.Address = addr[6];
            _listStudent.Add(_student);
            //_context.Add(_student);
            //await _context.SaveChangesAsync();

            List<Discipline> listDisciplinesStudent7 = new List<Discipline>();
            listDisciplinesStudent6.Add(dis[5]);
            _student = new Student();
            _student.Name = sts2[0];
            _student.LastName = sts2[1];
            //_student.Discipline = listDisciplinesStudent7;
            _student.Contact = stus[7];
            _student.Address = addr[7];
            _listStudent.Add(_student);
            //_context.Add(_student);
            //await _context.SaveChangesAsync();

            List<Discipline> listDisciplinesStudent8 = new List<Discipline>();
            listDisciplinesStudent6.Add(dis[5]);
            _student = new Student();
            _student.Name = sts8[0];
            _student.LastName = sts8[1];
            //_student.Discipline = listDisciplinesStudent8;
            _student.Contact = stus[8];
            _student.Address = addr[8];
            _listStudent.Add(_student);
            //_context.Add(_student);
            //await _context.SaveChangesAsync();


            ListStudent0 = _listStudent.Take(9).ToList();
            ListStudent2 = _listStudent.Skip(9).Take(9).ToList();
            ListStudent2 = _listStudent.Skip(18).Take(19).ToList();

            switch (list)
            {
                case 0:
                    return ListStudent0;
                case 1:
                    return ListStudent1;
                case 2:
                    return ListStudent1;
            }

            return _listStudent;
        }

        public List<Teacher> Teacher()
        {
            _ListTeachers = new List<Teacher>();
            Address[] addr = Addresses("TEACHER").ToArray();

            Contact[] contacts = Contact().ToArray();
            Discipline[] dis = Discipline().ToArray();

            string[] tch0 = new string[]
            {"Professor0", "SobreNome Professor0", "Rua do Professor0", "000",
            "Bairro Professor0","Cidade Professor0", "Estado Professor0","ComplementoProfessor0"  };

            string[] tch1 = new string[]
            {"Professor1", "SobreNome Professor1", "Rua do Professor1", "111",
            "Bairro Professor1","Cidade Professor1", "Estado Professor1","ComplementoProfessor1"  };

            string[] tch2 = new string[]
            {"Professor2", "SobreNome Professor2", "Rua do Professor2", "222",
            "Bairro Professor2","Cidade Professor2", "Estado Professor2","ComplementoProfessor2"  };

            string[] tch3 = new string[]
           {"Professor3", "SobreNome Professor3", "Rua do Professor3", "333",
            "Bairro Professor3","Cidade Professor3", "Estado Professor3","ComplementoProfessor3"  };

            string[] tch4 = new string[]
            {"Professor4", "SobreNome Professor4", "Rua do Professor4", "444",
            "Bairro Professor4","Cidade Professor4", "Estado Professor4","ComplementoProfessor4"  };

            string[] tch5 = new string[]
            {"Professor5", "SobreNome Professor5", "Rua do Professor5", "555",
            "Bairro Professor5","Cidade Professor5", "Estado Professor5","ComplementoProfessor5"  };

            string[] tch6 = new string[]
                       {"Professor6", "SobreNome Professor6", "Rua do Professor6", "666",
            "Bairro Professor6","Cidade Professor6", "Estado Professor6","ComplementoProfessor6"  };

            string[] tch7 = new string[]
            {"Professor7", "SobreNome Professor7", "Rua do Professor7", "777",
            "Bairro Professor7","Cidade Professor7", "Estado Professor7","ComplementoProfessor7"  };

            string[] tch8 = new string[]
            {"Professor8", "SobreNome Professor8", "Rua do Professor8", "888",
            "Bairro Professor8","Cidade Professor8", "Estado Professor8","ComplementoProfessor8"  };

            try
            {

                List<Discipline> listDisciplinesTeacher0 = new List<Discipline>();

                listDisciplinesTeacher0.Add(dis[1]);

                _teachers = new Teacher();
                _teachers.Name = tch0[0];
                _teachers.LastName = tch0[1];
                _teachers.Contact = contacts[3];
                //_teachers.Discipline = listDisciplinesTeacher0;
                _teachers.Address = addr[0];
                _ListTeachers.Add(_teachers);
                //_context.Add(_teachers);
                // await _context.SaveChangesAsync();

                List<Discipline> listDisciplinesTeacher1 = new List<Discipline>();
                listDisciplinesTeacher1.Add(dis[3]);
                _teachers = new Teacher();
                _teachers.Name = tch0[0];
                _teachers.LastName = tch0[1];
                _teachers.Contact = contacts[4];
                //_teachers.Discipline = listDisciplinesTeacher1;
                _teachers.Address = addr[1];
                _ListTeachers.Add(_teachers);
                //_context.Add(_teachers);
                //await _context.SaveChangesAsync();

                List<Discipline> listDisciplinesTeacher2 = new List<Discipline>();
                listDisciplinesTeacher2.Add(dis[5]);
                _teachers = new Teacher();
                _teachers.Name = tch0[0];
                _teachers.LastName = tch0[1];
                _teachers.Contact = contacts[5];
                //_teachers.Discipline = listDisciplinesTeacher2;
                _teachers.Address = addr[2];
                _ListTeachers.Add(_teachers);
                //  _context.Add(_teachers);
                // return await _context.SaveChangesAsync() > 0;

                List<Discipline> listDisciplinesTeacher3 = new List<Discipline>();
                listDisciplinesTeacher3.Add(dis[5]);
                _teachers = new Teacher();
                _teachers.Name = tch0[0];
                _teachers.LastName = tch0[1];
                _teachers.Contact = contacts[5];
                //_teachers.Discipline = listDisciplinesTeacher3;
                _teachers.Address = addr[3];
                _ListTeachers.Add(_teachers);
                //  _context.Add(_teachers);
                // await _context.SaveChangesAsync() > 0;

                List<Discipline> listDisciplinesTeacher4 = new List<Discipline>();
                listDisciplinesTeacher4.Add(dis[5]);
                _teachers = new Teacher();
                _teachers.Name = tch0[0];
                _teachers.LastName = tch0[1];
                _teachers.Contact = contacts[5];
                //_teachers.Discipline = listDisciplinesTeacher4;
                _teachers.Address = addr[4];
                _ListTeachers.Add(_teachers);
                //  _context.Add(_teachers);
                // await _context.SaveChangesAsync() > 0;
                List<Discipline> listDisciplinesTeacher5 = new List<Discipline>();
                listDisciplinesTeacher5.Add(dis[5]);
                _teachers = new Teacher();
                _teachers.Name = tch0[0];
                _teachers.LastName = tch0[1];
                _teachers.Contact = contacts[5];
                //_teachers.Discipline = listDisciplinesTeacher5;
                _teachers.Address = addr[5];
                //  _context.Add(_teachers);
                // return await _context.SaveChangesAsync() > 0;
                _ListTeachers.Add(_teachers);
                return _ListTeachers;
            }
            catch (System.Exception)
            {

            }
            return _ListTeachers;
        }

        public async Task<bool> Classes()
        {

            Teacher[] teacher = Teacher().ToArray();

            Discipline[] disp = Discipline().ToArray();
            Room[] rms = Rooms(0).ToArray();
            Unit[] unt = Unit().ToArray();

            /////////////////////////////////////////////////////
            _classes = new Class();
            _classes.Teacher = teacher[0];
            //_classes.TeacherId = 1;
            _classes.Start = DateTime.Now;
            _classes.End = DateTime.Now;
            _classes.Discipline = disp[1];
            _classes.Students = Student(0);
            _classes.Unit = unt[0];
            _classes.Room = Rooms(0).ToArray()[0];
            _context.Add(_classes);
            /////////////////////////////////////////////////////
            _classes = new Class();

            _classes.Teacher = teacher[1];
            //  _classes.TeacherId = 2;
            _classes.Start = DateTime.Now;
            _classes.End = DateTime.Now;
            _classes.Discipline = disp[3];
            _classes.Students = Student(1);
            _classes.Unit = unt[1];
            _classes.Room = Rooms(1).ToArray()[1];
            _context.Add(_classes);
            /////////////////////////////////////////////////////
            _classes = new Class();
            _classes.Teacher = teacher[2];
            //   _classes.TeacherId = 3;
            _classes.Start = DateTime.Now;
            _classes.End = DateTime.Now;
            _classes.Discipline = disp[5];
            _classes.Students = Student(3);
            _classes.Unit = unt[2];
            _classes.Room = Rooms(2).ToArray()[2];
            _context.Add(_classes);
            ////////////////////////////////////////////////////////////
            /* _classes = new Class();
             _classes.Teacher = teacher[3];
             // _classes.TeacherId = 3;
             _classes.Start = DateTime.Now;
             _classes.End = DateTime.Now;
             _classes.Discipline = disp[3];
             _classes.Students = Student();
             _classes.Unit = unt[1];
             _classes.Room = Rooms(2).ToArray()[3];
             _context.Add(_classes);

 */

            return await _context.SaveChangesAsync() > 0;
        }


    }
}
