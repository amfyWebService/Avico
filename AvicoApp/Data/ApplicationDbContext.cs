using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AvicoApp.Models;

namespace AvicoApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Establishment> Establishments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        // public DbSet<ApplicationUser> ApplicationUsers { get; set; }

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

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Establishments)
                .WithOne(e => e.Manager)
                .HasForeignKey(e => e.ManagerId)
                .IsRequired();

            modelBuilder.Entity<Establishment>()
                .HasMany(e => e.Reviews)
                .WithOne(r => r.Establishment)
                .HasForeignKey(r => r.EstablishmentId)
                .IsRequired();

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.HotelRooms)
                .WithOne(hr => hr.Hotel)
                .HasForeignKey(hr => hr.HotelId)
                .IsRequired();

            modelBuilder.Entity<HotelRoom>()
                .HasMany(hr => hr.Bookings)
                .WithOne(b => b.HotelRoom)
                .HasForeignKey(b => b.HotelRoomId)
                .IsRequired();

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Bookings)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

            
        }

        
    }
}
