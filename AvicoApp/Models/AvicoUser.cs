using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace AvicoApp.Models
{
    public class AvicoUser: IdentityUser
    {
        [PersonalData, Required, Column(TypeName = "varchar(255)")]
        public string FirstName { get; set; }

        [PersonalData, Required, Column(TypeName = "varchar(255)")]
        public string LastName { get; set; }

        public IEnumerable<Establishment> Establishments { get; set; } = Enumerable.Empty<Establishment>();

        public IEnumerable<Booking> Bookings { get; set; } = Enumerable.Empty<Booking>();

        public IEnumerable<Review> Reviews { get; set; } = Enumerable.Empty<Review>();
    }
}