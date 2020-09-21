using Demo.Web.Api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Web.Api
{
    public static class WebApiStartup
    {
        public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration config, List<Type> autoMapperProfileAssemblies = null)
        {
            services.Configure<AppSettings>(config.GetSection("AppSettings"));

            services.AddJwtAuthenctication(config);

            return services;
        }
    }
}
