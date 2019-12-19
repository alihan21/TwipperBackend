﻿using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd.DTOs
{
    public class GebruikerZonderTweetsDTO
    {
        public string Id { get; set; }
        public string VolledigeNaam { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public GebruikerZonderTweetsDTO(Gebruiker gebruiker)
        {
            Id = gebruiker.Id;
            VolledigeNaam = gebruiker.VolledigeNaam;
            Email = gebruiker.Email;
            UserName = gebruiker.UserName;
        }
    }
}
