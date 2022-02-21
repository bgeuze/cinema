using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CinemaProgram
{
    public class JsonHandler
    {
        public static bool SaveUser(string username, string password)
        {
            var filePath = "user.json";
            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var userList = JsonConvert.DeserializeObject<List<User>>(jsonData)
                                  ?? new List<User>();

            //add new user to the list
            userList.Add(new User(username, password, "User"));
            jsonData = JsonConvert.SerializeObject(userList);
            File.WriteAllText(filePath, jsonData);

            return true;
        }

        public static bool FindUser(string username, string password)
        {
            //load json file with all users
            using (StreamReader r = new StreamReader("user.json"))
            {
                if (r == null) { Console.WriteLine("ANAL DIGITAAL"); }
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
    }
}
