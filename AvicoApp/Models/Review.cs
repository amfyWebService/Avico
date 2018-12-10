using System.ComponentModel.DataAnnotations;

namespace AvicoApp.Models
{
    public class Review
    {
        [Key]
        public int ID { get; private set; }
        
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        
        [Required, Range(0,5)]
        public int Grade { get; set; }
        
        public Establishment Establishment { get; set; }

    }
}