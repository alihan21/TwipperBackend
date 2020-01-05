using System.Collections.Generic;
using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd.DTOs
{
  public class UserDTO
  {
    public string Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string AccCreatedOn { get; set; }
    public List<TweetDTO> Tweets { get; set; }
    public List<UserDTO> Following { get; set; }
    public List<UserDTO> Followers { get; set; }

    public UserDTO(User user)
    {
      Id = user.Id;
      FullName = user.FullName;
      Email = user.Email;
      UserName = user.UserName;
      AccCreatedOn = user.AccCreatedOn;
      Tweets = FillWithTweetDTOs(user.Tweets);
      Following = FillWithFollowersOrFollowing(user.FollowingUsers);
      Followers = FillWithFollowersOrFollowing(user.Followers);
    }

    public UserDTO(string id, string fullName, string email, string username, List<Tweet> tweets)
    {
      Id = id;
      FullName = fullName;
      Email = email;
      UserName = username;
      Tweets = FillWithTweetDTOs(tweets);
    }

    private List<UserDTO> FillWithFollowersOrFollowing(List<User> users)
    {
      List<UserDTO> userDTOs = new List<UserDTO>();

      users.ForEach(v => userDTOs.Add(new UserDTO(v.Id, v.FullName, v.Email, v.UserName, v.Tweets)));

      return userDTOs;
    }

    private List<TweetDTO> FillWithTweetDTOs(List<Tweet> tweets)
    {
      List<TweetDTO> temp = new List<TweetDTO>();

      tweets.ForEach(t => temp.Add(new TweetDTO(t)));

      return temp;
    }
  }
}
