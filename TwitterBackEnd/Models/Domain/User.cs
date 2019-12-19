using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TwitterBackEnd.Models.Domein
{
  public class User : IdentityUser
  {
    [Column(TypeName = "nvarchar(50)")]
    public string FullName { get; set; }
    public List<Tweet> Tweets { get; set; }
    public List<Connection> FollowersList { get; set; }
    public List<Connection> FollowingList { get; set; }

    public User(string fullName, string email, string userName)
    {
      FullName = fullName;
      Email = email;
      UserName = userName;
      Tweets = new List<Tweet>();
      FollowersList = new List<Connection>();
      FollowingList = new List<Connection>();
    }

    protected User()
    {
      Tweets = new List<Tweet>();
      FollowersList = new List<Connection>();
      FollowingList = new List<Connection>();
    }

    public List<User> Followers {
      get => FollowingList.Where(gtt => gtt.Following.Id == this.Id).Select(gtt => gtt.Follower).ToList();
    }

    public List<User> FollowingUsers {
      get => FollowersList.Where(gtt => gtt.Follower.Id == this.Id).Select(gtt => gtt.Following).ToList();
    }

    public void AddNewTweet(string tweetDescription)
    {
      Tweets.Add(new Tweet(tweetDescription));
    }

    public void FollowUser(User following)
    {
      FollowersList.Add(new Connection(this, following));
    }
  }
}
