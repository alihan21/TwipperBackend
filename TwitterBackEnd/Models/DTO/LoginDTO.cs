using System.ComponentModel.DataAnnotations;

namespace TwitterBackEnd.Models.ViewModels
{
  public class LoginDTO
  {
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
  }
}
