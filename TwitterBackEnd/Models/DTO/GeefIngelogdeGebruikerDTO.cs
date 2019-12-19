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

        public GeefIngelogdeGebruikerDTO(User gebruiker)
        {
            Id = gebruiker.Id;
            UserName = gebruiker.UserName;
            Email = gebruiker.Email;
            VolledigeNaam = gebruiker.FullName;
            Tweets = VulLijstMetTweetDTOs(gebruiker.Tweets);
            Volgers = VulLijstMetGebruikerZonderTweetsDTO(gebruiker.Followers);
            Gevolgden = VulLijstMetGebruikerDTOs(gebruiker.FollowingUsers);
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

        private List<GebruikerZonderTweetsDTO> VulLijstMetGebruikerZonderTweetsDTO(List<User> gebruikers){
            List<GebruikerZonderTweetsDTO> tijdeljk = new List<GebruikerZonderTweetsDTO>();

            gebruikers.ForEach(g => {
                tijdeljk.Add(new GebruikerZonderTweetsDTO(g));
            });

            return tijdeljk;
        }

        private List<GebruikerDTO> VulLijstMetGebruikerDTOs(List<User> gebruikers)
        {
            List<GebruikerDTO> tijdeljk = new List<GebruikerDTO>();

            gebruikers.ForEach(g => {
                tijdeljk.Add(new GebruikerDTO(g.Id, g.FullName, g.Email, g.UserName, g.Tweets));
            });

            return tijdeljk;
        }
    }
}
