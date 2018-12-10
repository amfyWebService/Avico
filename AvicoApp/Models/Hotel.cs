using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AvicoApp.Models
{
    public class Hotel : Establishment
    {
        public IEnumerable<HotelRoom> HotelRooms { get; set; }

        // public Hotel (string name, string description, string pictureUrl = "", string tel = "", string mail = ""){
        //     this.Name = name;
        //     this.Description = description;
        //     this.PictureUrl = pictureUrl;
        //     this.Tel = tel;
        //     this.Mail = mail;
        //     this.HotelRooms = Enumerable.Empty<HotelRoom>();
        // }

        public int HowManyHotelRoomsAvailableToday(){
            return this.HowManyHotelRoomsAvailable(DateTime.Today);
        }
        public int HowManyHotelRoomsAvailable(DateTime startDate){
            return this.HowManyHotelRoomsAvailable(startDate, null);
        }
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