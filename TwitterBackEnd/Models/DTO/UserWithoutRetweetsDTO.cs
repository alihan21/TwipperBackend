using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd.DTOs
{
  public class UserWithoutRetweetsDTO
  {
    public string Id { get; set; }
    public string VolledigeNaam { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }

    public UserWithoutRetweetsDTO(User gebruiker)
    {
      Id = gebruiker.Id;
      VolledigeNaam = gebruiker.FullName;
      Email = gebruiker.Email;
      UserName = gebruiker.UserName;
    }
  }
}
