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

            //check is username is already there
            foreach (User user in userList)
            {
                if (user.getUsername() == username) {
                    return false;
                }
            }

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

        public static bool NowPlayingMovies()
        {
            var filePath = "movies.json";
            //load nowplaying movies from themoviedb endpoint
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://api.themoviedb.org/3/movie/now_playing?api_key=2994dabe7980fbf78dcb92703ce4057a&language=nl-NL&page=1&region=NL");

                var parsedJson = JObject.Parse(json);
                var resultsJson = parsedJson["results"].ToString();
                var allMovies = JsonConvert.DeserializeObject(resultsJson);

                resultsJson = JsonConvert.SerializeObject(allMovies);
                File.WriteAllText(filePath, resultsJson);
            }

            //read existing json data
            var jsonData = File.ReadAllText(filePath);
            //de-serialize to object or create new list
            var movieList = JsonConvert.DeserializeObject<List<Movie>>(jsonData)
                                    ?? new List<Movie>();

            movieList.Add(new Movie(215, "Baruchs Adventure Movie", "16-02-2022", "Adventure movie about the life of Baruch :)"));

            jsonData = JsonConvert.SerializeObject(movieList);
            File.WriteAllText(filePath, jsonData);
        
            return true;
        }
    }
}
