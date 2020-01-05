using System;
using System.Collections.Generic;
using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd.DTOs
{
  public class TweetDTO
  {
    public int TweetId { get; set; }
    public string Description { get; set; }
    public string TweetDate { get; set; }
    public List<RetweetDTO> Retweets { get; set; }
    public UserWithoutRetweetsDTO PostedBy { get; set; }

    public TweetDTO(Tweet tweet)
    {
      TweetId = tweet.Id;
      Description = tweet.Description;
      TweetDate = tweet.BaseTweetDate;
      Retweets = FillWithRetweetDTOs(tweet.Retweets);
      PostedBy = new UserWithoutRetweetsDTO(tweet.PostedBy);
    }

    private List<RetweetDTO> FillWithRetweetDTOs(List<Retweet> retweets)
    {
      List<RetweetDTO> temp = new List<RetweetDTO>();

      retweets.ForEach(t => temp.Add(new RetweetDTO(t)));

      return temp;
    }
  }
}
