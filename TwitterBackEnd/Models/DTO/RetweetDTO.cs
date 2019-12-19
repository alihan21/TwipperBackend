using System;
using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd.DTOs
{
  public class RetweetDTO
  {
    public int RetweetId { get; set; }
    public UserWithoutRetweetsDTO User { get; set; }
    public string Description { get; set; }
    public DateTime RetweetDate { get; set; }

    public RetweetDTO(Retweet retweet)
    {
      RetweetId = retweet.RetweetId;
      User = new UserWithoutRetweetsDTO(retweet.Gebruiker);
      Description = retweet.Description;
      RetweetDate = retweet.TweetDate;
    }
  }
}
