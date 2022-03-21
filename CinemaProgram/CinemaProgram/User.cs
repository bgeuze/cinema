using System;
using System.Collections.Generic;
using System.Text.Json;

namespace CinemaProgram
{
    public class User
    {
        private string Id { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string Role { get; set; }
        private DateTime CreadtedDateTime { get; set; }

        DateTime DateTime = DateTime.Now;

        public User(string username, string password, string role)
        {
            Id = Guid.NewGuid().ToString("N");
            Username = username;
            Password = password;
     
            Role = role;
            CreadtedDateTime = DateTime;
        }

        internal string getUsername()
        {
            return Username;
        }

        internal string getUserID()
        {
            return Id;
        }
    }
}
