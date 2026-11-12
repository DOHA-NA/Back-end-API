using ApiCe.Core.Entites;
using ApiCe.Infra.Data;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiCe.Api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    
    {

       private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(
            AppDbContext context,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Email and Password are required");
            }

            var email = request.Email.Trim().ToLower();

            var exists = await _context.Users
                .AnyAsync(u => u.Email == email);

            if (exists)
                return Conflict("Email already registered");

            if (request.StudentId.HasValue)
            {
                var studentExists = await _context.Students
                    .AnyAsync(s => s.Id == request.StudentId.Value);

                if (!studentExists)
                    return BadRequest("Student does not exist");
            }

            var user = new User
            {
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(
                    request.Password),
                Role = "Student",
                StudentId = request.StudentId
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            var token = GenerateToken(user);

            return Ok(new
            {
                Message = "Registration successful",
                Token = token
            });
            
        }
        [HttpPost("login")]
public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            {
                return Unauthorized( "The Email OR Passworde Uncorect");
            }

            // توليد التوكن
            var token =GenerateToken(user);

            return Ok(new
            {
                message = "Login successful",
                token = token
            });
        }
        private string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["Jwt:Key"]!));

            var credentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,
                    user.Id.ToString()),

                new Claim(ClaimTypes.Email, user.Email),

                new Claim(ClaimTypes.Role, user.Role)
            };

            var expiry = double.Parse(
                _configuration["Jwt:ExpiryHours"]!);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(expiry),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }

        public class RegisterRequest
        {
            public string Email { get; set; } = string.Empty;

            public string Password { get; set; } = string.Empty;

            public int? StudentId { get; set; }
        }
    }}
