using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TwitterBackEnd.DTOs;
using TwitterBackEnd.Models.Domein;
using TwitterBackEnd.Models.DTO;
using TwitterBackEnd.Models.ViewModels;

namespace TwitterBackEnd.Controllers
{
  [ApiController]
  [Route("Twipper/[controller]")]
  public class LoggedInUserController : ControllerBase
  {
    private readonly UserManager<User> _userManager;
    private readonly IUserRepository _gebruikerRepository;

    public LoggedInUserController(UserManager<User> userManager, IUserRepository gebruikerRepository)
    {
      _userManager = userManager;
      _gebruikerRepository = gebruikerRepository;
    }

    /// <summary>
    /// Get logged user
    /// </summary>
    /// <returns>logged user</returns>
    [HttpGet]
    [Authorize]
    public ActionResult<UserDTO> GetLoggedUser()
    {
      var gebruiker =  GeefIngelogdeGebruiker();

      if (gebruiker == null)
      {
        return NotFound();
      }

      return Ok(new UserDTO(gebruiker));
    }

    /// <summary>
    /// Add a new tweet
    /// </summary>
    /// <param name="newTweetDTO">The info of new tweet</param>
    /// <returns>user with new tweet</returns>
    [HttpPost]
    [Authorize]
    [Route("tweets/add")]
    public ActionResult<User> AddNewTweet(NewTweetDTO newTweetDTO)
    {
      var gebruiker =  _gebruikerRepository.GetUserById(newTweetDTO.GebruikerId);

      if (gebruiker != null)
      {
        gebruiker.AddNewTweet(newTweetDTO.TweetBeschrjving);
        _gebruikerRepository.SaveChanges();

        return Ok();
      }

      return Unauthorized();
    }

    /// <summary>
    /// Follows another user
    /// </summary>
    /// <param name="gebruikerId">The id of the following user</param>
    /// <returns>user with new following</returns>
    [HttpPost]
    [Authorize]
    [Route("followers/add/{gebruikerId}")]
    public ActionResult<User> AddFollowing(string gebruikerId)
    {
      var gebruiker = GeefIngelogdeGebruiker();
      if (gebruiker == null)
      {
        return Unauthorized();
      }

      var deTeVolgenGebruiker =  _gebruikerRepository.GetUserById(gebruikerId);

      if (deTeVolgenGebruiker == null)
      {
        return NotFound();
      }

      gebruiker.FollowUser(deTeVolgenGebruiker);
      _gebruikerRepository.SaveChanges();

      return Ok(gebruiker);
    }

    /// <summary>
    /// retweet a existing tweet
    /// </summary>
    /// <param name="newRetweetDTO">The info of retweet</param>
    /// <returns>user</returns>
    [HttpPost]
    [Authorize]
    [Route("tweet/retweets/add")]
    public ActionResult AddNewRetweet(NewRetweetDTO newRetweetDTO)
    {
      var ingelogdeGebruiker = GeefIngelogdeGebruiker();
      var gebruikerVanOrigineleTweet = _gebruikerRepository.GetUserByTweetId(newRetweetDTO.TweetId);

      if (ingelogdeGebruiker != null)
      {
        var origineleTweet = gebruikerVanOrigineleTweet.Tweets.SingleOrDefault(t => t.TweetId == newRetweetDTO.TweetId);

        if (origineleTweet != null)
        {
          origineleTweet.VoegNieuweRetweet(ingelogdeGebruiker, newRetweetDTO.TweetBeschrjving);

          _gebruikerRepository.SaveChanges();

          return Ok();
        }

        return NotFound();
      }

      return Unauthorized();
    }

    private User GeefIngelogdeGebruiker()
    {
      string gebruikerId = User.Claims.First(u => u.Type == "GebruikerId").Value;
      return _gebruikerRepository.GetUserById(gebruikerId);
    }
  }
}
