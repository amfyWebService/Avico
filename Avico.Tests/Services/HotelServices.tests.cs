using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AvicoApp.Controllers;
using AvicoApp.Data;
using AvicoApp.Models;
using AvicoApp.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Avico.Tests.Services
{

    public class HotelServicesTests : IClassFixture<InMemoryDbFixture>
    {        
        private readonly ApplicationDbContext _context;
        public HotelServicesTests()
        {
        }

        [Fact]
        public async Task IndexReturnsARedirectToIndexHotel()
        {
             // Arrange
            var controller = new HotelController(this._context);

            // Act
            var result = await controller.Index();

            // Assert
            var redirectToActionResult = 
                Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Hotel", redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
        // private List<Hotel> GetTestHotels()
        // {
        //     var hotels = new List<Hotel>();
        //     hotels.Add(new Hotel()
        //     {
        //         DateCreated = new DateTime(2016, 7, 2),
        //         Id = 1,
        //         Name = "Test One"
        //     });
        //     hotels.Add(new Hotel()
        //     {
        //         DateCreated = new DateTime(2016, 7, 1),
        //         Id = 2,
        //         Name = "Test Two"
        //     });
        //     return hotels;
        // }
    }
}