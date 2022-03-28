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
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("#CINEMA TESTS");
            Console.WriteLine("-Create & Get Cinema Test- succesful: " + cinemaTest);
            if (cinemaTest)
            {
                Cinema cinema = interfaceObject.getCinema("Name");
                successfull++;
                String whiteSpace = "   ";
                if (TestAddBar())
                {
                    successfull++;
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else { Console.ForegroundColor = ConsoleColor.Red; }
                Console.WriteLine(whiteSpace + "-Add & Get Bar From Cinema Test- succesful: " + TestAddBar());
                if (TestMovies())
                {
                    successfull++;

                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else { Console.ForegroundColor = ConsoleColor.Red; }
                Console.WriteLine(whiteSpace + "Add and view Movie(s) From a cinema: " + TestMovies());
                if (TestAddHall())
                {
                    successfull++;

                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else { Console.ForegroundColor = ConsoleColor.Red; }
                Console.WriteLine(whiteSpace + "Add a hall to a existing cinema: " + TestAddHall());
               
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

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("-- 11 other test we're skipped because of fail!");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("#USER TESTS");
            if (TestUserCreationAndFetching()) { successfull++; Console.ForegroundColor = ConsoleColor.Green; }
                else { Console.ForegroundColor = ConsoleColor.Red; }
            Console.WriteLine("-Add & load users: " + TestUserCreationAndFetching());
            if (TestUserRoles()) { successfull++; Console.ForegroundColor = ConsoleColor.Green; }
                else { Console.ForegroundColor = ConsoleColor.Red; }
            Console.WriteLine("-Test user roles: " + TestUserRoles());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-Test remove user: " + " False");

            Console.WriteLine("-Test user role change: " + " False");

            Console.WriteLine("-Test Pricing user: " + " False");

            Console.WriteLine("-Test login without user.json: " + " False");
            //Test role change after creation
            //Test Pricing Users
            //Test login with no user.json
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Total test successfully completed: " + successfull + "/" + total + " or: " + Math.Round(successfull / total * 100, 2) + "%");

        }

        private static bool TestUserRoles()
        {
            if (UserJsonHandler.GetUserRole("TestUser") != "Admin")
            { return true; }
            return false;
        }

        private static bool TestUserCreationAndFetching()
        {
            //JsonHandler jsonHandler = new JsonHandler();
<<<<<<< Updated upstream
            UserJsonHandler.SaveUser("TestUser", "TestPassword");
            return UserJsonHandler.FindUser("TestUser", "TestPassword");
=======
            JsonHandler.SaveUser("TestUser", "TestPassword", "43");
            return JsonHandler.FindUser("TestUser", "TestPassword");
>>>>>>> Stashed changes
            //return false;
        }

        private static bool TestAddHall()
        {
            interfaceObject.getCinema("Name").addHall(new Hall(2, new Seat[2][]));
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
            Hall hall = new Hall(2, new Seat[2][]);
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
