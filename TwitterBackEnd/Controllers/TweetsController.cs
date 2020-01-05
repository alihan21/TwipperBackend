using Microsoft.AspNetCore.Mvc;
using TwitterBackEnd.Data.Repositories.Interfaces;
using TwitterBackEnd.DTOs;

namespace TwitterBackEnd.Controllers
{
  [Route("Twipper/[controller]")]
  [ApiController]
  public class TweetsController : ControllerBase
  {
    private readonly ITweetRepository _tweetRepository;

    public TweetsController(ITweetRepository tweetRepository)
    {
      _tweetRepository = tweetRepository;
    }

    /// <summary>
    /// Get a tweet based on it's id
    /// </summary>
    /// <param name="tweetId">id of tweet</param>
    /// <returns>tweetDTO</returns>
    [HttpGet]
    [Route("{tweetId}")]
    public ActionResult<TweetDTO> GetById(int tweetId)
    {
      var tweet = _tweetRepository.GetById(tweetId);

      if(tweet == null)
      {
        return NotFound();
      }

      return Ok(new TweetDTO(tweet));
    }
  }
}
