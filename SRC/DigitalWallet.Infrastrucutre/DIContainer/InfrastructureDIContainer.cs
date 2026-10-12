using System;
using DigitalWallet.Infrastrucutre.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace DigitalWallet.Infrastrucutre.DIContainer;

public static class InfrastructureDIContainer
{
public static void AddInfrastructureLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ApplicationDb"));
            });
        }
          
}
