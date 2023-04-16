﻿using Homework2.Base.Jwt;
using Homework2.Base.Response;
using Homework2.Data.Model;
using Homework2.Data.Repository.Abstract;
using Homework2.Data.UnitOfWork.Abstract;
using Homework2.Dto.Token;
using Homework2.Service.Abstract;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Service.Concrete
{
    public class TokenManagementService : ITokenManagementService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<Account> genericRepository;
        private readonly JwtConfig jwtConfig;
        public TokenManagementService(IUnitOfWork unitOfWork, IGenericRepository<Account> genericRepository, IOptionsMonitor<JwtConfig> jwtConfig)
        {
            this.unitOfWork = unitOfWork;
            this.genericRepository = genericRepository;
            this.jwtConfig = jwtConfig.CurrentValue;
        }

        public BaseResponse<TokenResponse> GenerateToken(TokenRequest request)
        {
            try
            {
                Account account = genericRepository.Where(x => x.UserName == request.UserName).FirstOrDefault();
                if (account is null)
                {
                    Log.Error("InvalidUserInformation");
                    return new BaseResponse<TokenResponse>("InvalidUserInformation");
                }

                // todo check password retry count

                if (account.Password != request.Password)
                {
                    // update password retry count ++
                    Log.Error("InvalidUserInformation");
                    return new BaseResponse<TokenResponse>("InvalidUserInformation");
                }


                string token = GenerateAccessToken(account, DateTime.Now);

                account.LastActivity = DateTime.UtcNow;
                genericRepository.Put(account);
                unitOfWork.Complete();

                TokenResponse tokenResponse = new TokenResponse
                {
                    AccessToken = token,
                    ExpireTime = DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
                    Role = account.Role,
                    UserName = account.UserName
                };

                return new BaseResponse<TokenResponse>(tokenResponse);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Token_Error");
                return new BaseResponse<TokenResponse>("Token_Error");
            }
        }

        private string GenerateAccessToken(Account account, DateTime now)
        {
            // Get claim value
            Claim[] claims = GetClaim(account);

            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

            var secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);

            var jwtToken = new JwtSecurityToken(
                jwtConfig.Issuer,
                shouldAddAudienceClaim ? jwtConfig.Audience : string.Empty,
                claims,
                expires: now.AddMinutes(jwtConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return accessToken;
        }

        private string GenerateAccessToken(Person person, DateTime now)
        {
            // Get claim value
            Claim[] claims = GetClaim(person);

            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

            var secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);

            var jwtToken = new JwtSecurityToken(
                jwtConfig.Issuer,
                shouldAddAudienceClaim ? jwtConfig.Audience : string.Empty,
                claims,
                expires: now.AddMinutes(jwtConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return accessToken;
        }

        private static Claim[] GetClaim(Account account)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.UserName),
                new Claim(ClaimTypes.Role, account.Role),
                new Claim("Name", account.Name),
                new Claim("Role", account.Role),
                new Claim("Email", account.Email),
                new Claim("AccountId", account.Id.ToString()),
                new Claim("LastActivity", account.LastActivity.ToLongTimeString())
            };

            return claims;
        }

        private static Claim[] GetClaim(Person person)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, person.Id.ToString()),
                new Claim(ClaimTypes.Name, person.FirstName),
               // new Claim(ClaimTypes.Role, person.Role),
                new Claim("Name", person.FirstName),
               // new Claim("Role", person.Role),
                new Claim("Email", person.Email),
                new Claim("AccountId", person.Id.ToString()),
                new Claim("DateOfBirth", person.DateOfBirth.ToLongTimeString())
            };

            return claims;
        }


    }
}
