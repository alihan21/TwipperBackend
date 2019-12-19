using System;
using System.Collections.Generic;
using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd.DTOs
{
    public class TweetDTO
    {
        public int TweetId { get; set; }
        public string Boodschap { get; set; }
        public DateTime TweetDatum { get; set; }
        public List<RetweetDTO> Retweets { get; set; }

        public TweetDTO(Tweet tweet)
        {
            TweetId = tweet.TweetId;
            Boodschap = tweet.Boodschap;
            TweetDatum = tweet.TweetDatum;
            Retweets = VulLijstMetRetweetDTOs(tweet.Retweets);
        }

        private List<RetweetDTO> VulLijstMetRetweetDTOs(List<Retweet> retweets)
        {
            List<RetweetDTO> tijdeljk = new List<RetweetDTO>();

            retweets.ForEach(t => {
                tijdeljk.Add(new RetweetDTO(t));
            });

            return tijdeljk;
        }
    }
}
