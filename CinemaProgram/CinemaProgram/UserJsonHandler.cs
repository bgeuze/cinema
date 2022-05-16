﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleTables;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CinemaProgram
{
    public class UserJsonHandler
    {
        public static bool SaveUser(string username, string password, string age)
        {
            var filePath = "user.json";

            //Creates a "Relative Path" that goes 3 folders up from the current/starting directory
            filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"./Data\\user.json");
            Directory.CreateDirectory(@"./Data");   //Creates the directory if it doesnt exist
            File.AppendAllText(filePath, ""); //Opens the file and writes the content to it creates it if it doesnt exist
            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var userList = JsonConvert.DeserializeObject<List<User>>(jsonData)
                                  ?? new List<User>();

            //add new user to the list
            userList.Add(new User(username, password, age, "User"));
            jsonData = JsonConvert.SerializeObject(userList);
            File.WriteAllText(filePath, jsonData);

            return true;
        }

        public static bool FindUser(string username, string password)
        {
            var filePath = "user.json";

            //Creates a "Relative Path" that goes 3 folders up from the current/starting directory
            filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"./Data\\user.json");
            Directory.CreateDirectory(@"./Data");   //Creates the directory if it doesnt exist
            File.AppendAllText(filePath, "");
            //load json file with all users
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                if(json.Length > 0)
                { 
                dynamic users = JsonConvert.DeserializeObject(json);

                //loop over all user objects and check if stored data matches the input data
                foreach (var user in users)
                {
                    if (username == Convert.ToString(user.Username))
                    {
                        if (password == Convert.ToString(user.Password))
                        {
                            return true;
                        }
                    }
                }
                }
                return false;
            }
        }

        public static string GetUserId(string username)
        {
            var filePath = "user.json";

            //Creates a "Relative Path" that goes 3 folders up from the current/starting directory
            filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"./Data\\user.json");
            Directory.CreateDirectory(@"./Data");   //Creates the directory if it doesnt exist
            File.AppendAllText(filePath, "");

            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                dynamic users = JsonConvert.DeserializeObject(json);

                //search for username and return user id
                foreach (var user in users)
                {
                    if (username == Convert.ToString(user.Username))
                    {
                        return user.Id;
                    }
                }
                return null;
            }
        }

        public static string GetUserRole(string username)
        {
            var filePath = "user.json";

            //Creates a "Relative Path" that goes 3 folders up from the current/starting directory
            filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"./Data\\user.json");
            Directory.CreateDirectory(@"./Data");   //Creates the directory if it doesnt exist
            File.AppendAllText(filePath, "");

            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                dynamic users = JsonConvert.DeserializeObject(json);

                //search for username and return user role
                foreach (var user in users)
                {
                    if (username == Convert.ToString(user.Username))
                    {
                        return user.Role;
                    }
                }
                return null;
            }
            
        }
    }
}
