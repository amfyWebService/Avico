using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AvicoApp.Models;

namespace AvicoApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AvicoUser>
    {
        public DbSet<Establishment> Establishments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        // public DbSet<AvicoUser> AvicoUsers { get; set; }

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

            modelBuilder.Entity<Establishment>()
                .HasOne(e => e.Manager)
                .WithMany(u => u.Establishments)
                .IsRequired();

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Establishment)
                .WithMany(e => e.Reviews)
                .IsRequired();

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .IsRequired();

            modelBuilder.Entity<HotelRoom>()
                .HasOne(hr => hr.Hotel)
                .WithMany(h => h.HotelRooms)
                .IsRequired();

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.HotelRoom)
                .WithMany(hr => hr.Bookings)
                .IsRequired();

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .IsRequired();

            
        }

        
    }
}
