using Newtonsoft.Json;
using System;
using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd.DTOs
{
    public class RetweetDTO
    {
        public int RetweetId { get; set; }
        public GebruikerZonderTweetsDTO Gebruiker { get; set; }
        public string Boodschap { get; set; }
        public DateTime RetweetDatum { get; set; }

        public RetweetDTO(Retweet retweet)
        {
            RetweetId = retweet.RetweetId;
            Gebruiker = new GebruikerZonderTweetsDTO(retweet.Gebruiker);
            Boodschap = retweet.Boodschap;
            RetweetDatum = retweet.TweetDatum;
        }
    }
}
