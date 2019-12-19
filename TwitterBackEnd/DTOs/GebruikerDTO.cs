using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd.DTOs
{
    public class GebruikerDTO
    {
        public string Id { get; set; }
        public string VolledigeNaam { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public List<TweetDTO> Tweets { get; set; }
        public List<GebruikerDTO> Gevolgden { get; set; }
        public List<GebruikerDTO> Volgers { get; set; }

        public GebruikerDTO(Gebruiker gebruiker){
            Id = gebruiker.Id;
            VolledigeNaam = gebruiker.VolledigeNaam;
            Email = gebruiker.Email;
            UserName = gebruiker.UserName;
            Tweets = VulLijstMetTweetDTOs(gebruiker.Tweets);
            Gevolgden = VulLijstMetGevolgdenOfVolgers(gebruiker.Gevolgden);
            Volgers = VulLijstMetGevolgdenOfVolgers(gebruiker.Volgers);
        }

        public GebruikerDTO(string id, string volledigeNaam, string email, string username, List<Tweet> tweets)
        {
            Id = id;
            VolledigeNaam = volledigeNaam;
            Email = email;
            UserName = username;
            Tweets = VulLijstMetTweetDTOs(tweets);
        }

        private List<GebruikerDTO> VulLijstMetGevolgdenOfVolgers(List<Gebruiker> volgers)
        {
            List<GebruikerDTO> gebruikerDTOs = new List<GebruikerDTO>();

            volgers.ForEach(v => gebruikerDTOs.Add(new GebruikerDTO(v.Id, v.VolledigeNaam, v.Email, v.UserName, v.Tweets)));

            return gebruikerDTOs;
        }

        private List<TweetDTO> VulLijstMetTweetDTOs(List<Tweet> tweets)
        {
            List<TweetDTO> tijdeljk = new List<TweetDTO>();

            tweets.ForEach(t => {
                tijdeljk.Add(new TweetDTO(t));
            });

            return tijdeljk;
        }
    }
}
