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
        private InMemoryDbFixture _fixture;
        
        public HotelServicesTests(InMemoryDbFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task test_should_display_empty_list_hotel()
        {
            // var uow = new UnitOfWork<ApplicationDbContext>(_fixture.);
            // var repo = uow.GetRepository<TestProduct>();
            // HotelServices service = _fixture.GetService<HotelServices>();
            // List<Hotel> hotels = await service.ListHotels();
            // Assert.Empty(hotels);
        }
    }
}