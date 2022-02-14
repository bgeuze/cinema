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
            System.Console.WriteLine("Wilt u inloggen of aanmelden?");
            ant = System.Console.ReadLine();
            
            while(ant != "inloggen" && ant != "aanmelden")
            {
                System.Console.WriteLine("Invoer incorrect, wilt u inloggen of aanmelden?");
                ant = System.Console.ReadLine();
            }
            if(ant == "inloggen")
            {

                System.Console.Clear();
                System.Console.WriteLine("Wat is uw gebruikersnaam?");
                string username = System.Console.ReadLine();
                System.Console.WriteLine("Wat is uw wachtwoord?");
                string password = System.Console.ReadLine();
                while (Interface.login(username,password) != true)
                {
                    System.Console.WriteLine("Inlog gefaald, probeer het opnieuw.");
                    System.Console.WriteLine("Wat is uw gebruikersnaam?");
                    username = System.Console.ReadLine();
                    System.Console.WriteLine("Wat is uw wachtwoord?");
                    password = System.Console.ReadLine();
                }
                
                homescreen();
                
            }
            else
            {
                
            }


        }
        public static void homescreen()
        {
            System.Console.Clear();
            
           
        }
            
    }
}
