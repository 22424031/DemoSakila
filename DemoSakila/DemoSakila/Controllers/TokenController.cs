using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sakila.Application.Contracts.Staffs;
using Sakila.Application.Feature.Staff.Request;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoSakila.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class TokenController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration configuration;
        private readonly IStaffRepository _staffRepository;
        public TokenController(IMediator mediator, IStaffRepository staffRepository, IConfiguration configurationmain)
        {
            _mediator = mediator;
            configuration = configurationmain;
            _staffRepository = staffRepository;
        }
        [HttpGet("GetToken")]
        public async Task<ActionResult<string>> GetToken(string userName, string password)
        {
            var user = await _mediator.Send(new LoginRequest { UserName = userName, Password = password });
            if (user is null) return null;
            var issuer = configuration["jwtBearer:Issuer"];
            var audience = configuration["jwtBearer:Audience"];
            var key = Encoding.ASCII.GetBytes
            (configuration["jwtBearer:SigningKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Id", user.Staff_Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Email, password),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            string stringToken = "";
            try
            {
               
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                stringToken = tokenHandler.WriteToken(token);
            }
            catch(Exception ex) { }
            return stringToken;
        }
    }
}
