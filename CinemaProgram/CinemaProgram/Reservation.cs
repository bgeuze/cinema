using System;

namespace CinemaProgram
{
    public class Reservation
    {
        public string Id { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public bool BarReservation { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Seat[] SeatList { get; set; }

        DateTime CurrentTime = DateTime.Now;

        public Reservation(string id, string name, bool barReservation, string userId, DateTime date, Seat[] seatlist)
        {
            Id = id ?? Guid.NewGuid().ToString("N");
            UserID = userId;
            Name = name;
            BarReservation = barReservation;
            int result = DateTime.Compare(CreatedDateTime, date);
            if (result != 0) {
                CreatedDateTime = date;
            }
            else {
                CreatedDateTime = CurrentTime;
            }
            SeatList = seatlist;
        }
    }
}
