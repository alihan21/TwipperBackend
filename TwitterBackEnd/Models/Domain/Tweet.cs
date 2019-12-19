using System;
using System.Collections.Generic;

namespace TwitterBackEnd.Models.Domein
{
  public class Tweet
  {
    public int TweetId { get; set; }
    public string Description { get; set; }
    public DateTime TweetDate { get; set; }
    public List<Retweet> Retweets { get; set; }

    public Tweet(string description)
    {
      Description = description;
      TweetDate = DateTime.UtcNow;
      Retweets = new List<Retweet>();
    }

    protected Tweet()
    {
      Retweets = new List<Retweet>();
    }

    public void VoegNieuweRetweet(User user, string description)
    {
      Retweets.Add(new Retweet(user, description));
    }
  }
}
