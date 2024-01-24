using Application;
using Domain.Repositories.Accounts;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Context;
using Infrastructure.EntityFramework.Repository.TiposProyectos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Core;
using System.Reflection;

namespace Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAplication();
            var connectionString = configuration.GetConnectionString("DatabaseConection");
            services.AddDbContext<ReadDbContext>(context => { context.UseSqlServer(connectionString); });
            services.AddDbContext<WriteDbContext>(context => { context.UseSqlServer(connectionString); });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();

            return services;
        }

    }
}
