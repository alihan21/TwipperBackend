using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd.DTOs
{
  public class UserWithoutRetweetsDTO
  {
    public string Id { get; set; }
    public string VolledigeNaam { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string AccCreatedOn { get; set; }

    public UserWithoutRetweetsDTO(User user)
    {
      Id = user.Id;
      VolledigeNaam = user.FullName;
      Email = user.Email;
      UserName = user.UserName;
      AccCreatedOn = user.AccCreatedOn;
    }
  }
}
