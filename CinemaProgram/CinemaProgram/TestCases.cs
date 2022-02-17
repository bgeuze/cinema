using System;
using System.Linq;


namespace CinemaProgram
{
    internal class TestCases
    {
        internal static void Start()
        {
            int total = 2;
            int successfull = 0;
            bool cinemaTest = TestCinemaCreation();
            Console.WriteLine("-Create & Get Cinema Test- succesful: " + cinemaTest);
            if (cinemaTest)
            {
                successfull++;
                String whiteSpace = "   ";

                Console.WriteLine(whiteSpace + "-Add & Get Bar From Cinema Test- succesful: " + TestAddBar());
                if (TestAddBar())
                {
                    successfull++;
                }
            }

            Console.WriteLine("Total test successfully completed: " + successfull +"/" +total);

        }

        private static bool TestCinemaCreation()
        {
            Boolean suc6 = false;
            Hall hall = new Hall();
            Hall[] halls = new Hall[] { };
            halls.Append(hall);
            Interface.createCinema("Name", halls);
            if (Interface.getCinema("Name") != null)
            {
                return true;
            }
            else
                return false;
        }

        private static bool TestAddBar()
        {
            Cinema cinema = Interface.getCinema("Name");
            cinema.addBar();
            if (cinema.getBar() != null)
            {
                return true;
            }
            else return false;
        }
    }
}
