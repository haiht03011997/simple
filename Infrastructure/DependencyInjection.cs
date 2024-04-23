using Application.Interfaces.Entities;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
        {
            services
            .AddPersistance(configuration);
            return services;
        }

        public static IServiceCollection AddPersistance(
        this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();

            return services;
        }

        //public static IServiceCollection AddAuth(
        //    this IServiceCollection services,
        //    IConfiguration configuration)
        //{
        //    var jwtSettings = new JwtSettings();
        //    configuration.Bind(JwtSettings.SectionName, jwtSettings);

        //    services.AddSingleton(Options.Create(jwtSettings));
        //    services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        //    services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
        //        .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuer = true,
        //            ValidateAudience = true,
        //            ValidateLifetime = true,
        //            ValidateIssuerSigningKey = true,
        //            ValidIssuer = jwtSettings.Issuer,
        //            ValidAudience = jwtSettings.Audience,
        //            IssuerSigningKey = new SymmetricSecurityKey(
        //                Encoding.UTF8.GetBytes(jwtSettings.Secret)),
        //        });

        //    return services;
        //}
    }
}
