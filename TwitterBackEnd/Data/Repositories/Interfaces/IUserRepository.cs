using System.Collections.Generic;

namespace TwitterBackEnd.Models.Domein
{
  public interface IUserRepository
  {
    void AddUser(User user);
    User GetUserById(string userId);
    User GetUserByUserName(string userName);
    User GetUserByTweetId(int tweetId);
    IEnumerable<User> GetAll();
    void SaveChanges();
  }
}
