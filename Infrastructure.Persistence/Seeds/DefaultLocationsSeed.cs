using Application.Interfaces;
using Domain.Common;
using Domain.Interfaces;
using Domain.Models.Locations;
using Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
    public class DefaultLocationsSeed
    {
        public static async Task SeedAsync(IGenericRepositoryAsync<Location> repositoryAsync)
        {
            List<Location> locations = new()
            {
                new Location()
                {
                    Name = "Palma Airport",
                    City = "Palma",
                    Street = "",
                    Building = 0,
                    PostalCode = "07611",
                    Email = "",
                    Phone = "",
                    Active = true,
                },
                new Location()
                {
                    Name = "Port d'Alcudia",
                    City = "Puerto De Alcudia",
                    Street = "",
                    Building = 0,
                    PostalCode = "07400",
                    Email = "",
                    Phone = "",
                    Active = true,
                },
                new Location()
                {
                    Name = "Santa Ponsa",
                    City = "Santa Ponsa",
                    Street = "",
                    Building = 0,
                    PostalCode = "07180",
                    Email = "",
                    Phone = "",
                    Active = true,
                },
                new Location()
                {
                    Name = "Deia",
                    City = "Deia",
                    Street = "",
                    Building = 0,
                    PostalCode = "07179",
                    Email = "",
                    Phone = "",
                    Active = true,
                },
                new Location()
                {
                    Name = "Manacor",
                    City = "Manacor",
                    Street = "",
                    Building = 0,
                    PostalCode = "07500",
                    Email = "",
                    Phone = "",
                    Active = true,
                },
            };

            foreach (Location location in locations)
            {
                await repositoryAsync.AddAsync(location);
            }
        }
    }
}
