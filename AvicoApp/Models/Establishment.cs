using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvicoApp.Models
{
    public abstract class Establishment: IIsOwner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(TypeName = "varchar(255)"), Required, MinLength(1), MaxLength(255)]
        public string Name { get; set; }

        [Required, DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Column(TypeName = "varchar(255)"), Url]
        public string PictureUrl { get; set; }

        [Required]
        public Address Address { get; private set; } = new Address();

        [Column(TypeName = "varchar(15)"), Phone]
        public string Tel { get; set; }

        [Column(TypeName = "varchar(255)"), EmailAddress]
        public string Mail { get; set; }

        public List<Review> Reviews { get; set; } = new List<Review>();

        public string ManagerId { get; set; }
        public ApplicationUser Manager { get; set; }

        [NotMapped]
        public double AvgGrade { 
            get {
                if(this.Reviews.Count() == 0){
                    return 0;
                }

                return (from review in this.Reviews
                    select review.Grade).Average();
            } 
        }

        public bool IsOwner(ApplicationUser user)
        {
            return this.ManagerId == user.Id;
        }
    }
}