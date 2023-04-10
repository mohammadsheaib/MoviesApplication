﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MoviesApplication.Entities.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoviesApplication.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/AuthenticationController")]
    public class AuthenticationController : ControllerBase
    {
        [AllowAnonymous]
        [Route("Login")]
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (user == null)
                return BadRequest("Invalid client request");

            if (user.username == "username" && user.password == "P@ssw0rd")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(issuer: "https://localhost:7090",
                    audience: "http://localhost:4200",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(1),
                    signingCredentials: signingCredentials);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }
    }
}