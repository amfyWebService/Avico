using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AvicoApp.Models
{
    public class HotelRoom
    {
        [Key]
        public int ID { get; private set; }

        [Required, MaxLength(255)]
        public string Description { get; set; }

        [Required, Range(1, double.MaxValue)]
        public int PeopleNumber { get; set; }

        [Required, Range(0, double.MaxValue)]
        public int NumberOfRooms { get; set; }

        public Hotel Hotel { get; private set; }

        public IEnumerable<Booking> Bookings { get; set; } = Enumerable.Empty<Booking>();

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
    }
}