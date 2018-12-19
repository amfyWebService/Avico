using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvicoApp.Data;
using AvicoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvicoApp.Services
{
    public class HotelServices
    {
        private readonly ApplicationDbContext _context;

        public HotelServices(ApplicationDbContext context){
            _context = context;
        }

        public async Task<List<Hotel>> ListHotels(){
            return await _context.Hotel.ToListAsync();
        }
        public async Task<Hotel> get(int? id){

            var hotel = await _context.Hotel
                .FirstOrDefaultAsync(m => m.ID == id);

            return hotel;
        }
        public async Task<int> Create([Bind("Name,Description,PictureUrl,Tel,Mail")] Hotel hotel){
            _context.Add(hotel);
            return await _context.SaveChangesAsync();
        }
        public async Task<Hotel> Find(int? id){
            return await _context.Hotel.FindAsync(id);
        }
        public async Task<int> save(int id, [Bind("ID,Name,Description,PictureUrl,Tel,Mail")] Hotel hotel){
            _context.Update(hotel);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int id){
           var hotel = await this.Find(id);
           _context.Hotel.Remove(hotel);
           return await _context.SaveChangesAsync();
        }
        public bool isExists(int id){
            return _context.Hotel.Any(e => e.ID == id);
        }
    }
}