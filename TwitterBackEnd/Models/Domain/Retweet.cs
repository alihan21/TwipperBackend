using System;
using TwitterBackEnd.Models.Domain;

namespace TwitterBackEnd.Models.Domein
{
  public class Retweet : BaseTweet
  {
    public Retweet(User postedBy, string description, string date) : base(postedBy, description, date)
    {
    }

    protected Retweet()
    {

    }
  }
}
