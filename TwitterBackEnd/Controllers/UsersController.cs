using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TwitterBackEnd.DTOs;
using TwitterBackEnd.Models.Domein;
using TwitterBackEnd.Models.ViewModels;

namespace TwitterBackEnd.Controllers
{
  [ApiController]
  [Route("Twipper/[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly IUserRepository _gebruikerRepository;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _conf;

    public UsersController(IUserRepository gebruikerRepository, UserManager<User> userManager, IConfiguration configuration,
        SignInManager<User> signInManager)
    {
      _gebruikerRepository = gebruikerRepository;
      _userManager = userManager;
      _conf = configuration;
      _signInManager = signInManager;
    }

    /// <summary>
    /// Get all users
    /// </summary>
    /// <returns>All users from DB</returns>
    [HttpGet]
    [Route("all")]
    public ActionResult<List<GebruikerDTO>> GetAll()
    {
      var alleGebruikers =  _gebruikerRepository.GetAll();

      if(alleGebruikers == null || !alleGebruikers.Any())
      {
        return NotFound();
      }

      return Ok(VervormLijstVanGebruikersNaarLijstVanGebruikerDTOs(alleGebruikers.ToList()));
    }



    /// <summary>
    /// Get user based on his username
    /// </summary>
    /// <param name="naamVanGebruiker">username</param>
    /// <returns>user</returns>
    [HttpGet]
    [Route("{userName}")]
    public ActionResult<GebruikerDTO> GetUserByUserName(string userName)
    {
      var gebruiker =  _gebruikerRepository.GetUserByUserName(userName);

      if (gebruiker == null)
      {
        return NotFound();
      }

      return Ok(new GebruikerDTO(gebruiker));
    }

    /// <summary>
    /// Try to log user in
    /// </summary>
    /// <param name="loginDTO">The info of user</param>
    /// <returns>user</returns>
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<string>> Login(LoginDTO loginDTO)
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

        return Created("", token);
      }
      else
      {
        return BadRequest(new { message = "Username of password doesn't match!" });
      }
    }

    /// <summary>
    /// Try to register user
    /// </summary>
    /// <param name="DTOViewModel">The info of user</param>
    /// <returns>user</returns>
    [HttpPost]
    [Route("register")]
    public async Task<object> Register(RegistreerDTO DTOViewModel)
    {
      User gebruiker = new User(DTOViewModel.VolledigeNaam, DTOViewModel.Email, DTOViewModel.UserName);

      try
      {
        var result = await _userManager.CreateAsync(gebruiker, DTOViewModel.Password);
        
        return Ok(result);
      }
      catch (Exception ex)
      {
        return BadRequest("Register failed");
      }
    }

    private List<GebruikerDTO> VervormLijstVanGebruikersNaarLijstVanGebruikerDTOs(List<User> alleGebruikers)
    {
      List<GebruikerDTO> lijstVanGebruikerDTOs = new List<GebruikerDTO>();

      alleGebruikers.ForEach(g => lijstVanGebruikerDTOs.Add(new GebruikerDTO(g)));

      return lijstVanGebruikerDTOs;
    }
  }
}
