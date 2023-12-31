﻿using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Common;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options
                        .UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
               options
                   .UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }
            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<ILocationRepositoryAsync, LocationRepositoryAsync>();
            services.AddTransient<IVehicleRepositoryAsync, VehicleRepositoryAsync>();
            services.AddTransient<IReservationRepositoryAsync, ReservationRepositoryAsync>();
            services.AddTransient<IGenericRepositoryAsync<AuditableBaseEntity>, GenericRepositoryAsync<AuditableBaseEntity>>();
            #endregion
        }
    }
}
