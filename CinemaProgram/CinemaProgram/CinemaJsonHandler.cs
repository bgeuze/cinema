using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;

namespace CinemaProgram
{
    internal class CinemaJsonHandler
    {
        public static bool NewCinema(string name, ArrayList halls)
        {
            var filePath = "cinema1.json";

            //Creates a "Relative Path" that goes 3 folders up from the current/starting directory
            filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"./Data\\cinema1.json");
            Directory.CreateDirectory(@"./Data");   //Creates the directory if it doesnt exist
            File.AppendAllText(filePath, ""); //Opens the file and writes the content to it creates it if it doesnt exsist
            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var cinemaList = JsonConvert.DeserializeObject<List<Cinema>>(jsonData) ?? new List<Cinema>();

            //add new user to the list
            cinemaList.Add(new Cinema(name, halls));
            jsonData = JsonConvert.SerializeObject(cinemaList);
            File.WriteAllText(filePath, jsonData);

            return true;
        }
    }
}
