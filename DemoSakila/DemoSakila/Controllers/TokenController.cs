using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sakila.Application.Contracts.Staffs;
using Sakila.Application.Feature.Staff.Request;
using Sakila.Application.Feature.RefreshToken.Request;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Sakila.Application.Ententions;
using Sakila.Application.Dtos.Common;
using Sakila.Application.Dtos.RefreshTokens;

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
        public async Task<ActionResult<BaseResponse<BaseTokenDto>>> GetToken(string userName, string password)
        {
            var baseResponse = new BaseResponse<BaseTokenDto>();
            var basetoken = new BaseTokenDto();
            
            return baseResponse;
        }
        [HttpGet("GetTokenRefeshToken")]
        public async Task<ActionResult<BaseResponse<BaseTokenDto>>> GetTokenRefeshToken(string userName, string password,string keyEncrypt)
        {
            var baseResponse = new BaseResponse<BaseTokenDto>();
            var basetoken = new BaseTokenDto();
         
            return baseResponse;
        }
        private string GetTokenWithExp(int minute,string userName, string password, string staff_Id)
        {
            var issuer = configuration["jwtBearer:Issuer"];
            var audience = configuration["jwtBearer:Audience"];
            var key = Encoding.ASCII.GetBytes
            (configuration["jwtBearer:SigningKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Id", staff_Id),
                new Claim("UserName", userName),
                new Claim("Password", password),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
                Expires = DateTime.UtcNow.AddMinutes(minute),
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
            catch (Exception ex) { }
            return stringToken;
        }
    }
}
