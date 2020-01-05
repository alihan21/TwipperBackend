using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterBackEnd.Data.Repositories.Interfaces;
using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd.Data.Repositories.Concrete
{
  public class TweetRepository : ITweetRepository
  {
    private readonly ApplicationDbContext _dbContext;

    public TweetRepository(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public Tweet GetById(int tweetId)
    {
      return _dbContext.Tweets.Include(t => t.PostedBy).Include(t => t.Retweets).ThenInclude(r => r.PostedBy).SingleOrDefault(t => t.Id == tweetId);
    }
  }
}
