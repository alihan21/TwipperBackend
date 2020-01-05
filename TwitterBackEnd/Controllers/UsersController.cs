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
using TwitterBackEnd.Models.DTO;
using TwitterBackEnd.Models.ViewModels;

namespace TwitterBackEnd.Controllers
{
  [ApiController]
  [Route("Twipper/[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly IUserRepository _userRepository;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _conf;

    public UsersController(IUserRepository userRepository, UserManager<User> userManager, IConfiguration configuration,
        SignInManager<User> signInManager)
    {
      _userRepository = userRepository;
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
    public ActionResult<List<UserDTO>> GetAll()
    {
      var alleGebruikers =  _userRepository.GetAll();

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
    [Route("{userId}")]
    public ActionResult<UserDTO> GetUserByUserName(string userId)
    {
      var user =  _userRepository.GetUserById(userId);

      if (user == null)
      {
        return NotFound();
      }

      return Ok(new UserDTO(user));
    }

    /// <summary>
    /// Try to log user in
    /// </summary>
    /// <param name="loginDTO">The info of user</param>
    /// <returns>user</returns>
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<LoggedInDTO>> Login(LoginDTO loginDTO)
    {
      var user = await _userManager.FindByNameAsync(loginDTO.UserName);

      if (user != null && await _userManager.CheckPasswordAsync(user, loginDTO.Password))
      {
        var tokenDescriptor = new SecurityTokenDescriptor
        {
          Subject = new ClaimsIdentity(new Claim[]{
                        new Claim("GebruikerId", user.Id)
                    }),
          Expires = DateTime.UtcNow.AddHours(1),
          SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf["JWT_SecretKey"])), SecurityAlgorithms.HmacSha256Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var token = tokenHandler.WriteToken(securityToken);

        var userFromDB = _userRepository.GetUserById(user.Id);

        var userWithToken = new LoggedInDTO(userFromDB, token);

        return Created("", userWithToken);
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
    public async Task<ActionResult<UserDTO>> Register(RegisterDTO DTOViewModel)
    {
      var errorMessage = "";
      User user = new User(DTOViewModel.FullName, DTOViewModel.Email, DTOViewModel.UserName);


      try
      {
        var result = await _userManager.CreateAsync(user, DTOViewModel.Password);
        errorMessage = result.Errors.FirstOrDefault()?.Description;

        if (result.Succeeded)
        {
          return Ok(new UserDTO(user));
        }

        return BadRequest(new { message = errorMessage });
      }
      catch (Exception ex)
      {
        return BadRequest(new { message = "Register failed" });
      }
    }

    private List<UserDTO> VervormLijstVanGebruikersNaarLijstVanGebruikerDTOs(List<User> alleGebruikers)
    {
      List<UserDTO> lijstVanGebruikerDTOs = new List<UserDTO>();

      alleGebruikers.ForEach(g => lijstVanGebruikerDTOs.Add(new UserDTO(g)));

      return lijstVanGebruikerDTOs;
    }
  }
}
