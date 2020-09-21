using Demo.Users.Core.Interfaces;
using Demo.Web.Api.Extensions;
using Demo.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Web.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        IAuthenticationService _authService;
        AppSettings _appSettings;
        public AccountController(IAuthenticationService authSrvce,
            IOptionsMonitor<AppSettings> settings)
        {
            _authService = authSrvce;
            _appSettings = settings.CurrentValue;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.ValidateUserAsync(model.Email, model.Password, model.RememberMe);
                if (result.Success)
                {
                    var user = result.Payload;
                    var claims = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.Id)
                    });

                    var token = GetAccessToken(claims);

                    return this.AppOk(new
                    {
                        token.AccessToken,
                        token.Expires,
                        user = new
                        {
                            user.Email,
                            user.Mobile
                        }
                    });
                }
                return this.AppOk(result);
            }
            return this.AppBadRequest(ModelState);
        }

        private TokenViewModel GetAccessToken(ClaimsIdentity claims)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtHandler = new JwtSecurityTokenHandler();

            var token = jwtHandler.CreateToken(tokenDescriptor);
            var access_token = jwtHandler.WriteToken(token);

            return new TokenViewModel
            {
                AccessToken = access_token,
                Expires = token.ValidTo.Ticks
            };
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.CreateForAsync(new Users.Core.DTOs.InputUser
                {
                    Email = model.Email,
                    Mobile = model.Mobile,
                    Password = model.Password
                });
                if (result.Success)
                {
                    var user = result.Payload;
                    var claims = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.Id)
                    });

                    var token = GetAccessToken(claims);

                    return this.AppOk(new
                    {
                        token.AccessToken,
                        token.Expires,
                        user = new
                        {
                            user.Email,
                            user.Mobile
                        }
                    });
                }
                return this.AppOk(result);
            }
            return this.AppBadRequest(ModelState);
        }
    }
}
