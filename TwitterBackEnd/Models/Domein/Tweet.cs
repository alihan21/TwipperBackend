using System;
using System.Collections.Generic;

namespace TwitterBackEnd.Models.Domein
{
    public class Tweet
    {
        public int TweetId { get; set; }
        public string Boodschap { get; set; }
        public DateTime TweetDatum { get; set; }
        public List<Retweet> Retweets { get; set; }

        public void VoegNieuweRetweet(Gebruiker gebruiker, string boodschap){
            Retweets.Add(new Retweet(gebruiker, boodschap));
        }
    }
}
