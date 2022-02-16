using System;
using System.Collections.Generic;
using System.Text.Json;

namespace CinemaProgram
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }

        public User(string username, string password, string rol)
        {
            Id = 1;
            Username = username;
            Password = password;
            Rol = rol;
        }
    }
    //public class RootObject
    //{
    //    public List<User> users { get; set; }
    //}
}
