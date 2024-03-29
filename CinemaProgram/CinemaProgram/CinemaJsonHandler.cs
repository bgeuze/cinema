﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace CinemaProgram
{
    internal class CinemaJsonHandler
    {
        public static bool NewCinema(string name, Hall[] halls)
        {
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"./cinema1.json");
            File.AppendAllText(filePath, "");

            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var cinemaList = JsonConvert.DeserializeObject<List<Cinema>>(jsonData) ?? new List<Cinema>();

            //add new user to the list
            cinemaList.Add(new Cinema(name));
            jsonData = JsonConvert.SerializeObject(cinemaList);
            File.WriteAllText(filePath, jsonData);

            return true;
        }
    }
}
