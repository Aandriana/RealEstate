using Common.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RealEstate.DAL.Data;
using RealEstate.DAL.Entities;
using RealEstate.DAL.UnitOfWork;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace RealEstate.BLL.Infrastructure
{
    public static class BllServiceCollectionsExtentions
    {
        public static IServiceCollection AddMainContext(this IServiceCollection services, string connectionString, IConfiguration Configuration)
        {
            return services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString(connectionString)));
        }

        public static IServiceCollection AddIdentityFromBll(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                  .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }

        public static IServiceCollection AddAuthenticationFromBll(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<TokenManagement>(Configuration.GetSection("tokenManagement"));
            var token = Configuration.GetSection("tokenManagement").Get<TokenManagement>();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = token.JwtIssuer,
                        ValidAudience = token.JwtIssuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token.JwtKey)),
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuer = true,
                        ValidateAudience = true
                    };
                });

            return services;
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {

            return services.AddTransient<IUnitOfWork, UnitOfWork>(provider =>
                new UnitOfWork(provider.GetRequiredService<ApplicationDbContext>()));
        }
    }
}
