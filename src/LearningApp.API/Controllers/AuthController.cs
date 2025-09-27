using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LearningApp.Core.DTOs;
using LearningApp.Core.Entities;
using LearningApp.API.Services;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace LearningApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ITokenService tokenService,
            ILogger<AuthController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            _logger.LogInformation("User registration attempt for email: {Email}", registerDto.Email);

            var user = new User
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                _logger.LogWarning("User registration failed for email: {Email}. Errors: {Errors}", 
                    registerDto.Email, string.Join(", ", result.Errors.Select(e => e.Description)));
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }

            _logger.LogInformation("User registered successfully: {Email}", registerDto.Email);

            var token = await _tokenService.GenerateTokenAsync(user);
            return Ok(new { Token = token, User = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt
            }});
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            _logger.LogInformation("User login attempt for email: {Email}", loginDto.Email);

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                _logger.LogWarning("Login failed - user not found: {Email}", loginDto.Email);
                return Unauthorized("Invalid credentials");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                _logger.LogWarning("Login failed - invalid password for user: {Email}", loginDto.Email);
                return Unauthorized("Invalid credentials");
            }

            if (!user.IsActive)
            {
                _logger.LogWarning("Login failed - user account is inactive: {Email}", loginDto.Email);
                return Unauthorized("Account is inactive");
            }

            _logger.LogInformation("User logged in successfully: {Email}", loginDto.Email);

            var token = await _tokenService.GenerateTokenAsync(user);
            return Ok(new { Token = token, User = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt
            }});
        }
    }
}