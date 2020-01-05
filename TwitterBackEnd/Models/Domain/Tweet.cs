using System;
using System.Collections.Generic;
using TwitterBackEnd.Models.Domain;

namespace TwitterBackEnd.Models.Domein
{
  public class Tweet : BaseTweet
  {
    public List<Retweet> Retweets { get; set; }

    public Tweet(User postedBy, string description, string date) : base(postedBy, description, date)
    {
      Retweets = new List<Retweet>();
    }

    protected Tweet()
    {
      Retweets = new List<Retweet>();
    }

    public void VoegNieuweRetweet(User user, string description, string date)
    {
      Retweets.Add(new Retweet(user, description, date));
    }
  }
}
