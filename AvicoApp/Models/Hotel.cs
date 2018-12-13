using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AvicoApp.Models
{
    public class Hotel : Establishment
    {
        public IEnumerable<HotelRoom> HotelRooms { get; set; } = Enumerable.Empty<HotelRoom>();

        [DisplayName("Rooms available")]
        public int HowManyHotelRoomsAvailableToday{
            get {
                return this.HowManyHotelRoomsAvailable(DateTime.Today);
            }
        }

        public int HowManyHotelRoomsAvailable(DateTime startDate){
            return this.HowManyHotelRoomsAvailable(startDate, null);
        }

        [DisplayName("Rooms available")]
        public int HowManyHotelRoomsAvailable(DateTime startDate, DateTime? endDate)
        {
            int roomsAvailable = 0;
            IEnumerator<HotelRoom> enumerator = this.HotelRooms.GetEnumerator();

            while (enumerator.MoveNext())
            {
                roomsAvailable += enumerator.Current.HowManyIsAvailable(startDate, endDate);
            }

            return roomsAvailable;
        }
    }
}