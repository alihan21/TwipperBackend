using System.ComponentModel.DataAnnotations;

namespace TwitterBackEnd.Models.ViewModels
{
    public class LoginDTO
    {
        [Required]
        public string Gebruikersnaam { get; set; }

        [Required]
        public string Wachtwoord { get; set; }
    }
}
