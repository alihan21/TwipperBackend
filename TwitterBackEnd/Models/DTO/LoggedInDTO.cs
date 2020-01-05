using TwitterBackEnd.DTOs;
using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd.Models.DTO
{
  public class LoggedInDTO
  {
    public UserDTO User { get; set; }
    public string Token { get; set; }

    public LoggedInDTO(User user, string token)
    {
      User = new UserDTO(user);
      Token = token;
    }
  }
}
