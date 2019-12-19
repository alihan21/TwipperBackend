using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd.DTOs
{
    public class GeefIngelogdeGebruikerDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string VolledigeNaam { get; set; }
        public List<TweetDTO> Tweets { get; set; }
        public List<GebruikerZonderTweetsDTO> Volgers { get; set; }
        public List<GebruikerDTO> Gevolgden { get; set; }

        public GeefIngelogdeGebruikerDTO(Gebruiker gebruiker)
        {
            Id = gebruiker.Id;
            UserName = gebruiker.UserName;
            Email = gebruiker.Email;
            VolledigeNaam = gebruiker.VolledigeNaam;
            Tweets = VulLijstMetTweetDTOs(gebruiker.Tweets);
            Volgers = VulLijstMetGebruikerZonderTweetsDTO(gebruiker.Volgers);
            Gevolgden = VulLijstMetGebruikerDTOs(gebruiker.Gevolgden);
            var lol = 15;
        }

        private List<TweetDTO> VulLijstMetTweetDTOs(List<Tweet> tweets)
        {
            List<TweetDTO> tijdeljk = new List<TweetDTO>();

            tweets.ForEach(t => {
                tijdeljk.Add(new TweetDTO(t));
            });

            return tijdeljk;
        }

        private List<GebruikerZonderTweetsDTO> VulLijstMetGebruikerZonderTweetsDTO(List<Gebruiker> gebruikers){
            List<GebruikerZonderTweetsDTO> tijdeljk = new List<GebruikerZonderTweetsDTO>();

            gebruikers.ForEach(g => {
                tijdeljk.Add(new GebruikerZonderTweetsDTO(g));
            });

            return tijdeljk;
        }

        private List<GebruikerDTO> VulLijstMetGebruikerDTOs(List<Gebruiker> gebruikers)
        {
            List<GebruikerDTO> tijdeljk = new List<GebruikerDTO>();

            gebruikers.ForEach(g => {
                tijdeljk.Add(new GebruikerDTO(g.Id, g.VolledigeNaam, g.Email, g.UserName, g.Tweets));
            });

            return tijdeljk;
        }
    }
}
