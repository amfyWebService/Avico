using System.ComponentModel.DataAnnotations;

namespace AvicoApp.Models
{
    public class Review: IIsOwner
    {
        [Key]
        public int ID { get; private set; }
        
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        
        [Required, Range(0,5)]
        public int Grade { get; set; }
        
        public int EstablishmentId { get; set; }
        public Establishment Establishment { get; set; }
        
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public bool IsOwner(ApplicationUser user)
        {
            return this.UserId == user.Id;
        }
    }
}