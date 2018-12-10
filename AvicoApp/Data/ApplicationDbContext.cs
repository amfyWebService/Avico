using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AvicoApp.Models;

namespace AvicoApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Establishment> Establishments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Establishment>()
                .HasDiscriminator<string>("establishment_type")
                .HasValue<Hotel>("establishment_hotel")
                .HasValue<Restaurant>("establishment_restaurant");

            modelBuilder.Entity<Establishment>().OwnsOne(e => e.Address);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Establishment)
                .WithMany(e => e.Reviews)
                .IsRequired();

            modelBuilder.Entity<HotelRoom>()
                .HasOne(hr => hr.Hotel)
                .WithMany(h => h.HotelRooms)
                .IsRequired();

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.HotelRoom)
                .WithMany(hr => hr.Bookings)
                .IsRequired();
        }

        public DbSet<AvicoApp.Models.Restaurant> Restaurant { get; set; }

        public DbSet<AvicoApp.Models.Hotel> Hotel { get; set; }
    }
}
