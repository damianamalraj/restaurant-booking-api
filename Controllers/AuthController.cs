using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestaurantBookingApi.Models.DTOs.Identity;
using RestaurantBookingApi.Services.IServices;

namespace RestaurantBookingApi.Data.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService;

    public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration, IEmailService emailService)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _configuration = configuration;
      _emailService = emailService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO userDto)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest();
      }

      var checkUser = await _userManager.FindByEmailAsync(userDto.Email);

      if (checkUser != null)
      {
        return BadRequest("User with this email already exists");
      }

      var user = new IdentityUser
      {
        UserName = userDto.Email,
        Email = userDto.Email
      };

      var result = await _userManager.CreateAsync(user, userDto.Password);

      if (!result.Succeeded)
      {
        return BadRequest(result.Errors);
      }

      var emailConfirmToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

      var confirmEmail = Url.Action("ConfirmEmail", "Auth", new { email = user.Email, emailConfirmToken }, Request.Scheme);

      var emailSent = await _emailService.SendEmailAsync(user.Email, "Confirm your email", $"<h1>Welcome to Restaurant Booking</h1><p>Please confirm your email by <a href='{confirmEmail}'>clicking here</a></p>");

      if (!emailSent)
      {
        return BadRequest("Email confirmation failed to send");
      }

      return Ok("User created successfully");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO userDto)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest();
      }

      var checkUser = await _userManager.FindByEmailAsync(userDto.Email);

      if (checkUser == null)
      {
        return BadRequest("Invalid credentials");
      }

      var checkPassword = await _signInManager.CheckPasswordSignInAsync(checkUser, userDto.Password, false);

      if (!checkPassword.Succeeded)
      {
        return BadRequest("Invalid credentials");
      }

      var token = GenerateJwtToken(checkUser);

      return Ok(new { token });
    }

    private string GenerateJwtToken(IdentityUser user)
    {
      var jwtTokenHandler = new JwtSecurityTokenHandler();

      var issuer = _configuration["Jwt:Issuer"];
      var audience = _configuration["Jwt:Audience"];
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Email, user.Email)
      };

      var token = new JwtSecurityToken(
        issuer: issuer,
        audience: audience,
        claims: claims,
        expires: DateTime.Now.AddHours(1),
        signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
      );

      return jwtTokenHandler.WriteToken(token);
    }

    [HttpGet("google-login")]
    public async Task<IActionResult> GoogleLogin()
    {
      var redirectUrl = Url.Action("GoogleResponse", "Auth");

      var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);

      return Challenge(properties, "Google");
    }

    [HttpGet("google-response")]
    public async Task<IActionResult> GoogleResponse()
    {
      var result = await HttpContext.AuthenticateAsync(IdentityConstants.ExternalScheme);

      if (!result.Succeeded)
      {
        return BadRequest("Google authentication failed");
      }

      var userInfo = await _signInManager.GetExternalLoginInfoAsync();

      var user = await _userManager.FindByEmailAsync(result.Principal.FindFirstValue(ClaimTypes.Email));

      if (user == null)
      {
        user = new IdentityUser
        {
          UserName = result.Principal.FindFirstValue(ClaimTypes.Email),
          Email = result.Principal.FindFirstValue(ClaimTypes.Email)
        };

        var createUserResult = await _userManager.CreateAsync(user);

        if (!createUserResult.Succeeded)
        {
          return BadRequest("User creation failed");
        }
      }

      var token = GenerateJwtToken(user);

      return Ok(new { token });
    }

    [HttpGet("confirm-email")]
    public async Task<IActionResult> ConfirmEmail(string email, string emailConfirmToken)
    {
      var user = await _userManager.FindByEmailAsync(email);

      if (user == null)
      {
        return BadRequest("Invalid email");
      }

      var result = await _userManager.ConfirmEmailAsync(user, emailConfirmToken);

      if (!result.Succeeded)
      {
        return BadRequest("Email confirmation failed");
      }

      return Ok("Email confirmed successfully");
    }
  }
}