using System.Collections;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Reflection;

namespace CinemaProgram
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //string json = JsonSerializer.Serialize(_data);
            //Creates a "Relative Path" that goes 3 folders up from the current/starting directory
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"../../../Hello\\file.json");
            //Directory.CreateDirectory(@"../../../Hello");   //Creates the directory if it doesnt exist
            //File.AppendAllText(path, "hello");  //Appends the text hello to said file
            //Console.WriteLine("Teset");
            await ConsoleProgram.LoginRegisterAsync();
            //TestCases.Start();

            //ArrayList halls = new ArrayList();
            //Seat[][] seats = new Seat[2][];
            //seats[0] = new Seat[2] { new Seat(), new Seat() };
            //seats[1] = new Seat[2] { new Seat(), new Seat() };

            //Hall hall = new Hall(1, seats);
            //halls.Add(hall);

            //Hall hall2 = new Hall(2, seats);
            //halls.Add(hall2);

            //Interface test = new Interface();
            //test.newCinema("Bios 1", halls);

        }
    }
}
