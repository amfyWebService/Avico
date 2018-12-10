using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AvicoApp.Models
{
    public class Address
    {
        [Column(TypeName = "varchar(255)")]
        public string Street { get; set; }

        [Column(TypeName = "varchar(255)"), DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string City { get; set; }
    }
}