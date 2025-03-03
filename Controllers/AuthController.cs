using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CafeManiaApi.Dtos;
using Microsoft.EntityFrameworkCore;
using CafeManiaApi.DataContexts;
using CafeManiaApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace CafeManiaApi.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public AuthController(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto user)
        {
            var usuario = _context.Colaboradores
            .FirstOrDefault(u => u.UsuarioColaborador == user.Username && u.SenhaColaborador == user.Password);

            if (usuario == null)
                return Unauthorized("Usuário ou senha inválidos");

            var token = GenerateJwtToken(usuario);
            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(Colaborador usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.UsuarioColaborador),
                new Claim(ClaimTypes.Role, usuario.Permissoes)
                // new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Login()
        {
            return Ok("Acesso permitido para usuários autenticados!");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult Admin()
        {
            return Ok("Acesso permitido apenas para administradores!");
        }

        [Authorize(Roles = "Admin, Colaborador")]
        [HttpGet("usuarios")]
        public IActionResult Colaboradores()
        {
            return Ok("Acesso permitido para administradores e colaboradores!");
        }

    }
}
