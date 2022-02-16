using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProgram
{
    internal class ConsoleProgram
    {
        private static string ant;

        public static void LoginRegister()
        {
            //Keuze om in te loggen of om aan te melden.
            Console.WriteLine("Wilt u inloggen of aanmelden?");
            ant = Console.ReadLine();
            
            while(ant != "inloggen" && ant != "aanmelden")
            {
                System.Console.WriteLine("Invoer incorrect, wilt u inloggen of aanmelden?");
                ant = System.Console.ReadLine();
            }
            if(ant == "inloggen")
            {
                Console.Clear();
                Console.WriteLine("Wat is uw gebruikersnaam?");
                string username = Console.ReadLine();
                Console.WriteLine("Wat is uw wachtwoord?");
                string password = Console.ReadLine();

                while (Interface.Login(username,password) != true)
                {
                    Console.WriteLine("Inloggen gefaald, probeer het opnieuw.");
                    Console.WriteLine("Wat is uw gebruikersnaam?");
                    username = Console.ReadLine();
                    Console.WriteLine("Wat is uw wachtwoord?");
                    password = Console.ReadLine();
                }

                HomeScreen();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Voer een gebruikersnaam in.");
                string username = Console.ReadLine();
                Console.WriteLine("Voer een wachtwoord in.");
                string password = Console.ReadLine();

                while (Interface.Register(username, password) != true)
                {
                    Console.WriteLine("Registreren gefaald, probeer het opnieuw.");
                    Console.WriteLine("Voer een gebruikersnaam in.");
                    username = Console.ReadLine();
                    Console.WriteLine("Voer een wachtwoord in.");
                    password = Console.ReadLine();
                }

                HomeScreen();
            }


        }
        public static void HomeScreen()
        {
            Console.Clear();
        }
            
    }
}
