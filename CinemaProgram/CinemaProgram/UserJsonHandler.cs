using System;
using System.Collections.Generic;
using System.IO;
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
        public static bool SaveUser(string username, string password, DateTime birthday)
        {
            var filePath = "user.json";
            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var userList = JsonConvert.DeserializeObject<List<User>>(jsonData)
                                  ?? new List<User>();

            //add new user to the list
            userList.Add(new User(username, password, birthday, "User"));
            jsonData = JsonConvert.SerializeObject(userList);
            File.WriteAllText(filePath, jsonData);

            return true;
        }

        public static bool FindUser(string username, string password)
        {
            //load json file with all users
            using (StreamReader r = new StreamReader("user.json"))
            {
                string json = r.ReadToEnd();
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
                return false;
            }
        }

        public static string GetUserId(string username)
        {
            using (StreamReader r = new StreamReader("user.json"))
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
            using (StreamReader r = new StreamReader("user.json"))
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

        public static void ChangeUserRole()
        {
            var filePath = "user.json";
            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var users = JsonConvert.DeserializeObject<List<User>>(jsonData)
                                  ?? new List<User>();

            Console.WriteLine("Van wie wil u de rol verander");
            string username = Console.ReadLine();
            
            Console.WriteLine($"Welke rol wilt u {username} geven?");

            var table = new ConsoleTable("1", "Admin");
            table.AddRow("2", "User");
            table.Write();
            string role = Console.ReadLine();
            foreach (var user in users)
            {
                if (username == Convert.ToString(user.Username))
                {
                    if(role == "1")
                    {
                        user.Role = "Admin";
                    }
                    if (role == "2")
                    {
                        user.Role = "User";
                    }
                }
            }
            jsonData = JsonConvert.SerializeObject(users);
            File.WriteAllText(filePath, jsonData);
        }
    }
}
