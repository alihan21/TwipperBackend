using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TwitterBackEnd.DTOs;
using TwitterBackEnd.Models.Domein;
using TwitterBackEnd.Models.ViewModels;

namespace TwitterBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GebruikerProfielController : ControllerBase
    {
        private readonly UserManager<Gebruiker> _userManager;
        private readonly IGebruikerRepository _gebruikerRepository;

        public GebruikerProfielController(UserManager<Gebruiker> userManager, IGebruikerRepository gebruikerRepository)
        {
            _userManager = userManager;
            _gebruikerRepository = gebruikerRepository;
        }

        [HttpGet]
        [Authorize]
        //GET : api/GebruikerProfiel
        public async Task<ActionResult<GeefIngelogdeGebruikerDTO>> GeefGebruiker()
        {
            var gebruiker = await GeefIngelogdeGebruiker();

            if (gebruiker == null){
                return NotFound();
            }

            return new GeefIngelogdeGebruikerDTO(gebruiker);
        }

        [HttpPost]
        [Authorize]
        [Route("VoegNieuweTweet")]
        // POST: api/GebruikerProfiel/VoegNieuweTweet
        public async Task<ActionResult> VoegNieuweTweetAsync(NieuweTweetOfRetweetDTO nieuweTweetMetGebruikerIdDTO)
        {
            var gebruiker = await _gebruikerRepository.GeefGebruikerMetId(nieuweTweetMetGebruikerIdDTO.GebruikerId);

            if (gebruiker != null) {
                gebruiker.VoegNieuweTweetToe(nieuweTweetMetGebruikerIdDTO.TweetBeschrjving);
                _gebruikerRepository.SaveChanges();

                return Ok();
            }

            return Unauthorized();
        }

        [HttpPost("{gebruikerId}")]
        [Authorize]
        public async Task<ActionResult> VolgGebruikerMetNaamAsync(string gebruikerId)
        {
            var gebruiker = await GeefIngelogdeGebruiker();
            if (gebruiker == null)
            {
                return Unauthorized();
            }

            var deTeVolgenGebruiker = await _gebruikerRepository.GeefGebruikerMetId(gebruikerId);
            if (deTeVolgenGebruiker == null)
            {
                return NotFound();
            }

            gebruiker.VoegNieuweGevolgdeToe(deTeVolgenGebruiker);
            _gebruikerRepository.SaveChanges();

            return Ok();

        }

        [HttpPost]
        [Authorize]
        [Route("VoegNieuweRetweet")]
        // POST: api/GebruikerProfiel/VoegNieuweRetweet
        public async Task<ActionResult> VoegNieuweRetweetAsync(NieuweTweetOfRetweetDTO nieuweTweetOfRetweetDTO)
        {
            var ingelogdeGebruiker = await GeefIngelogdeGebruiker();
            var gebruikerVanOrigineleTweet = await _gebruikerRepository.GeefGebruikerMetTweetId(nieuweTweetOfRetweetDTO.TweetId);

            if (ingelogdeGebruiker != null)
            {
                var origineleTweet = gebruikerVanOrigineleTweet.Tweets.SingleOrDefault(t => t.TweetId == nieuweTweetOfRetweetDTO.TweetId);

                if(origineleTweet != null)
                {
                    origineleTweet.VoegNieuweRetweet(ingelogdeGebruiker, nieuweTweetOfRetweetDTO.TweetBeschrjving);

                    _gebruikerRepository.SaveChanges();

                    return Ok();
                }

                return NotFound();
            }

            return Unauthorized();
        }

        private async Task<Gebruiker> GeefIngelogdeGebruiker()
        {
            string gebruikerId = User.Claims.First(u => u.Type == "GebruikerId").Value;
            return await _gebruikerRepository.GeefGebruikerMetId(gebruikerId);
        }
    }
}