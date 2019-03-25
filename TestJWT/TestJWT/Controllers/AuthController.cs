using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TestJWT.Models;

namespace TestJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        public AppSettings appSettings { get; }

        public AuthController(IConfiguration configuration)
        {
            appSettings = configuration.GetSection("AppSettings").Get<AppSettings>(); ;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] CredentialsModel credentials)
        {
            if (credentials.UserID == "admin" && credentials.Password == "123456")
            {
                var token = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .Issuer(appSettings.Issuer)
                .WithSecret(appSettings.Secret)
                .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
                .AddClaim("openid", "12345")
                .Build();
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}