using System;

namespace TwitterBackEnd.Models.Domein
{
  public class Retweet
  {
    public int RetweetId { get; set; }
    public User Gebruiker { get; set; }
    public string Description { get; set; }
    public DateTime TweetDate { get; set; }

    public Retweet(User user, string description)
    {
      Gebruiker = user;
      Description = description;
      TweetDate = DateTime.UtcNow;
    }

    protected Retweet()
    {

    }
  }
}
