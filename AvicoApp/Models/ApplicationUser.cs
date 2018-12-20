using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace AvicoApp.Models
{
    public class ApplicationUser: IdentityUser
    {
        // [PersonalData, Required, Column(TypeName = "varchar(255)")]
        // public string FirstName { get; set; }

        // [PersonalData, Required, Column(TypeName = "varchar(255)")]
        // public string LastName { get; set; }

        public List<Establishment> Establishments { get; set; } = new List<Establishment>();

        public List<Booking> Bookings { get; set; } = new List<Booking>();

        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}