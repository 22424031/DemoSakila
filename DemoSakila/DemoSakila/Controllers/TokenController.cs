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
            var user = await _mediator.Send(new LoginRequest { UserName = userName, Password = password });
            if (user is null)
            {
                baseResponse.ErrorMessage = "User not exists";
                baseResponse.ErrorCode = "User Not Found";
                baseResponse.Status = 400;
                return baseResponse;
            }
            var refreshToken = this.GetTokenWithExp(Convert.ToInt32(configuration["TimeLimitRefreshToken"]), userName, password, user.Staff_Id.ToString());
            baseResponse.ErrorMessage = "";
            baseResponse.ErrorCode = "";
            baseResponse.Status = 200;
            basetoken.Token = this.GetTokenWithExp(Convert.ToInt32(configuration["TimeLimitToken"]), userName, password, user.Staff_Id.ToString());
            basetoken.RefreshToken = refreshToken;
            basetoken.Password = EnCryptExtension.Encrypt(password, configuration["keyEncrypt"]!);
            basetoken.UserName = EnCryptExtension.Encrypt(userName, configuration["keyEncrypt"]!);
            baseResponse.Data = basetoken;
            Refresh_tokenDto refreshTokenDto = new();
            refreshTokenDto.Staff_Id = Convert.ToInt32(user.Staff_Id);
            refreshTokenDto.token = refreshToken;
            var isStaff = await _mediator.Send(new ExistsStaffIDRequest { id = user.Staff_Id });
            if (isStaff)//udpate token 
            {
                var result = await _mediator.Send(new UpdateTokenRequest { Refresh_token = refreshTokenDto });
                if (!result)
                {
                    baseResponse.ErrorMessage = "Update refreshToken fail";
                    baseResponse.ErrorCode = "UpdateFail";
                    baseResponse.Status = 500;
                    baseResponse.Data = null;
                    return baseResponse;
                }
            }
            else
            {
                var result = await _mediator.Send(new CreateTokenRequest { refresh_TokenDto = refreshTokenDto });
                if (result is null)
                {
                    baseResponse.ErrorMessage = "Update refreshToken fail";
                    baseResponse.ErrorCode = "UpdateFail";
                    baseResponse.Status = 500;
                    baseResponse.Data = null;
                    return baseResponse;
                }
            }

            baseResponse.Data.Email = userName;
            return baseResponse;
        }
        [HttpGet("GetTokenRefeshToken")]
        public async Task<ActionResult<BaseResponse<BaseTokenDto>>> GetTokenRefeshToken(string userName, string password,string keyEncrypt)
        {
            var baseResponse = new BaseResponse<BaseTokenDto>();
            var basetoken = new BaseTokenDto();
            var refreshToken = await _mediator.Send(new GetRefreshTokenRequest { UserName = userName, Password = password, key = keyEncrypt });
            if (refreshToken is null)
            {
                baseResponse.ErrorMessage = "refresh not exists";
                baseResponse.ErrorCode = "refreshNotFound";
                baseResponse.Status = 400;
                return baseResponse;
            }
            baseResponse.ErrorMessage = "";
            baseResponse.ErrorCode = "";
            baseResponse.Status = 200;
            basetoken.RefreshToken = refreshToken.RefreshToken;
            baseResponse.Data = basetoken;
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
