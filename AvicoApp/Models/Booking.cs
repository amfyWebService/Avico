using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using AvicoApp.Models.Validation;

namespace AvicoApp.Models
{
    public class Booking : IValidatableObject
    {
        [Key]
        public int ID { get; set; }

        [Required, Range(1, double.MaxValue)]
        public int PeopleNumber { get; set; }

        [DataType(DataType.Date), Required, DateGreaterThan("Today")]
        public DateTime ArrivalDate { get; set; }

        [DataType(DataType.Date), Required, DateGreaterThan("ArrivalDate")]
        public DateTime DepartureDate { get; set; }

        [Required, Range(1, double.MaxValue)]
        public int NumberOfRooms { get; set; }

        public HotelRoom HotelRoom { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.NumberOfRooms > this.HotelRoom.HowManyIsAvailable(this.ArrivalDate, this.DepartureDate))
            {
                yield return new ValidationResult
                    ("Rooms unavailable for this stay duration", new[] { "ArrivalDate", "DepartureDate" });
            }

            if(this.PeopleNumber > (this.HotelRoom.PeopleNumber * this.NumberOfRooms)){
                yield return new ValidationResult
                    ("Not enough space", new[] { "PeopleNumber", "NumberOfRooms" });
            }
        }
    }
}