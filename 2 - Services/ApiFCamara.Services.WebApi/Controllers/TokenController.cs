using ApiFCamara.Application.Model;
using ApiFCamara.Services.WebApi.Configuration;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



namespace ApiFCamara.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class TokenController : Controller
    {
        private JwtTokenConfiguration _configuration;

        public TokenController(IOptions<JwtTokenConfiguration> configuration)
        {
            _configuration = configuration.Value;
        }       

        public IActionResult Post([FromBody] UserViewModel user)
        {
            if (user.Username != "admin" || user.Password != "admin")
                return Unauthorized();            

            var timeExpiration = DateTime.Now.AddMinutes(_configuration.TokenExperiationInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration.Issuer,
                audience: _configuration.Audience,
                expires: timeExpiration,
                claims: new Claim[] {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                    new Claim(JwtRegisteredClaimNames.UniqueName,user.Username),
                    new Claim("management","management")
                },
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Key)), SecurityAlgorithms.HmacSha256),
                notBefore: DateTime.Now
            );                        

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }
    }
}
