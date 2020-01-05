using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd.Data.Repositories.Interfaces
{
  public interface ITweetRepository
  {
    Tweet GetById(int tweetId);
  }
}
