using System;
using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd.Models.Domain
{
  public abstract class BaseTweet
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public string BaseTweetDate { get; set; }
    public User PostedBy { get; set; }

    public BaseTweet(User postedBy, string description, string date)
    {
      PostedBy = postedBy;
      Description = description;
      BaseTweetDate = date;
    }

    protected BaseTweet()
    {

    }
  }
}
