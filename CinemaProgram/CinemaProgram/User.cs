using System;
using System.Collections.Generic;
using System.Text.Json;

namespace CinemaProgram
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Age { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDateTime { get; set; }

        DateTime DateTime = DateTime.Now;

        public User(string username, string password, string age, string role)
        {
            Id = Guid.NewGuid().ToString("N");
            Username = username;
            Password = password;
            Age = age;
            Role = role;
            CreatedDateTime = DateTime;
        }

        internal string getUsername()
        {
            return Username;
        }

        internal string getUserID()
        {
            return Id;
        }

        internal string getUserAge()
        {
            return Age;
        }
    }
}

