using System;
using System.Threading.Tasks;
using AvicoApp.Controllers;
using AvicoApp.Data;
using AvicoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Avico.Tests
{
    public class UnitTest1
    {
        
        private readonly HotelController _hotelController;

        private readonly ApplicationDbContext _context;

        public UnitTest1(ApplicationDbContext context){
            _context = context;
            _hotelController = new HotelController(context);
        }

        [Fact]
        public void Test1()
        {

        }

        
        [Fact]
        public async Task Test_should_create_hotel()
        {
            Hotel hotel = new Hotel(){
                Description = "teet"
            };
            // var result =  await _hotelController.Create(hotel);
            // var viewResult = Assert.IsType<ViewResult>(result);
        }
    }
}
