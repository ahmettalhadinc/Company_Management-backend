﻿using Company_Management.Core.Models;
using Company_Management.Core.Services;
using Company_Management.Service.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Company_Management.Service.Services
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateRefreshToken()
        {
            byte[] number=new byte[32];

           using RandomNumberGenerator random=RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }

        public Token CreateToken(User user, List<Role> roles)
        {
           Token token = new Token();

            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new(symmetricSecurityKey,SecurityAlgorithms.HmacSha256);
            token.Expiration = DateTime.Now.AddDays(7);
            JwtSecurityToken jwtSecurityToken = new(
                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                expires: token.Expiration,
                claims: SetClaims(user, roles),
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials

                );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            token.AccessToken=jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            token.RefreshToken=CreateRefreshToken();
            return token;
        }

        public IEnumerable<Claim> SetClaims(User user, List<Role> roles)
        {
            Claim claim = new("sub",user.Id.ToString());
            List<Claim> claims = new List<Claim>();
            claims.Add(claim);
            claims.AddName(user.Name);
            claims.AddRoles(roles.Select(p=>p.Name).ToArray());

            return claims;
        }
    }
}
