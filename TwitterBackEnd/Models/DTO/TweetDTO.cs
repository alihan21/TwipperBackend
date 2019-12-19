using System;
using System.Collections.Generic;
using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd.DTOs
{
  public class TweetDTO
  {
    public int TweetId { get; set; }
    public string Description { get; set; }
    public DateTime TweetDate { get; set; }
    public List<RetweetDTO> Retweets { get; set; }

    public TweetDTO(Tweet tweet)
    {
      TweetId = tweet.TweetId;
      Description = tweet.Description;
      TweetDate = tweet.TweetDate;
      Retweets = FillWithRetweetDTOs(tweet.Retweets);
    }

    private List<RetweetDTO> FillWithRetweetDTOs(List<Retweet> retweets)
    {
      List<RetweetDTO> temp = new List<RetweetDTO>();

      retweets.ForEach(t => temp.Add(new RetweetDTO(t)));

      return temp;
    }
  }
}
