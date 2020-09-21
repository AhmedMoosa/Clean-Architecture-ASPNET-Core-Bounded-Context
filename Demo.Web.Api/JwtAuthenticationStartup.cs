using Demo.Web.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Web.Api
{
    public static class JwtAuthenticationStartup
    {
        public static IServiceCollection AddJwtAuthenctication(this IServiceCollection services, IConfiguration config)
        {

            var settingsSection = config.GetSection("AppSettings");
            AppSettings settings = settingsSection.Get<AppSettings>();
            byte[] key = Encoding.UTF8.GetBytes(settings.Secret);

            services.AddAuthentication(authOptions =>
                {
                    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(jwtOptions =>
                {
                    jwtOptions.SaveToken = true;
                    jwtOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateLifetime = true
                    };
                });
            return services;
        }
    }
}
