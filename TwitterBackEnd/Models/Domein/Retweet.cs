using System;

namespace TwitterBackEnd.Models.Domein
{
    public class Retweet
    {
        public int RetweetId { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public string Boodschap { get; set; }
        public DateTime TweetDatum { get; set; }

        public Retweet(Gebruiker gebruiker, string boodschap){
            Gebruiker = gebruiker;
            Boodschap = boodschap;
            TweetDatum = DateTime.UtcNow;
        }

        public Retweet()
        {

        }
    }
}
