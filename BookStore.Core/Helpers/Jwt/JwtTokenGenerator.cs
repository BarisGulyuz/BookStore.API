﻿using BookStore.Core.DTO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Jwt
{
    public class JwtTokenGenerator
    {
        public static string GenerateToken(UserReponseDto userResponse)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.Key));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();


            claims.Add(new Claim(ClaimTypes.Role, userResponse.Role));
            claims.Add(new Claim(ClaimTypes.Name, userResponse.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, userResponse.Id.ToString()));



            JwtSecurityToken token = new JwtSecurityToken(
                issuer: JwtSettings.Issuer,
                audience: JwtSettings.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(JwtSettings.Expire),
                signingCredentials: credentials
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }

    }
}
