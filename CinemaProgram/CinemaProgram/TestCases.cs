using System;
using System.Linq;
using System.Collections;



namespace CinemaProgram
{
    internal class TestCases
    {

        private static Interface interfaceObject = new Interface();
        internal static void Start()
        {
            double total = 18;
            double successfull = 0;
            bool cinemaTest = TestCinemaCreation();
            Console.WriteLine("#CINEMA TESTS");
            Console.WriteLine("-Create & Get Cinema Test- succesful: " + cinemaTest);
            if (cinemaTest)
            {
                Cinema cinema = interfaceObject.getCinema("Name");
                successfull++;
                String whiteSpace = "   ";

                Console.WriteLine(whiteSpace + "-Add & Get Bar From Cinema Test- succesful: " + TestAddBar());
                if (TestAddBar())
                {
                    successfull++;
                }
                Console.WriteLine(whiteSpace + "Add and view Movie(s) From a cinema: " + TestMovies());
                if (TestMovies())
                {
                    successfull++;
                }
                Console.WriteLine(whiteSpace + "Add a hall to a existing cinema: " + TestAddHall());
                if (TestAddHall())
                {
                    successfull++;
                }
                //Test seat pricing
                //test seat choosing
                //test canceling order 
                //Test seating bar
                //Test schedule adding movie
                //test schedule removing movie
                //test schedule getting schedule and movie
                //test buying tickets

            }
            else
            {
                Console.WriteLine("-- 11 other test we're skipped because of fail!");
            }
            Console.WriteLine("#USER TESTS");
            Console.WriteLine("-Add & load users: " + TestUserCreationAndFetching());
            Console.WriteLine("-Test user roles: " + TestUserRoles());
            //Test remove user
            //Test role change after creation
            //Test Pricing Users
            //Test login with no user.json
            Console.WriteLine("Total test successfully completed: " + successfull + "/" + total + " or: " + Math.Round(successfull / total * 100, 2) + "%");

        }

        private static bool TestUserRoles()
        {
            return false;
        }

        private static bool TestUserCreationAndFetching()
        {
            //JsonHandler jsonHandler = new JsonHandler();
            JsonHandler.SaveUser("TestUser", "TestPassword");
            return JsonHandler.FindUser("TestUser", "TestPassword");
            //return false;
        }

        private static bool TestAddHall()
        {
            interfaceObject.getCinema("Name").addHall(new Hall(2, new Seat()));
            if (interfaceObject.getCinema("Name").test == "CinemaProgram.Hall") { return true; }
            return false;
        }

        private static bool TestMovies()
        {
            Cinema cinema = interfaceObject.getCinema("Name");
            return false;
        }

        private static bool TestCinemaCreation()
        {
            Hall hall = new Hall(2, new Seat());
            ArrayList halls = new ArrayList();
            halls.Add(hall);
            interfaceObject.createCinema(new Cinema("CinemaName", halls));
            if (interfaceObject.getCinema("CinemaName") != null)
            {
                return true;
            }
            else
                Console.WriteLine(interfaceObject.getCinema("CinemaName"));
            return false;
        }

        private static bool TestAddBar()
        {
            Cinema cinema = interfaceObject.getCinema("Name");
            cinema.addBar(new Bar());
            if (cinema.getBar() != null)
            {
                return true;
            }
            else return false;
        }
    }
}
