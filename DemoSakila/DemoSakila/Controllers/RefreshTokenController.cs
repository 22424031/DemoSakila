﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sakila.Application.Contracts.Staffs;
using Sakila.Application.Contracts.Refresh_tokens;
using Sakila.Application.Feature.RefreshToken.Request;
using Sakila.Application.Dtos.Common;
using Sakila.Application.Dtos.RefreshTokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Sakila.Application.Ententions;

namespace DemoSakila.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RefreshTokenController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration configuration;
        private readonly IStaffRepository _staffRepository;
        public RefreshTokenController(IMediator mediator, IStaffRepository staffRepository, IConfiguration configurationmain
            , IRefresh_tokenRepository refresh_TokenRepository
            )
        {
            _mediator = mediator;
            configuration = configurationmain;
            _staffRepository = staffRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_token"></param>
        /// <returns></returns>
        [HttpGet("GetToken")]
        public async Task<ActionResult<BaseResponse<BaseTokenDto>>> GetToken(string _token)
        {
            var baseResponse = new BaseResponse<BaseTokenDto>();
            var jwtHandler = new JwtSecurityTokenHandler();
            var jsonToken = jwtHandler.ReadJwtToken(_token);
            var id = jsonToken.Claims.First(x => x.Type == "Id").Value;
            var userName = jsonToken.Claims.First(x => x.Type == "UserName").Value;
            var password = jsonToken.Claims.First(x => x.Type == "Password").Value;
            var baseToken = new BaseTokenDto();
            var refreshToken = GetTokenWithExp(Convert.ToInt32(configuration["TimeLimitRefreshToken"]), userName, password, id);
            baseToken.Password = EnCryptExtension.Encrypt(password, configuration["keyEncrypt"]!);
            baseToken.UserName = EnCryptExtension.Encrypt(userName, configuration["keyEncrypt"]!);
            baseToken.Token = GetTokenWithExp(Convert.ToInt32(configuration["TimeLimitToken"]), userName, password, id);
            baseToken.RefreshToken = refreshToken;
            baseResponse.Data = baseToken;

            Refresh_tokenDto refreshTokenDto = new()
            {
                Staff_Id = Convert.ToInt32(id),
                token = refreshToken
            };

            var result = await _mediator.Send(new UpdateTokenRequest
            {
                Refresh_token = refreshTokenDto
            });

            if (result)
            {
                baseResponse.Status = 200;
                baseResponse.Data.Email = userName;
                return baseResponse;
            }
            else
            {
                baseResponse.ErrorMessage = "Error Internal server update token fail";
                baseResponse.ErrorCode = "ErrorInternalServer";
                baseResponse.Status = 500;
                baseResponse.Data = null;
                return baseResponse;
            }

        }
        private string GetTokenWithExp(int minute, string userName, string password, string staff_Id)
        {
            var issuer = configuration["jwtBearer:Issuer"];
            var audience = configuration["jwtBearer:Audience"];
            var key = Encoding.ASCII.GetBytes(configuration["jwtBearer:SigningKey"]);

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