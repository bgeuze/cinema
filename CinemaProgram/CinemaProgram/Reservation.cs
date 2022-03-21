using System;
namespace CinemaProgram
{
    public class Reservation
    {
        public string Id { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public bool BarReservation { get; set; }
        public DateTime CreadtedDateTime { get; set; }

        DateTime DateTime = DateTime.Now;

        public Reservation(string name, bool barReservation, string userId)
        {
            Id = Guid.NewGuid().ToString("N");
            UserID = userId;
            Name = name;
            BarReservation = barReservation;
            CreadtedDateTime = DateTime;
        }
    }
}
