namespace AvicoApp.Models
{
    public interface IIsOwner
    {
        bool IsOwner(ApplicationUser user);
    }
}