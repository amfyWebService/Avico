using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AvicoApp.Models
{
    public class HotelRoom: IIsOwner
    {
        [Key]
        public int ID { get; private set; }

        [Required, MaxLength(255)]
        public string Description { get; set; }

        [Required, Range(1, double.MaxValue)]
        public int PeopleNumber { get; set; }

        [Required, Range(0, double.MaxValue)]
        public int NumberOfRooms { get; set; }

        public int HotelId { get; private set; }
        public Hotel Hotel { get; private set; }

        public List<Booking> Bookings { get; set; } = new List<Booking>();

        public int HowManyIsAvailable(DateTime startDate, DateTime? endDate = null)
        {
            if (!endDate.HasValue)
            {
                endDate = startDate.AddDays(1);
            }

            List<int> numbersUnavailable = new List<int>();

            for (DateTime start = startDate; start < endDate; start = start.AddDays(1))
            {
                numbersUnavailable.Append(
                    (from booking in this.Bookings
                     where booking.ArrivalDate <= startDate && booking.DepartureDate >= startDate
                     select booking).Count()
                );
            }

            return numbersUnavailable.Min();
        }

        public bool IsOwner(ApplicationUser user)
        {
            return this.Hotel.ManagerId == user.Id;
        }
    }
}