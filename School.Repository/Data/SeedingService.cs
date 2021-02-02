using System.Collections.Generic;
using System.Threading.Tasks;
using School.Domain.Entities;

namespace School.Repository.Data
{
    public class SeedingService
    {
        private readonly SchoolDbContext _context;
        private Seeding _seeding { get; set; }
        public SeedingService(SchoolDbContext context)
        {
            _context = context;

        }

        public async Task<bool> Seed()
        {
            _seeding = new Seeding(_context);
            _seeding.Student();
            return await _seeding.Classes();
        }
        //  List<Room> rooms = new List<Room>();

        /*        Room r1 = new Room();
                    r1.Identifier = "Sala de Inglês";
                    r1.Description = "Multi Idiomas aos sábados";

                    Room r2 = new Room();
                    r2.Identifier = "13";
                    r2.Description = "Somente aulas de italiano";

                    Room r3 = new Room();
                    r3.Identifier = "Francês";
                    r3.Description = "";


                    Room r4 = new Room();
                    r4.Identifier = "Sala de Inglês";
                    r4.Description = "Multi Idiomas aos sábados";

                    Room r5 = new Room();
                    r5.Identifier = "13";
                    r5.Description = "Somente aulas de italiano";

                    Room r6 = new Room();
                    r6.Identifier = "Francês";
                    r6.Description = "";


                    Room r7 = new Room();
                    r4.Identifier = "Sala de Inglês";
                    r4.Description = "Multi Idiomas aos sábados";

                    Room r8 = new Room();
                    r5.Identifier = "13";
                    r5.Description = "Somente aulas de italiano";

                    Room r9 = new Room();
                    r6.Identifier = "Francês";
                    r6.Description = "";
        //////////
                    //   rooms.Add(r1);
                    //   rooms.Add(r2);
                    //   rooms.Add(r3);
                    CheckingAccount cc1 = new CheckingAccount();
                    cc1.Bank = "Cef";
                    cc1.Agency = 2345;
                    cc1.Account = 23431;
                    cc1.Status = "OK";

                    List<UnitCheckingAccount> Lcc1 = new List<UnitCheckingAccount>();
                    UnitCheckingAccount UCAccount = new UnitCheckingAccount();
                    UCAccount.CheckingAccount = cc1;
                    Lcc1.Add(UCAccount);


                    CheckingAccount cc2 = new CheckingAccount();
                    cc2.Bank = "Itau";
                    cc2.Agency = 4785;
                    cc2.Account = 32546;
                    cc2.Status = "OK";


                    List<UnitCheckingAccount> Lcc2 = new List<UnitCheckingAccount>();
                    UnitCheckingAccount UCAccount2 = new UnitCheckingAccount();
                    UCAccount2.CheckingAccount = cc2;
                    Lcc2.Add(UCAccount2);


                    List<CheckingAccount> Lcc3 = new List<CheckingAccount>();
                    CheckingAccount cc3 = new CheckingAccount();
                    cc2.Bank = "Itau";
                    cc2.Agency = 4785;
                    cc2.Account = 32546;
                    cc2.Status = "OK";
                    Lcc3.Add(cc3);



                    List<UnitRoom> LunitRoom1 = new List<UnitRoom>();
                    UnitRoom unitRoom1 = new UnitRoom();
                    unitRoom1.Room = r1;

                    UnitRoom unitRoom2 = new UnitRoom();
                    unitRoom2.Room = r2;

                    UnitRoom unitRoom3 = new UnitRoom();
                    unitRoom3.Room = r3;
                    LunitRoom1.Add(unitRoom1);
                    LunitRoom1.Add(unitRoom2);
                    LunitRoom1.Add(unitRoom3);

                    Unit u1 = new Unit();
                    u1.Name = "Cidade Nova";
                    u1.Street = "R. Prof. Costa Chiabi";
                    u1.Number = "95";
                    u1.Neighborhood = "Cidade Nova";
                    u1.City = "Belo Horizonte";
                    u1.State = "MG";
                    u1.UnitRoom = LunitRoom1;
                    u1.UnitCAccount = Lcc1;


                    List<UnitRoom> LunitRoom2 = new List<UnitRoom>();
                    UnitRoom unitRoom4 = new UnitRoom();
                    unitRoom4.Room = r4;

                    UnitRoom unitRoom5 = new UnitRoom();
                    unitRoom5.Room = r5;

                    UnitRoom unitRoom6 = new UnitRoom();
                    unitRoom6.Room = r6;


                    LunitRoom2.Add(unitRoom4);
                    LunitRoom2.Add(unitRoom5);
                    LunitRoom2.Add(unitRoom6);


                    Unit u2 = new Unit();
                    u2.Name = "Lordes";
                    u2.Street = "R. Espírito Santo";
                    u2.Number = "1481";
                    u2.Neighborhood = "Lourdes";
                    u2.City = "Belo Horizonte";
                    u2.State = "MG";
                    u2.UnitRoom = LunitRoom2;



                    List<UnitRoom> LunitRoom3 = new List<UnitRoom>();
                    UnitRoom unitRoom7 = new UnitRoom();
                    unitRoom7.Room = r7;

                    UnitRoom unitRoom8 = new UnitRoom();
                    unitRoom8.Room = r8;

                    UnitRoom unitRoom9 = new UnitRoom();
                    unitRoom9.Room = r9;


                    LunitRoom2.Add(unitRoom4);
                    LunitRoom2.Add(unitRoom5);
                    LunitRoom2.Add(unitRoom6);



                    Unit u3 = new Unit();
                    u3.Name = "Santa Mônica";
                    u3.Street = "R. Érico Veríssimo";
                    u3.Number = "1229";
                    u3.Neighborhood = "Santa Mônica";
                    u3.City = "Belo Horizonte";
                    u3.State = "MG";
                    u3.UnitRoom = LunitRoom3;


                    List<DisciplineStudent> DisciplineStudent1 = new List<DisciplineStudent>();


                    //contains 9
                    List<DisciplineStudent> DisciplineStudent2 = new List<DisciplineStudent>();

                    List<DisciplineTeacher> DisciplineTeacher1 = new List<DisciplineTeacher>();


                    Discipline d1 = new Discipline();
                    d1.Language = "Alemão";
                    Discipline d2 = new Discipline();
                    d2.Language = "Árabe";
                    Discipline d3 = new Discipline();
                    d3.Language = "Chinês";
                    Discipline d4 = new Discipline();
                    d4.Language = "Espanhol";
                    Discipline d5 = new Discipline();
                    d5.Language = "Francês";
                    Discipline d6 = new Discipline();
                    d6.Language = "Inglês";
                    Discipline d7 = new Discipline();
                    d7.Language = "Italiano";
                    Discipline d8 = new Discipline();
                    d8.Language = "Japonês";
                    Discipline d9 = new Discipline();
                    d9.Language = "Portuês";




                    List<InstantMessage> Lim1 = new List<InstantMessage>();
                    InstantMessage im1 = new InstantMessage();
                    im1.Name = "WhatsApp";
                    im1.UniqueIdentifier = "999999999999";
                    Lim1.Add(im1);

                    List<InstantMessage> Lim2 = new List<InstantMessage>();
                    InstantMessage im2 = new InstantMessage();
                    im2.Name = "Skype";
                    Lim2.Add(im2);


                    List<InstantMessage> Lim3 = new List<InstantMessage>();
                    InstantMessage im3 = new InstantMessage();
                    im3.Name = "Telegram";
                    Lim3.Add(im3);

                    List<SocialNetwork> Lsc1 = new List<SocialNetwork>();
                    SocialNetwork sc1 = new SocialNetwork();
                    sc1.Name = "Facebook";
                    sc1.URL = "urlfacebook";
                    Lsc1.Add(sc1);

                    List<SocialNetwork> Lsc2 = new List<SocialNetwork>();
                    SocialNetwork sc2 = new SocialNetwork();
                    sc2.Name = "Instagram";
                    sc2.URL = "url url";
                    Lsc2.Add(sc2);

                    List<SocialNetwork> Lsc3 = new List<SocialNetwork>();
                    SocialNetwork sc3 = new SocialNetwork();
                    sc3.Name = "Twiter";
                    Lsc3.Add(sc3);

                    //Marcus Student
                    Contact c1 = new Contact();
                    c1.CellPhone = "31988598734";
                    c1.ComercialPhone = "33333333333";
                    c1.Email = "marcus@marcus";
                    c1.instantMessage = Lim1;
                    c1.socialNetwork = Lsc1;

                    //Mestre Professor
                    Contact c2 = new Contact();
                    c2.CellPhone = "319999999";
                    c2.ComercialPhone = "6666666666";
                    c2.Email = "prof@prof";
                    c2.instantMessage = Lim2;
                    c2.socialNetwork = Lsc2;


                    //lais Student
                    Contact c3 = new Contact();
                    c3.CellPhone = "31988598734";
                    c3.ComercialPhone = "33333333333";
                    c3.Email = "marcus@marcus";
                    c3.instantMessage = Lim3;
                    c3.socialNetwork = Lsc3;


                    Student s1 = new Student();
                    s1.Name = "Marcus";
                    s1.LastName = "Dias";
                    s1.Contact = c1;
                    s1.Street = "Arcos";
                    s1.Number = "217";
                    s1.Neighborhood = "Vera Cruz";
                    s1.City = "Belo Horizonte";
                    s1.State = "MG";
                    s1.Discipline = DisciplineStudent1;


                    DisciplineStudent DStudent1 = new DisciplineStudent();
                    //alemao
                    DStudent1.Discipline = d1;
                    DStudent1.Student = s1;

                    DisciplineStudent DStudent11 = new DisciplineStudent();
                    //Arabe
                    DStudent11.Discipline = d2;
                    DStudent11.Student = s1;

                    DisciplineStudent1.Add(DStudent1);
                    DisciplineStudent1.Add(DStudent11);

                    Student s2 = new Student();
                    s2.Name = "Lais";
                    s2.LastName = "Cunha";
                    s2.Contact = c3;
                    s2.Street = "alagados";
                    s2.Number = "278";
                    s2.Neighborhood = "Mangabeiras";
                    s2.City = "Belo Horizonte";
                    s2.State = "MG";
                    s2.Discipline = DisciplineStudent2;

                    DisciplineStudent DStudent2 = new DisciplineStudent();
                    //Arabe
                    DStudent2.Discipline = d9;
                    DStudent2.Student = s2;
                    DisciplineStudent2.Add(DStudent2);


                    Teacher t1 = new Teacher();
                    t1.Name = "Ramalho";
                    t1.LastName = "";
                    t1.Contact = c2;
                    t1.Street = "adf";
                    t1.Number = "54";
                    t1.Neighborhood = "barreiro";
                    t1.City = "Belo Horizonte";
                    t1.State = "MG";
                    t1.Discipline = DisciplineTeacher1;


                    DisciplineTeacher DTeacher1 = new DisciplineTeacher();
                    DTeacher1.Discipline = d5;
                    DTeacher1.Teacher = t1;

                    DisciplineTeacher1.Add(DTeacher1);


                    List<Room> LisRoom = new List<Room>();
                    Room room1 = new Room();
                    room1.Identifier = "Alemão";
                    Room room2 = new Room();
                    room2.Identifier = "Árabe";
                    Room room3 = new Room();
                    room3.Identifier = "Chinês";
                    Room room4 = new Room();
                    room4.Identifier = "Espanhol";
                    Room room5 = new Room();
                    room5.Identifier = "Francês";
                    Room room6 = new Room();
                    room6.Identifier = "Inglês";
                    Room room7 = new Room();
                    room7.Identifier = "Italiano";
                    Room room8 = new Room();
                    room8.Identifier = "Japonês";
                    Room room9 = new Room();
                    room9.Identifier = "Portuês";

                    LisRoom.Add(room1);
                    LisRoom.Add(room2);
                    LisRoom.Add(room3);
                    LisRoom.Add(room4);
                    LisRoom.Add(room5);
                    LisRoom.Add(room6);
                    LisRoom.Add(room7);
                    LisRoom.Add(room8);
                    LisRoom.Add(room9);



                    // Teacher student
                    _context.Add(t1);
                    _context.Add(s1);
                    _context.Add(s2);
                    _context.Add(cc1);
                    _context.Add(cc2);
                    _context.AddRange(LisRoom);



                    return _context.SaveChanges() > 1;
                }*/
    }
}
