using System;
using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd.DTOs
{
  public class RetweetDTO
  {
    public int RetweetId { get; set; }
    public UserWithoutRetweetsDTO User { get; set; }
    public string Description { get; set; }
    public string RetweetDate { get; set; }

    public RetweetDTO(Retweet retweet)
    {
      RetweetId = retweet.Id;
      User = new UserWithoutRetweetsDTO(retweet.PostedBy);
      Description = retweet.Description;
      RetweetDate = retweet.BaseTweetDate;
    }
  }
}
