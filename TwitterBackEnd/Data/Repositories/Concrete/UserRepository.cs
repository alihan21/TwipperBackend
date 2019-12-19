using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd.Data.Repositories
{
  public class GebruikerRepository : IUserRepository
  {
    private readonly ApplicationDbContext _dbContext;

    public GebruikerRepository(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public void AddUser(User user)
    {
      _dbContext.UsersDB.Add(user);
    }

    public User GetUserById(string userId)
    {
      return _dbContext.UsersDB.
          Include(g => g.Tweets).
          ThenInclude(t => t.Retweets).
          ThenInclude(r => r.Gebruiker).
          Include(g => g.FollowingList).
          ThenInclude(gtt => gtt.Follower).
          Include(g => g.FollowersList).
          ThenInclude(gtt => gtt.Following).
          ThenInclude(g => g.Tweets).
          ThenInclude(t => t.Retweets).
          ThenInclude(r => r.Gebruiker).
          SingleOrDefault(g => g.Id == userId);
    }

    public User GetUserByUserName(string userName)
    {
      return _dbContext.UsersDB.
          Include(g => g.Tweets).
          ThenInclude(t => t.Retweets).
          ThenInclude(r => r.Gebruiker).
          Include(g => g.FollowingList).
          ThenInclude(gtt => gtt.Follower).
          Include(g => g.FollowersList).
          ThenInclude(gtt => gtt.Following).
          SingleOrDefault(g => g.UserName == userName);
    }

    public User GetUserByTweetId(int tweetId)
    {
      return _dbContext.UsersDB.
          Include(g => g.Tweets).
          ThenInclude(t => t.Retweets).
          ThenInclude(r => r.Gebruiker).
          Include(g => g.FollowingList).
          ThenInclude(gtt => gtt.Follower).
          Include(g => g.FollowersList).
          ThenInclude(gtt => gtt.Following).
          SingleOrDefault(g => g.Tweets.Exists(t => t.TweetId == tweetId));
    }

    public IEnumerable<User> GetAll()
    {
      return _dbContext.UsersDB.
          Include(g => g.Tweets).
          ThenInclude(t => t.Retweets).
          ThenInclude(r => r.Gebruiker).
          Include(g => g.FollowingList).
          ThenInclude(gtt => gtt.Follower).
          Include(g => g.FollowersList).
          ThenInclude(gtt => gtt.Following).
          ToList();
    }

    public void SaveChanges()
    {
      _dbContext.SaveChanges();
    }
  }
}
