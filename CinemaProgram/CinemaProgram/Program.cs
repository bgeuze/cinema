using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTables;
using Newtonsoft.Json;

namespace CinemaProgram
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
       
            //user login & registration
            await ConsoleProgram.LoginRegisterAsync();

            //TestCases.Start();
        }
    }
}
