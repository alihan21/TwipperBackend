using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TwitterBackEnd.DTOs;
using TwitterBackEnd.Models.Domein;
using TwitterBackEnd.Models.ViewModels;

namespace TwitterBackEnd.Controllers
{
  //EnableCors["LOL "]
  [Route("api/[controller]")]
  [ApiController]
  public class GebruikerController : ControllerBase
  {
    private readonly IGebruikerRepository _gebruikerRepository;
    private readonly UserManager<Gebruiker> _userManager;
    private readonly SignInManager<Gebruiker> _signInManager;
    private readonly IConfiguration _conf;

    public GebruikerController(IGebruikerRepository gebruikerRepository, UserManager<Gebruiker> userManager, IConfiguration configuration,
        SignInManager<Gebruiker> signInManager)
    {
      _gebruikerRepository = gebruikerRepository;
      _userManager = userManager;
      _conf = configuration;
      _signInManager = signInManager;
    }

    // GET: api/Gebruiker
    [HttpGet]
    //[Authorize]
    public async Task<ActionResult<List<GebruikerDTO>>> GetGebruikersAsync()
    {
      var alleGebruikers = await _gebruikerRepository.GeefAlleGebruikers();

      return Ok(VervormLijstVanGebruikersNaarLijstVanGebruikerDTOs(alleGebruikers));
    }



    // GET: api/Gebruiker/vincent
    [HttpGet("{naamVanGebruiker}")]
    [Authorize]
    public async Task<ActionResult<GebruikerDTO>> GeefGebruikerMetNaam(string naamVanGebruiker)
    {
      var gebruiker = await _gebruikerRepository.GeefGebruikerMetNaam(naamVanGebruiker);

      if (gebruiker == null)
      {
        return NotFound();
      }

      return new GebruikerDTO(gebruiker);
    }

    [HttpPost]
    [Route("Login")]
    [AllowAnonymous]
    // POST: api/Gebruiker/Login
    public async Task<IActionResult> Login(LoginDTO loginDTO)
    {
      var gebruiker = await _userManager.FindByNameAsync(loginDTO.Gebruikersnaam);

      if (gebruiker != null && await _userManager.CheckPasswordAsync(gebruiker, loginDTO.Wachtwoord))
      {
        var tokenDescriptor = new SecurityTokenDescriptor
        {
          Subject = new ClaimsIdentity(new Claim[]{
                        new Claim("GebruikerId", gebruiker.Id)
                    }),
          Expires = DateTime.UtcNow.AddHours(1),
          SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf["JWT_SecretKey"])), SecurityAlgorithms.HmacSha256Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var token = tokenHandler.WriteToken(securityToken);

        return Ok(new { token });
      }
      else
      {
        return BadRequest(new { message = "Gebruikersnaam of wachtwoord klopt niet!" });
      }
    }

    [HttpPost]
    [Route("Registreer")]
    [AllowAnonymous]
    public async Task<object> RegistreerPost(RegistreerDTO DTOViewModel)
    {
      Gebruiker gebruiker = new Gebruiker()
      {
        UserName = DTOViewModel.UserName,
        Email = DTOViewModel.Email,
        VolledigeNaam = DTOViewModel.VolledigeNaam
      };

      try
      {
        var result = await _userManager.CreateAsync(gebruiker, DTOViewModel.Password);
        return Ok(result);
      }
      catch (Exception ex)
      {
        return ValidationProblem();
      }
    }

    private List<GebruikerDTO> VervormLijstVanGebruikersNaarLijstVanGebruikerDTOs(List<Gebruiker> alleGebruikers)
    {
      List<GebruikerDTO> lijstVanGebruikerDTOs = new List<GebruikerDTO>();

      alleGebruikers.ForEach(g => lijstVanGebruikerDTOs.Add(new GebruikerDTO(g)));

      return lijstVanGebruikerDTOs;
    }
  }
}
