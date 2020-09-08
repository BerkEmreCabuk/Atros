using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atros.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using Atros.Domain.Users.Queries;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Atros.Domain.Users.Models;

namespace Atros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IOptions<JWTSettingsModel> _settings;
        private readonly ILogger<UserController> _logger;
        private readonly IMemoryCache _memory;
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

        public UserController(
            IOptions<JWTSettingsModel> settings,
            IMemoryCache memory,
            ILogger<UserController> logger)
        {
            _settings = settings;
            _logger = logger;
            _memory = memory;
        }

        [HttpGet("gettoken")]
        public async Task<IActionResult> GetToken(string userName, string password)
        {
            try
            {
                var userModel = await Mediator.Send(new GetUserByNameAndPasswordQuery { Username = userName, Password = password });

                var tokenHandler = new JwtSecurityTokenHandler();
                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_settings.Value.SecretKey));
                var jwt = new JwtSecurityToken(
                    issuer: _settings.Value.Issuer,
                    audience: _settings.Value.Audience,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                var responseJson = new
                {
                    access_token = encodedJwt,
                    expires_in = (int)TimeSpan.FromDays(1).TotalSeconds
                };
                _memory.Set<UserModel>(encodedJwt, userModel, TimeSpan.FromDays(1));
                return Ok(responseJson);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}